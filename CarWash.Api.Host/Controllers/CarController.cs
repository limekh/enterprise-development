using CarWash.Application.Contracts.Cars;

namespace CarWash.Api.Host.Controllers;

/// <summary>
/// Контроллер CRUD-операций над автомобилями
/// </summary>
public class CarController(
    ICarService crudService,
    ILogger<CarController> logger)
    : CrudControllerBase<CarDto, CarCreateUpdateDto, int>(
        crudService, logger);