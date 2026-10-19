using CarWash.Application.Contracts.Procedures;

namespace CarWash.Api.Host.Controllers;

/// <summary>
/// Контроллер CRUD-операций над услугами автомойки
/// </summary>
public class CarWashProcedureController(
    ICarWashProcedureService crudService,
    ILogger<CarWashProcedureController> logger)
    : CrudControllerBase<
        CarWashProcedureDto,
        CarWashProcedureCreateUpdateDto,
        int>(crudService, logger);