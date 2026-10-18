using CarWash.Domain.Data;
using CarWash.Domain.Entities;

namespace CarWash.Infrastructure.InMemory.Repositories;

/// <summary>
/// Имплементация репозитория для вида процедуры
/// </summary>
public class CarWashProcedureInMemoryRepository(CarWashData data)
    : IRepository<CarWashProcedure, int>
{
    private readonly List<CarWashProcedure> _procedures = data.Procedures;

    public void Create(CarWashProcedure entity)
    {
        _procedures.Add(entity);
    }

    public CarWashProcedure Read(int entityId)
    {
        return _procedures.First(procedure => procedure.Id == entityId);
    }

    public List<CarWashProcedure> ReadAll()
    {
        return [.. _procedures];
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
            _procedures.Remove(procedure);
    }
}