
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using Repositories;
using AutoMapper;
using DTOs;
using Entities;

namespace projectWebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private IOrderService _categoryService;
        private IMapper _mapper;


        public OrderController(IOrderService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> createOrder([FromBody] OrderDTO order)
        {
            Order ord = _mapper.Map<OrderDTO, Order>(order);
            Order ord2 = await _categoryService.createOrder(ord);
            OrderDTO orderToReturn = _mapper.Map<Order,OrderDTO >(ord2);
            if (orderToReturn != null)
            {
                return Ok(orderToReturn);
            }
            else
            {
                return NoContent();
            }
        }







    }
}
