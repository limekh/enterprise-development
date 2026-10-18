using CarWash.Domain.Data;
using CarWash.Domain.Entities;

namespace CarWash.Infrastructure.InMemory.Repositories;

/// <summary>
/// Имплементация репозитория для заказов
/// </summary>
public class OrderInMemoryRepository(CarWashData data)
    : IRepository<Order, int>
{
    private readonly List<Order> _orders = data.Orders;

    public void Create(Order entity)
    {
        _orders.Add(entity);
    }

    public Order Read(int entityId)
    {
        return _orders.First(order => order.Id == entityId);
    }

    public List<Order> ReadAll()
    {
        return [.. _orders];
    }

    public void Update(Order entity)
    {
        Delete(entity.Id);
        Create(entity);
    }

    public void Delete(int entityId)
    {
        Order order = Read(entityId);
        if (order != null)
            _orders.Remove(order);
    }
}