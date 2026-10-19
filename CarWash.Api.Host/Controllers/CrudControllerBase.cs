using CarWash.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CarWash.Api.Host.Controllers;

/// <summary>
/// Базовый контроллер для CRUD-операций над сущностями
/// </summary>
[Route("api/[controller]")]
[ApiController]
public abstract class CrudControllerBase<TDto, TCreateUpdateDto, TKey>(
    IApplicationService<TDto, TCreateUpdateDto, TKey> appService,
    ILogger<CrudControllerBase<TDto, TCreateUpdateDto, TKey>> logger)
    : ControllerBase
    where TDto : class
    where TCreateUpdateDto : class
    where TKey : struct
{
    /// <summary>
    /// Добавление новой записи
    /// </summary>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(500)]
    public ActionResult<TDto> Create(TCreateUpdateDto newDto)
    {
        logger.LogInformation(
            "{method} method of {controller} is called with {@dto} parameter",
            nameof(Create), GetType().Name, newDto);

        try
        {
            var result = appService.Create(newDto);

            logger.LogInformation(
                "{method} method of {controller} executed successfully",
                nameof(Create), GetType().Name);

            return CreatedAtAction(nameof(Get), new { id = GetId(result) }, result);
        }
        catch (Exception ex)
        {
            logger.LogError(
                "An exception happened during {method} method of {controller}: {@exception}",
                nameof(Create), GetType().Name, ex);

            return StatusCode(500, "An internal server error occurred.");
        }
    }

    /// <summary>
    /// Изменение имеющихся данных
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public ActionResult<TDto> Edit(TKey id, TCreateUpdateDto newDto)
    {
        logger.LogInformation(
            "{method} method of {controller} is called with {key},{@dto} parameters",
            nameof(Edit), GetType().Name, id, newDto);

        try
        {
            var result = appService.Update(newDto, id);

            logger.LogInformation(
                "{method} method of {controller} executed successfully",
                nameof(Edit), GetType().Name);

            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(
                "An exception happened during {method} method of {controller}: {@exception}",
                nameof(Edit), GetType().Name, ex);

            return StatusCode(500, "An internal server error occurred.");
        }
    }

    /// <summary>
    /// Удаление данных
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public IActionResult Delete(TKey id)
    {
        logger.LogInformation(
            "{method} method of {controller} is called with {id} parameter",
            nameof(Delete), GetType().Name, id);

        try
        {
            appService.Delete(id);

            logger.LogInformation(
                "{method} method of {controller} executed successfully",
                nameof(Delete), GetType().Name);

            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(
                "An exception happened during {method} method of {controller}: {@exception}",
                nameof(Delete), GetType().Name, ex);

            return StatusCode(500, "An internal server error occurred.");
        }
    }

    /// <summary>
    /// Получение списка всех данных
    /// </summary>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public ActionResult<IList<TDto>> GetAll()
    {
        logger.LogInformation(
            "{method} method of {controller} is called",
            nameof(GetAll), GetType().Name);

        try
        {
            var result = appService.GetAll();

            logger.LogInformation(
                "{method} method of {controller} executed successfully",
                nameof(GetAll), GetType().Name);

            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(
                "An exception happened during {method} method of {controller}: {@exception}",
                nameof(GetAll), GetType().Name, ex);

            return StatusCode(500, "An internal server error occurred.");
        }
    }

    /// <summary>
    /// Получение данных по идентификатору
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public ActionResult<TDto> Get(TKey id)
    {
        logger.LogInformation(
            "{method} method of {controller} is called with {id} parameter",
            nameof(Get), GetType().Name, id);

        try
        {
            var result = appService.Get(id);

            logger.LogInformation(
                "{method} method of {controller} executed successfully",
                nameof(Get), GetType().Name);

            return result != null ? Ok(result) : NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(
                "An exception happened during {method} method of {controller}: {@exception}",
                nameof(Get), GetType().Name, ex);

            return StatusCode(500, "An internal server error occurred.");
        }
    }

    private static object? GetId(TDto dto)
    {
        var property = typeof(TDto).GetProperty("Id");
        return property?.GetValue(dto);
    }
}
