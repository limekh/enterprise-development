using CarWash.Domain.Data;
using CarWash.Domain.Entities;

namespace CarWash.Infrastructure.InMemory.Repositories;

/// <summary>
/// Имплементация репозитория для авто
/// </summary>
public class CarInMemoryRepository(CarWashData data)
    : IRepository<Car, int>
{
    public void Create(Car entity)
    {
        data.Cars.Add(entity);
    }

    public Car Read(int entityId)
    {
        return data.Cars.First(car => car.Id == entityId);
    }

    public List<Car> ReadAll()
    {
        return [.. data.Cars];
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
            data.Cars.Remove(car);
    }
}