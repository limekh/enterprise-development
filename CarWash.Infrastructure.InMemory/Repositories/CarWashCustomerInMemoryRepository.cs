using CarWash.Domain.Data;
using CarWash.Domain.Entities;

namespace CarWash.Infrastructure.InMemory.Repositories;

/// <summary>
/// Имплементация репозитория для клиентов
/// </summary>
public class CarWashCustomerInMemoryRepository(CarWashData data)
    : IRepository<CarWashCustomer, int>
{
    private readonly List<CarWashCustomer> _customers = data.Customers;

    public void Create(CarWashCustomer entity)
    {
        _customers.Add(entity);
    }

    public CarWashCustomer Read(int entityId)
    {
        return _customers.First(customer => customer.Id == entityId);
    }

    public List<CarWashCustomer> ReadAll()
    {
        return [.. _customers];
    }

    public void Update(CarWashCustomer entity)
    {
        Delete(entity.Id);
        Create(entity);
    }

    public void Delete(int entityId)
    {
        CarWashCustomer customer = Read(entityId);
        if (customer != null)
            _customers.Remove(customer);
    }
}