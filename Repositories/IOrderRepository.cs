﻿

using Entities;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<Order> createOrder(Order order);
    }
}