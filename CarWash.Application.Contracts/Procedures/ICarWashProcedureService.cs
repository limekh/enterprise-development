using CarWash.Application.Contracts;

namespace CarWash.Application.Contracts.Procedures;

/// <summary>
/// Наследник службы аппликейшена для работы с услугами автомойки
/// </summary>
public interface ICarWashProcedureService
    : IApplicationService<
        CarWashProcedureDto,
        CarWashProcedureCreateUpdateDto,
        int>
{
}