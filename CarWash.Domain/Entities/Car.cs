namespace CarWash.Domain.Entities;

public class Car
{
    public int Id { get; set; }

    public string LicensePlate { get; set; } = string.Empty;

    public string Brand {  get; set; } = string.Empty;

    public int ClientId { get; set; }

    public Client Client { get; set; } = null!;

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}