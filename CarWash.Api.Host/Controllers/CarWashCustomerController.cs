using CarWash.Application.Contracts.Customers;

namespace CarWash.Api.Host.Controllers;

/// <summary>
/// Контроллер CRUD-операций над клиентами автомойки
/// </summary>
public class CarWashCustomerController(
    ICarWashCustomerService crudService,
    ILogger<CarWashCustomerController> logger)
    : CrudControllerBase<
        CarWashCustomerDto,
        CarWashCustomerCreateUpdateDto,
        int>(crudService, logger);