namespace CarWash.Domain.Entities;

public class Order
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public Client Client { get; set; } = null!;

    public int CarId { get; set; }

    public Car Car { get; set; } = null!;

    public int ServiceId { get; set; }

    public Service Service { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public int WashBoxNumber { get; set; }
}