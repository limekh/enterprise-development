using CarWash.Domain.Shared.Enums;

namespace CarWash.Application.Contracts.Procedures;

/// <summary>
/// DTO для POST/PUT запросов к услугам автомойки
/// </summary>
public record CarWashProcedureCreateUpdateDto(
    string Name,
    CarCategory CarCategory,
    decimal Price,
    TimeSpan Duration);