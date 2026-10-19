using CarWash.Application.Contracts.Cars;
using CarWash.Domain.Entities;
using CarWash.Infrastructure.InMemory;

namespace CarWash.Application.Services;

/// <summary>
/// Служба для CRUD-операций над авто
/// </summary>
public class CarService(
    IRepository<Car, int> carRepository,
    IRepository<CarWashCustomer, int> customerRepository)
    : ICarService
{
    private readonly IRepository<Car, int> _carRepository = carRepository;
    private readonly IRepository<CarWashCustomer, int> _customerRepository =
        customerRepository;

    public CarDto Create(CarCreateUpdateDto dto)
    {
        CarWashCustomer customer = _customerRepository.Read(dto.CustomerId);

        int newId = _carRepository.ReadAll()
            .Select(car => car.Id)
            .DefaultIfEmpty(0)
            .Max() + 1;

        var car = new Car
        {
            Id = newId,
            CarCategory = dto.CarCategory,
            LicensePlate = dto.LicensePlate,
            Brand = dto.Brand,
            CustomerId = customer.Id,
            Customer = customer
        };

        _carRepository.Create(car);

        customer.Cars.Add(car);

        return MapToDto(car);
    }

    public CarDto Get(int dtoId)
    {
        return MapToDto(_carRepository.Read(dtoId));
    }

    public List<CarDto> GetAll()
    {
        return _carRepository.ReadAll()
            .Select(MapToDto)
            .ToList();
    }

    public CarDto Update(CarCreateUpdateDto dto, int dtoId)
    {
        Car oldCar = _carRepository.Read(dtoId);
        CarWashCustomer customer = _customerRepository.Read(dto.CustomerId);

        oldCar.Customer.Cars.Remove(oldCar);

        var car = new Car
        {
            Id = dtoId,
            CarCategory = dto.CarCategory,
            LicensePlate = dto.LicensePlate,
            Brand = dto.Brand,
            CustomerId = customer.Id,
            Customer = customer,
            Orders = oldCar.Orders
        };

        _carRepository.Update(car);
        customer.Cars.Add(car);

        return MapToDto(car);
    }

    public void Delete(int dtoId)
    {
        Car car = _carRepository.Read(dtoId);

        car.Customer.Cars.Remove(car);
        _carRepository.Delete(dtoId);
    }

    private static CarDto MapToDto(Car car)
    {
        return new CarDto(
            car.Id,
            car.CarCategory,
            car.LicensePlate,
            car.Brand,
            car.CustomerId);
    }
}
