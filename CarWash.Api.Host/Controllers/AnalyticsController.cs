using CarWash.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CarWash.Api.Host.Controllers;

/// <summary>
/// Контроллер аналитических запросов автомойки
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController(
    IAnalyticsService service,
    ILogger<AnalyticsController> logger) : ControllerBase
{
    /// <summary>
    /// Получает топ 5 клиентов по количеству посещений автомойки
    /// </summary>
    [HttpGet("top5-customers")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public ActionResult<List<KeyValuePair<int, int>>>
        GetTopFiveCustomersByVisitCount()
    {
        logger.LogInformation(
            "{method} method of {controller} is called",
            nameof(GetTopFiveCustomersByVisitCount), GetType().Name);

        try
        {
            var result = service.GetTopFiveCustomersByVisitCount();

            logger.LogInformation(
                "{method} method of {controller} executed successfully",
                nameof(GetTopFiveCustomersByVisitCount), GetType().Name);

            return result.Count > 0 ? Ok(result) : NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(
                "An exception happened during {method} method of {controller}: {@exception}",
                nameof(GetTopFiveCustomersByVisitCount), GetType().Name, ex);

            return StatusCode(
                500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Получает автомобили, находящиеся на мойке в данный момент
    /// </summary>
    [HttpGet("cars-at-wash")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public ActionResult<List<int>> GetCarsCurrentlyAtCarWash()
    {
        logger.LogInformation(
            "{method} method of {controller} is called",
            nameof(GetCarsCurrentlyAtCarWash), GetType().Name);

        try
        {
            var result = service.GetCarsCurrentlyAtCarWash();

            logger.LogInformation(
                "{method} method of {controller} executed successfully",
                nameof(GetCarsCurrentlyAtCarWash), GetType().Name);

            return result.Count > 0 ? Ok(result) : NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(
                "An exception happened during {method} method of {controller}: {@exception}",
                nameof(GetCarsCurrentlyAtCarWash), GetType().Name, ex);

            return StatusCode(
                500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Получает топ 5 наиболее популярных процедур автомойки
    /// </summary>
    [HttpGet("top5-procedures")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public ActionResult<List<int>> GetTopPopularProcedures()
    {
        logger.LogInformation(
            "{method} method of {controller} is called",
            nameof(GetTopPopularProcedures), GetType().Name);

        try
        {
            var result = service.GetTopPopularProcedures();

            logger.LogInformation(
                "{method} method of {controller} executed successfully",
                nameof(GetTopPopularProcedures), GetType().Name);

            return result.Count > 0 ? Ok(result) : NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(
                "An exception happened during {method} method of {controller}: {@exception}",
                nameof(GetTopPopularProcedures), GetType().Name, ex);

            return StatusCode(
                500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Получает время освобождения выбранного моечного бокса
    /// </summary>
    [HttpGet("wash-box-release-time")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public ActionResult<DateTime> GetWashBoxReleaseTime(
        [FromQuery] int washBoxNumber)
    {
        logger.LogInformation(
            "{method} method of {controller} is called with {washBoxNumber} parameter",
            nameof(GetWashBoxReleaseTime), GetType().Name, washBoxNumber);

        try
        {
            var result = service.GetWashBoxReleaseTime(washBoxNumber);

            logger.LogInformation(
                "{method} method of {controller} executed successfully",
                nameof(GetWashBoxReleaseTime), GetType().Name);

            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(
                "An exception happened during {method} method of {controller}: {@exception}",
                nameof(GetWashBoxReleaseTime), GetType().Name, ex);

            return StatusCode(
                500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Рассчитывает суммарную выручку по выбранной процедуре
    /// </summary>
    [HttpGet("procedure-revenue")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public ActionResult<decimal> CalculateProcedureRevenue(
        [FromQuery] int procedureId)
    {
        logger.LogInformation(
            "{method} method of {controller} is called with {procedureId} parameter",
            nameof(CalculateProcedureRevenue), GetType().Name, procedureId);

        try
        {
            var result = service.CalculateProcedureRevenue(procedureId);

            logger.LogInformation(
                "{method} method of {controller} executed successfully",
                nameof(CalculateProcedureRevenue), GetType().Name);

            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(
                "An exception happened during {method} method of {controller}: {@exception}",
                nameof(CalculateProcedureRevenue), GetType().Name, ex);

            return StatusCode(
                500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }
}
