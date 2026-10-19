namespace CarWash.Application.Contracts.Orders;

/// <summary>
/// DTO для POST/PUT запросов к заказам
/// </summary>
public record OrderCreateUpdateDto(
    int CarId,
    int ProcedureId,
    DateTime StartTime,
    int WashBoxNumber);