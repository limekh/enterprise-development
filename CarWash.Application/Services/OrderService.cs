
using CarWash.Application.Contracts.Orders;
using CarWash.Domain.Entities;
using CarWash.Infrastructure.InMemory;

namespace CarWash.Application.Services;

/// <summary>
/// Служба для CRUD-операций над заказами
/// </summary>
public class OrderService(
    IRepository<Order, int> orderRepository,
    IRepository<Car, int> carRepository,
    IRepository<CarWashProcedure, int> procedureRepository)
    : IOrderService
{
    private readonly IRepository<Order, int> _orderRepository = orderRepository;
    private readonly IRepository<Car, int> _carRepository = carRepository;
    private readonly IRepository<CarWashProcedure, int> _procedureRepository =
        procedureRepository;

    public OrderDto Create(OrderCreateUpdateDto dto)
    {
        Car car = _carRepository.Read(dto.CarId);
        CarWashProcedure procedure =
            _procedureRepository.Read(dto.ProcedureId);

        int newId = _orderRepository.ReadAll()
            .Select(order => order.Id)
            .DefaultIfEmpty(0)
            .Max() + 1;

        var order = new Order
        {
            Id = newId,
            CarId = car.Id,
            Car = car,
            ProcedureId = procedure.Id,
            Procedure = procedure,
            StartTime = dto.StartTime,
            WashBoxNumber = dto.WashBoxNumber
        };

        _orderRepository.Create(order);
        car.Orders.Add(order);
        procedure.Orders.Add(order);

        return MapToDto(order);
    }

    public OrderDto Get(int dtoId)
    {
        return MapToDto(_orderRepository.Read(dtoId));
    }

    public List<OrderDto> GetAll()
    {
        return _orderRepository.ReadAll()
            .Select(MapToDto)
            .ToList();
    }

    public OrderDto Update(OrderCreateUpdateDto dto, int dtoId)
    {
        Order oldOrder = _orderRepository.Read(dtoId);
        Car car = _carRepository.Read(dto.CarId);
        CarWashProcedure procedure =
            _procedureRepository.Read(dto.ProcedureId);

        oldOrder.Car.Orders.Remove(oldOrder);
        oldOrder.Procedure.Orders.Remove(oldOrder);

        var order = new Order
        {
            Id = dtoId,
            CarId = car.Id,
            Car = car,
            ProcedureId = procedure.Id,
            Procedure = procedure,
            StartTime = dto.StartTime,
            WashBoxNumber = dto.WashBoxNumber
        };

        _orderRepository.Update(order);
        car.Orders.Add(order);
        procedure.Orders.Add(order);

        return MapToDto(order);
    }

    public void Delete(int dtoId)
    {
        Order order = _orderRepository.Read(dtoId);

        order.Car.Orders.Remove(order);
        order.Procedure.Orders.Remove(order);

        _orderRepository.Delete(dtoId);
    }

    private static OrderDto MapToDto(Order order)
    {
        return new OrderDto(
            order.Id,
            order.CarId,
            order.ProcedureId,
            order.StartTime,
            order.WashBoxNumber);
    }
}
