namespace CarWash.Domain.Entities;

public class Client
{
    public indexer Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Phone {  get; set; } = string.Empty;

    public ICollection<Car> Cars { get; set; } = new List<Car>();

    public ICollection Orders { get; set; } = new List<Order>();
}