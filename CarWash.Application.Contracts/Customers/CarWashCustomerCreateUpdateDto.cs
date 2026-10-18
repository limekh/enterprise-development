namespace CarWash.Application.Contracts.Customers;

/// <summary>
/// DTO для POST/PUT запросов к клиентам
/// </summary>
public record CarWashCustomerCreateUpdateDto(
    string LastName,
    string FirstName,
    string? Patronymic,
    string Phone);