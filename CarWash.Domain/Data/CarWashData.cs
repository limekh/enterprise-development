using CarWash.Domain.Entities;
using CarWash.Domain.Shared.Enums;

namespace CarWash.Domain.Data;

/// <summary>
/// Тестовые данные автомойки
/// </summary>
public class CarWashData
{
    /// <summary>
    /// Текущее время для тестовых данных
    /// </summary>
    public DateTime Now { get; } = new(2026, 9, 17, 12, 0, 0);

    /// <summary>
    /// Клиенты автомойки
    /// </summary>
    public List<Client> Clients { get; } = [];

    /// <summary>
    /// Автомобили клиентов
    /// </summary>
    public List<Car> Cars { get; } = [];

    /// <summary>
    /// Услуги автомойки
    /// </summary>
    public List<Service> Services { get; } = [];

    /// <summary>
    /// Заказы автомойки
    /// </summary>
    public List<Order> Orders { get; } = [];

    public CarWashData()
    {
        Clients.AddRange(
            [
                new Client
                {
                    Id = 1,
                    LastName = "Сопранов",
                    FirstName = "Антон",
                    Patronymic = null,
                    Phone = "+79010000001"
                },

                new Client
                {
                    Id = 2,
                    LastName = "Ошпаренный",
                    FirstName = "Дмитрий",
                    Patronymic = "Алексеевич",
                    Phone = "+79020000002"
                },

                new Client
                {
                    Id = 3,
                    LastName = "Папс",
                    FirstName = "Боб",
                    Patronymic = null,
                    Phone = "+79030000003"
                },

                new Client
                {
                    Id = 4,
                    LastName = "Быков",
                    FirstName = "Андрей",
                    Patronymic = "Евгеньевич",
                    Phone = "+79040000004"
                },

                new Client
                {
                    Id = 5,
                    LastName = "Бобков",
                    FirstName = "Геннадий",
                    Patronymic = "Андреевич",
                    Phone = "+79040000066",
                },

                new Client
                {
                    Id = 6,
                    LastName = "Афанасьев",
                    FirstName = "Федор",
                    Patronymic = "Иванович",
                    Phone = "+79060000006"
                },

                new Client
                {
                    Id = 7,
                    LastName = "Васильев",
                    FirstName = "Максим",
                    Patronymic = "Максимович",
                    Phone = "+79990000007"
                },

                new Client
                {
                    Id = 8,
                    LastName = "Новиков",
                    FirstName = "Николай",
                    Patronymic = null,
                    Phone = "+79990000008"
                },

                new Client
                {
                    Id = 9,
                    LastName = "Фёдоров",
                    FirstName = "Роман",
                    Patronymic = "Романович",
                    Phone = "+79990000009"
                },

                new Client
                {
                    Id = 10,
                    LastName = "Морозов",
                    FirstName = "Михаил",
                    Patronymic = "Михайлович",
                    Phone = "+79990000010"
                },

                new Client
                {
                    Id = 11,
                    LastName = "Лоренцо",
                    FirstName = "Анелло",
                    Patronymic = null,
                    Phone = "+79990000011"
                },

                new Client
                {
                    Id = 12,
                    LastName = "Алексеев",
                    FirstName = "Виктор",
                    Patronymic = "Викторович",
                    Phone = "+79990000012"
                }
            ]);

        Cars.AddRange(
            [
                new Car { Id = 1, LicensePlate = "А111АА", Brand = "Chevrolet", ClientId = 1, Client = Clients.Single(client => client.Id == 1) },

                new Car { Id = 2, LicensePlate = "А222АА", Brand = "Cadillac", ClientId = 1, Client = Clients.Single(client => client.Id == 1) },

                new Car { Id = 3, LicensePlate = "О248ВН", Brand = "BMW", ClientId = 2, Client = Clients.Single(client => client.Id == 2) },

                new Car { Id = 4, LicensePlate = "О249ВН", Brand = "BMW", ClientId = 2, Client = Clients.Single(client => client.Id == 2) },

                new Car { Id = 5, LicensePlate = "С555СС", Brand = "Harley-Davidson", ClientId = 3, Client = Clients.Single(client => client.Id == 3) },

                new Car { Id = 6, LicensePlate = "Е666ЕЕ", Brand = "Honda", ClientId = 4, Client = Clients.Single(client => client.Id == 4) },

                new Car { Id = 7, LicensePlate = "К777КК", Brand = "Lada", ClientId = 5, Client = Clients.Single(client => client.Id == 5) },

                new Car { Id = 8, LicensePlate = "М571АК", Brand = "KamAZ", ClientId = 6, Client = Clients.Single(client => client.Id == 6) },

                new Car { Id = 9, LicensePlate = "Н101НН", Brand = "Skoda", ClientId = 7, Client = Clients.Single(client => client.Id == 7) },

                new Car { Id = 10, LicensePlate = "О202ОО", Brand = "Volvo", ClientId = 8, Client = Clients.Single(client => client.Id == 8) },

                new Car { Id = 11, LicensePlate = "Р303РР", Brand = "Nissan", ClientId = 9, Client = Clients.Single(client => client.Id == 9) },

                new Car { Id = 12, LicensePlate = "Т404ТТ", Brand = "Mazda", ClientId = 10, Client = Clients.Single(client => client.Id == 10) },

                new Car { Id = 13, LicensePlate = "Т505ТТ", Brand = "Lexus", ClientId = 10, Client = Clients.Single(client => client.Id == 10) },

                new Car { Id = 14, LicensePlate = "У606УУ", Brand = "GMC", ClientId = 11, Client = Clients.Single(client => client.Id == 11) },

                new Car { Id = 15, LicensePlate = "Х707ХХ", Brand = "Peugeot", ClientId = 12, Client = Clients.Single(client => client.Id == 12) }
            ]);

        Services.AddRange(
            [
                new Service
                {
                    Id = 1,
                    Name = "Комплексная мойка",
                    CarCategory = CarCategory.Passenger,
                    Price = 1500m,
                    DurationMinutes = 60
                },

                new Service
                {
                    Id = 2,
                    Name = "Мойка кузова",
                    CarCategory = CarCategory.Passenger,
                    Price = 800m,
                    DurationMinutes = 30
                },

                new Service
                {
                    Id = 3,
                    Name = "Мойка салона",
                    CarCategory = CarCategory.Passenger,
                    Price = 1000m,
                    DurationMinutes = 45
                },

                new Service
                {
                    Id = 4,
                    Name = "Мойка двигателя",
                    CarCategory = CarCategory.Passenger,
                    Price = 1200m,
                    DurationMinutes = 40
                },

                new Service
                {
                    Id = 5,
                    Name = "Полировка кузова",
                    CarCategory = CarCategory.Passenger,
                    Price = 3000m,
                    DurationMinutes = 120
                },

                new Service
                {
                    Id = 6,
                    Name = "Мойка внедорожника",
                    CarCategory = CarCategory.SUV,
                    Price = 2000m,
                    DurationMinutes = 75
                },

                new Service
                {
                    Id = 7,
                    Name = "Мойка микроавтобуса",
                    CarCategory = CarCategory.Minibus,
                    Price = 2500m,
                    DurationMinutes = 90
                },

                new Service
                {
                    Id = 8,
                    Name = "Мойка грузового автомобиля",
                    CarCategory = CarCategory.Truck,
                    Price = 4000m,
                    DurationMinutes = 120
                },

                new Service
                {
                    Id = 9,
                    Name = "Мойка автобуса",
                    CarCategory = CarCategory.Bus,
                    Price = 5000m,
                    DurationMinutes = 150
                },

                new Service
                {
                    Id = 10,
                    Name = "Мойка мотоцикла",
                    CarCategory = CarCategory.Motorcycle,
                    Price = 700m,
                    DurationMinutes = 30
                }
            ]);

        Orders.AddRange(
            [
                CreateOrder(1, 1, 1, 1, new(2026, 9, 10, 9, 0, 0), 1),

                CreateOrder(2, 1, 2, 2, new(2026, 9, 11, 10, 0, 0), 2),

                CreateOrder(3, 1, 1, 1, new(2026, 9, 12, 11, 0, 0), 1),

                CreateOrder(4, 1, 2, 3, new(2026, 9, 13, 12, 0, 0), 2),

                CreateOrder(26, 1, 2, 3, new(2026, 9, 17, 11, 30, 0), 2),

                CreateOrder(5, 2, 3, 1, new(2026, 9, 10, 10, 0, 0), 2),

                CreateOrder(6, 2, 4, 2, new(2026, 9, 11, 11, 0, 0), 3),

                CreateOrder(7, 2, 4, 1, new(2026, 9, 13, 13, 0, 0), 1),

                CreateOrder(27, 2, 3, 1, new(2026, 9, 17, 11, 30, 0), 3),

                CreateOrder(8, 3, 5, 10, new(2026, 9, 10, 12, 0, 0), 3),

                CreateOrder(9, 3, 5, 10, new(2026, 9, 11, 13, 0, 0), 4),

                CreateOrder(10, 4, 6, 10, new(2026, 9, 10, 13, 0, 0), 4),

                CreateOrder(11, 4, 6, 10, new(2026, 9, 11, 14, 0, 0), 1),

                CreateOrder(12, 5, 7, 1, new(2026, 9, 10, 14, 0, 0), 1),

                CreateOrder(13, 5, 7, 2, new(2026, 9, 11, 15, 0, 0), 2),

                CreateOrder(14, 5, 7, 1, new(2026, 9, 15, 11, 0, 0), 4),

                CreateOrder(28, 5, 7, 2, new(2026, 9, 17, 11, 50, 0), 4),

                CreateOrder(15, 6, 8, 8, new(2026, 9, 10, 15, 0, 0), 4),

                CreateOrder(16, 7, 9, 2, new(2026, 9, 10, 16, 0, 0), 2),

                CreateOrder(17, 7, 9, 3, new(2026, 9, 11, 16, 0, 0), 3),

                CreateOrder(18, 8, 10, 3, new(2026, 9, 11, 17, 0, 0), 3),

                CreateOrder(19, 9, 11, 4, new(2026, 9, 12, 10, 0, 0), 1),

                CreateOrder(20, 9, 11, 5, new(2026, 9, 15, 10, 0, 0), 2),

                CreateOrder(21, 10, 12, 5, new(2026, 9, 12, 11, 0, 0), 2),

                CreateOrder(22, 10, 13, 1, new(2026, 9, 15, 10, 0, 0), 3),

                CreateOrder(23, 11, 14, 8, new(2026, 9, 13, 11, 0, 0), 4),

                CreateOrder(24, 11, 14, 1, new(2026, 9, 16, 14, 0, 0), 2),

                CreateOrder(25, 12, 15, 2, new(2026, 9, 15, 12, 0, 0), 3),
            ]);

        foreach (var client in Clients)
        {
            client.Cars = Cars
                .Where(car => car.ClientId == client.Id)
                .ToList();

            client.Orders = Orders
                .Where(order => order.ClientId == client.Id)
                .ToList();
        }

        foreach (var car in Cars)
        {
            car.Orders = Orders
                .Where(order => order.CarId == car.Id)
                .ToList();
        }

        foreach (var service in Services)
        {
            service.Orders = Orders
                .Where(order => order.ServiceId == service.Id)
                .ToList();
        }
    }

    private Order CreateOrder(
        int id,
        int clientId,
        int carId,
        int serviceId,
        DateTime startTime,
        int washBoxNumber) =>
        new()
        {
            Id = id,
            ClientId = clientId,
            Client = Clients.Single(client => client.Id == clientId),
            CarId = carId,
            Car = Cars.Single(car => car.Id == carId),
            ServiceId = serviceId,
            Service = Services.Single(service => service.Id == serviceId),
            StartTime = startTime,
            WashBoxNumber = washBoxNumber
        };
}
