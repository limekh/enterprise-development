namespace CarWash.Domain.Entities;

/// <summary>
/// Автомобиль клиента.
/// </summary>
public class Car
{
    /// <summary>
    /// Уникальный идентификатор автомобиля.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Государственный регистрационный номер автомобиля.
    /// </summary>
    public required string LicensePlate { get; set; }

    /// <summary>
    /// Марка автомобиля.
    /// </summary>
    public required string Brand { get; set; }

    /// <summary>
    /// Идентификатор владельца автомобиля.
    /// </summary>
    public int ClientId { get; set; }

    /// <summary>
    /// Владелец автомобиля.
    /// </summary>
    public required Client Client { get; set; }

    /// <summary>
    /// Заказы на обслуживание автомобиля.
    /// </summary>
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}