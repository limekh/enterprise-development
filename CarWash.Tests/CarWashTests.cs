using CarWash.Domain.Data;

namespace CarWash.Tests;

public class CarWashTests(CarWashData data) : IClassFixture<CarWashData>
{
    private readonly CarWashData _data = data;

    /// <summary>
    /// 1. Получить топ 5 клиентов по количеству посещений автомойки
    /// </summary>
    [Fact]
    public void GetTopFiveClientsByVisitCount()
    {
        // Arrange
        var orders = _data.Orders;

        var expectedClientIds = new[]
        {
            1, 2, 5, 3, 4  
        };

        // Act
        var actualClientIds = orders
            .GroupBy(order => order.Car.ClientId)
            .Select(group => new
            {
                ClientId = group.Key,
                VisitCount = group.Count()
            })
            .OrderByDescending(x => x.VisitCount)
            .ThenBy(x => x.ClientId)
            .Take(5)
            .Select(x => x.ClientId)
            .ToArray();

        // Assert
        Assert.Equal(expectedClientIds, actualClientIds);
    }

    /// <summary>
    /// 2. Получить автомобили, находящиеся на мойке в данный момент
    /// </summary>
    [Fact]
    public void GetCarsCurrentlyAtCarWash()
    {
        // Arrange
        var orders = _data.Orders;
        var now = _data.Now;

        var expectedCarIds = new[]
        {
            2, 3, 7
        };

        // Act
        var actualCarIds = orders
            .Where(order =>
                order.StartTime <= now &&
                now < order.StartTime.Add(order.Service.Duration))
            .Select(order => order.CarId)
            .ToArray();

        // Assert
        Assert.Equal(expectedCarIds.Length, actualCarIds.Length);

        foreach (var expectedCarId in expectedCarIds)
        {
            Assert.Contains(expectedCarId, actualCarIds);
        }
    }

    /// <summary>
    /// 3. Получить топ 5 наиболее популярных услуг автомойки
    /// </summary>
    [Fact]
    public void GetTopPopularServices()
    {
        // Arrange
        var orders = _data.Orders;

        var expectedServiceIds = new[]
        {
            1, 2, 3, 10, 8
        };

        // Act
        var actualServiceIds = orders
            .GroupBy(order => order.ServiceId)
            .Select(group => new
            {
                ServiceId = group.Key,
                OrderCount = group.Count()
            })
            .OrderByDescending(x => x.OrderCount)
            .ThenBy(x => x.ServiceId)
            .Take(5)
            .Select(x => x.ServiceId)
            .ToArray();

        // Assert
        Assert.Equal(expectedServiceIds, actualServiceIds);
    }

    /// <summary>
    /// 4. Получить время освобождения выбранного бокса
    /// </summary>
    [Fact]
    public void GetWashBoxReleaseTime()
    {
        // Arrange
        var orders = _data.Orders;
        var washBoxNumber = 4;

        var expectedReleaseTime = new DateTime(2026, 9, 17, 12, 20, 0);

        // Act
        var actualReleaseTime = orders
            .Where(order => order.WashBoxNumber == washBoxNumber)
            .Select(order =>
                order.StartTime.Add(order.Service.Duration))
            .Max();

        // Assert
        Assert.Equal(expectedReleaseTime, actualReleaseTime);
    }

    /// <summary>
    /// 5. Получить суммарную выручку по каждой услуге.
    /// </summary>
    [Theory]
    [InlineData(1, 12000)]
    [InlineData(2, 4800)]
    [InlineData(3, 4000)]
    [InlineData(5, 6000)]
    public void CalculateServiceRevenue(
        int serviceId,
        decimal expectedRevenue)
    {
        // Arrange
        var orders = _data.Orders;

        // Act
        var actualRevenue = orders
            .Where(order => order.ServiceId == serviceId)
            .Sum(order => order.Service.Price);

        // Assert
        Assert.Equal(expectedRevenue, actualRevenue);
    }
}