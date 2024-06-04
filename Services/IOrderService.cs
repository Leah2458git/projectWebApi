using Entities;
using Repositories;

namespace Services
{
    public interface IOrderService
    {
        Task<Order> createOrder(Order order);
    }
}