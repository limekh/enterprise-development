namespace CarWash.Domain.Entities;

/// <summary>
/// Клиент автомойки
/// </summary>
public class Client
{
    /// <summary>
    /// Уникальный идентификатор клиента
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Фамилия клиента
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Имя клиента
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Отчество клиента
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// Номер телефона клиента
    /// </summary>
    public required string Phone { get; set; }

    /// <summary>
    /// Автомобили клиента.
    /// </summary>
    public ICollection<Car> Cars { get; set; } = new List<Car>();

    /// <summary>
    /// Заказы клиента.
    /// </summary>
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}