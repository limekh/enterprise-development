using CarWash.Domain.Data;
using CarWash.Domain.Entities;

namespace CarWash.Infrastructure.InMemory.Repositories;

/// <summary>
/// Имплементация репозитория для авто
/// </summary>
public class CarInMemoryRepository(CarWashData data)
    : IRepository<Car, int>
{
    private readonly List<Car> _cars = data.Cars;

    public void Create(Car entity)
    {
        _cars.Add(entity);
    }

    public Car Read(int entityId)
    {
        return _cars.First(car => car.Id == entityId);
    }

    public List<Car> ReadAll()
    {
        return [.. _cars];
    }

    public void Update(Car entity)
    {
        Delete(entity.Id);
        Create(entity);
    }

    public void Delete(int entityId)
    {
        Car car = Read(entityId);
        if (car != null)
            _cars.Remove(car);
    }
}