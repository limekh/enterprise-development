namespace CarWash.Domain.Entities;

using CarWash.Domain.Enums;

public class Service
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public CarCategory CarCategory { get; set; }

    public decimal Price { get; set; }

    public int DurationMinutes { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}