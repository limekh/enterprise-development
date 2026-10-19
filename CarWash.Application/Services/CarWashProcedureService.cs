
using CarWash.Application.Contracts.Procedures;
using CarWash.Domain.Entities;
using CarWash.Infrastructure.InMemory;

namespace CarWash.Application.Services;

/// <summary>
/// Служба для CRUD-операций над услугами автомойки
/// </summary>
public class CarWashProcedureService(
    IRepository<CarWashProcedure, int> procedureRepository)
    : ICarWashProcedureService
{
    private readonly IRepository<CarWashProcedure, int> _procedureRepository =
        procedureRepository;

    public CarWashProcedureDto Create(CarWashProcedureCreateUpdateDto dto)
    {
        int newId = _procedureRepository.ReadAll()
            .Select(procedure => procedure.Id)
            .DefaultIfEmpty(0)
            .Max() + 1;

        var procedure = new CarWashProcedure
        {
            Id = newId,
            Name = dto.Name,
            CarCategory = dto.CarCategory,
            Price = dto.Price,
            Duration = dto.Duration
        };

        _procedureRepository.Create(procedure);

        return MapToDto(procedure);
    }

    public CarWashProcedureDto Get(int dtoId)
    {
        return MapToDto(_procedureRepository.Read(dtoId));
    }

    public List<CarWashProcedureDto> GetAll()
    {
        return _procedureRepository.ReadAll()
            .Select(MapToDto)
            .ToList();
    }

    public CarWashProcedureDto Update(
        CarWashProcedureCreateUpdateDto dto,
        int dtoId)
    {
        CarWashProcedure oldProcedure = _procedureRepository.Read(dtoId);

        var procedure = new CarWashProcedure
        {
            Id = dtoId,
            Name = dto.Name,
            CarCategory = dto.CarCategory,
            Price = dto.Price,
            Duration = dto.Duration,
            Orders = oldProcedure.Orders
        };

        _procedureRepository.Update(procedure);

        return MapToDto(procedure);
    }

    public void Delete(int dtoId)
    {
        _procedureRepository.Delete(dtoId);
    }

    private static CarWashProcedureDto MapToDto(
        CarWashProcedure procedure)
    {
        return new CarWashProcedureDto(
            procedure.Id,
            procedure.Name,
            procedure.CarCategory,
            procedure.Price,
            procedure.Duration);
    }
}
