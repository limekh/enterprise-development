using CarWash.Application.Contracts.Customers;
using CarWash.Domain.Entities;
using CarWash.Infrastructure.InMemory;

namespace CarWash.Application.Services;

/// <summary>
/// Служба для CRUD-операций над клиентами
/// </summary>
public class CarWashCustomerService(
    IRepository<CarWashCustomer, int> customerRepository)
    : ICarWashCustomerService
{
    private readonly IRepository<CarWashCustomer, int> _customerRepository =
        customerRepository;

    public CarWashCustomerDto Create(CarWashCustomerCreateUpdateDto dto)
    {
        int newId = _customerRepository.ReadAll()
            .Select(customer => customer.Id)
            .DefaultIfEmpty(0)
            .Max() + 1;

        var customer = new CarWashCustomer
        {
            Id = newId,
            LastName = dto.LastName,
            FirstName = dto.FirstName,
            Patronymic = dto.Patronymic,
            Phone = dto.Phone
        };

        _customerRepository.Create(customer);

        return MapToDto(customer);
    }

    public CarWashCustomerDto Get(int dtoId)
    {
        return MapToDto(_customerRepository.Read(dtoId));
    }

    public List<CarWashCustomerDto> GetAll()
    {
        return _customerRepository.ReadAll()
            .Select(MapToDto)
            .ToList();
    }

    public CarWashCustomerDto Update(
        CarWashCustomerCreateUpdateDto dto,
        int dtoId)
    {
        var customer = new CarWashCustomer
        {
            Id = dtoId,
            LastName = dto.LastName,
            FirstName = dto.FirstName,
            Patronymic = dto.Patronymic,
            Phone = dto.Phone
        };

        _customerRepository.Update(customer);

        return MapToDto(customer);
    }

    public void Delete(int dtoId)
    {
        _customerRepository.Delete(dtoId);
    }

    private static CarWashCustomerDto MapToDto(CarWashCustomer customer)
    {
        return new CarWashCustomerDto(
            customer.Id,
            customer.LastName,
            customer.FirstName,
            customer.Patronymic,
            customer.Phone);
    }
}
