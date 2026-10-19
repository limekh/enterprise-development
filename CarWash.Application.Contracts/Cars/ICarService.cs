using CarWash.Application.Contracts;

namespace CarWash.Application.Contracts.Cars;

/// <summary>
/// Наследник службы аппликейшена для работы с авто
/// </summary>
public interface ICarService
    : IApplicationService<CarDto, CarCreateUpdateDto, int>
{
}