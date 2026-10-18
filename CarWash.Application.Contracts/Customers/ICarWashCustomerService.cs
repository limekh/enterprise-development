using CarWash.Application.Contracts;

namespace CarWash.Application.Contracts.Customers;

/// <summary>
/// Наследник службы аппликейшена для работы с клиентами
/// </summary>
public interface ICarWashCustomerService
    : IApplicationService<CarWashCustomerDto, CarWashCustomerCreateUpdateDto, int>
{
}
