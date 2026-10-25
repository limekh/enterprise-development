using CarWash.Domain.Data;
using CarWash.Domain.Entities;

namespace CarWash.Infrastructure.InMemory.Repositories;

/// <summary>
/// Имплементация репозитория для вида процедуры
/// </summary>
public class CarWashProcedureInMemoryRepository(CarWashData data)
    : IRepository<CarWashProcedure, int>
{
    public void Create(CarWashProcedure entity)
    {
        data.Procedures.Add(entity);
    }

    public CarWashProcedure Read(int entityId)
    {
        return data.Procedures.First(procedure => procedure.Id == entityId);
    }

    public List<CarWashProcedure> ReadAll()
    {
        return [.. data.Procedures];
    }

    public void Update(CarWashProcedure entity)
    {
        Delete(entity.Id);
        Create(entity);
    }

    public void Delete(int entityId)
    {
        CarWashProcedure procedure = Read(entityId);
        if (procedure != null)
            data.Procedures.Remove(procedure);
    }
}