
using CarWash.Application.Contracts;
using CarWash.Domain.Data;

namespace CarWash.Application.Services;

/// <summary>
/// Аналитическая служба автомойки
/// </summary>
public class AnalyticsService(CarWashData data) : IAnalyticsService
{
    /// <inheritdoc/>
    public List<KeyValuePair<int, int>> GetTopFiveCustomersByVisitCount()
    {
        return data.Orders
            .GroupBy(order => order.Car.CustomerId)
            .Select(group => new KeyValuePair<int, int>(
                group.Key,
                group.Count()))
            .OrderByDescending(item => item.Value)
            .ThenBy(item => item.Key)
            .Take(5)
            .ToList();
    }

    /// <inheritdoc/>
    public List<int> GetCarsCurrentlyAtCarWash()
    {
        DateTime now = data.Now;

        return data.Orders
            .Where(order =>
                order.StartTime <= now &&
                now < order.StartTime.Add(order.Procedure.Duration))
            .Select(order => order.CarId)
            .ToList();
    }

    /// <inheritdoc/>
    public List<int> GetTopPopularProcedures()
    {
        return data.Orders
            .GroupBy(order => order.ProcedureId)
            .Select(group => new
            {
                ProcedureId = group.Key,
                OrderCount = group.Count()
            })
            .OrderByDescending(item => item.OrderCount)
            .ThenBy(item => item.ProcedureId)
            .Take(5)
            .Select(item => item.ProcedureId)
            .ToList();
    }

    /// <inheritdoc/>
    public DateTime GetWashBoxReleaseTime(int washBoxNumber)
    {
        return data.Orders
            .Where(order => order.WashBoxNumber == washBoxNumber)
            .Select(order =>
                order.StartTime.Add(order.Procedure.Duration))
            .Max();
    }

    /// <inheritdoc/>
    public decimal CalculateProcedureRevenue(int procedureId)
    {
        return data.Orders
            .Where(order => order.ProcedureId == procedureId)
            .Sum(order => order.Procedure.Price);
    }
}
