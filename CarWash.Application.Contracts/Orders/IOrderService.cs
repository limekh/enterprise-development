using CarWash.Application.Contracts;

namespace CarWash.Application.Contracts.Orders;

/// <summary>
/// Наследник службы аппликейшена для работы с заказами
/// </summary>
public interface IOrderService
    : IApplicationService<OrderDto, OrderCreateUpdateDto, int>
{
}