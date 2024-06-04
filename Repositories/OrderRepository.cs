
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private Shop214928673Context _shop;

        public OrderRepository(Shop214928673Context shop)
        {
            _shop = shop;
        }

        public async Task<Order> createOrder(Order order)
        {
            await _shop.Orders.AddAsync(order);
            await _shop.SaveChangesAsync();
            return order;
        }











    }
}

