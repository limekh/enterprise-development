using CarWash.Domain.Data;

namespace CarWash.Tests;

/// <summary>
/// Юнит тесты для автомойки
/// </summary>
public class CarWashTests(CarWashData data) : IClassFixture<CarWashData>
{
    /// <summary>
    /// 1. Получить топ 5 клиентов по количеству посещений автомойки
    /// </summary>
    [Fact]
    public void GetTopFiveCustomersByVisitCount()
    {
        // Arrange
        var orders = data.Orders;

        var expectedCustomerIds = new[]
        {
            2, 1, 5, 4, 7  
        };

        // Act
        var actualCustomerIds = orders
            .GroupBy(order => order.Car.CustomerId)
            .Select(group => new
            {
                CustomerId = group.Key,
                VisitCount = group.Count()
            })
            .OrderByDescending(x => x.VisitCount)
            .ThenBy(x => x.CustomerId)
            .Take(5)
            .Select(x => x.CustomerId)
            .ToArray();

        // Assert
        Assert.Equal(expectedCustomerIds, actualCustomerIds);
    }

    /// <summary>
    /// 2. Получить автомобили, находящиеся на мойке в данный момент
    /// </summary>
    [Fact]
    public void GetCarsCurrentlyAtCarWash()
    {
        // Arrange
        var orders = data.Orders;
        var now = data.Now;

        var expectedCarIds = new[]
        {
            2, 3, 7
        };

        // Act
        var actualCarIds = orders
            .Where(order =>
                order.StartTime <= now &&
                now < order.StartTime.Add(order.Procedure.Duration))
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
    public void GetTopPopularProcedures()
    {
        // Arrange
        var orders = data.Orders;

        var expectedProcedureIds = new[]
        {
            1, 2, 3, 10, 8
        };

        // Act
        var actualProcedureIds = orders
            .GroupBy(order => order.ProcedureId)
            .Select(group => new
            {
                ProcedureId = group.Key,
                OrderCount = group.Count()
            })
            .OrderByDescending(x => x.OrderCount)
            .ThenBy(x => x.ProcedureId)
            .Take(5)
            .Select(x => x.ProcedureId)
            .ToArray();

        // Assert
        Assert.Equal(expectedProcedureIds, actualProcedureIds);
    }

    /// <summary>
    /// 4. Получить время освобождения выбранного бокса
    /// </summary>
    [Fact]
    public void GetWashBoxReleaseTime()
    {
        // Arrange
        var orders = data.Orders;
        var washBoxNumber = 4;

        var expectedReleaseTime = new DateTime(2026, 9, 17, 12, 20, 0);

        // Act
        var actualReleaseTime = orders
            .Where(order => order.WashBoxNumber == washBoxNumber)
            .Select(order =>
                order.StartTime.Add(order.Procedure.Duration))
            .Max();

        // Assert
        Assert.Equal(expectedReleaseTime, actualReleaseTime);
    }

    /// <summary>
    /// 5. Получить суммарную выручку по каждой услуге
    /// </summary>
    [Theory]
    [InlineData(1, 12000)]
    [InlineData(2, 4800)]
    [InlineData(3, 4000)]
    [InlineData(5, 6000)]
    public void CalculateProcedureRevenue(
        int ProcedureId,
        decimal expectedRevenue)
    {
        // Arrange
        var orders = data.Orders;

        // Act
        var actualRevenue = orders
            .Where(order => order.ProcedureId == ProcedureId)
            .Sum(order => order.Procedure.Price);

        // Assert
        Assert.Equal(expectedRevenue, actualRevenue);
    }
}