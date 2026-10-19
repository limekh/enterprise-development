using CarWash.Domain.Shared.Enums;

namespace CarWash.Application.Contracts.Cars;

/// <summary>
/// DTO для POST/PUT запросов к авто
/// </summary>
public record CarCreateUpdateDto(
    CarCategory CarCategory,
    string LicensePlate,
    string Brand,
    int CustomerId);