using CarWash.Domain.Data;
using CarWash.Domain.Entities;

namespace CarWash.Infrastructure.InMemory.Repositories;

/// <summary>
/// Имплементация репозитория для заказов
/// </summary>
public class OrderInMemoryRepository(CarWashData data)
    : IRepository<Order, int>
{
    public void Create(Order entity)
    {
        data.Orders.Add(entity);
    }

    public Order Read(int entityId)
    {
        return data.Orders.First(order => order.Id == entityId);
    }

    public List<Order> ReadAll()
    {
        return [.. data.Orders];
    }

    public void Update(Order entity)
    {
        Delete(entity.Id);
        Create(entity);
    }

    public void Delete(int entityId)
    {
        var order = Read(entityId);
        data.Orders.Remove(order);
    }
}