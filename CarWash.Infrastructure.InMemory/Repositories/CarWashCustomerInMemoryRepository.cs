using CarWash.Domain.Data;
using CarWash.Domain.Entities;

namespace CarWash.Infrastructure.InMemory.Repositories;

/// <summary>
/// Имплементация репозитория для клиентов
/// </summary>
public class CarWashCustomerInMemoryRepository(CarWashData data)
    : IRepository<CarWashCustomer, int>
{
    public void Create(CarWashCustomer entity)
    {
        data.Customers.Add(entity);
    }

    public CarWashCustomer Read(int entityId)
    {
        return data.Customers.First(customer => customer.Id == entityId);
    }

    public List<CarWashCustomer> ReadAll()
    {
        return [.. data.Customers];
    }

    public void Update(CarWashCustomer entity)
    {
        Delete(entity.Id);
        Create(entity);
    }

    public void Delete(int entityId)
    {
        var customer = Read(entityId);
        data.Customers.Remove(customer);
    }
}