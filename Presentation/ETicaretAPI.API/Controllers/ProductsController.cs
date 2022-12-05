using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productServiceRead;
        private readonly IProductWriteRepository _productServiceWrite;


        private readonly IOrderReadRepository _orderServiceRead;
        private readonly IOrderWriteRepository _orderServiceWrite;

        private readonly ICustomerWriteRepository _customerWriteRepository;


        public ProductsController(IProductReadRepository productServiceRead,
                                  IProductWriteRepository productServiceWrite,
                                  IOrderReadRepository orderServiceRead,
                                  IOrderWriteRepository orderServiceWrite,
                                  ICustomerWriteRepository customerWriteRepository)
        {
            _productServiceRead = productServiceRead;
            _productServiceWrite = productServiceWrite;
            _orderServiceRead = orderServiceRead;
            _orderServiceWrite = orderServiceWrite;
            _customerWriteRepository = customerWriteRepository;
        }



        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var customerId = Guid.NewGuid();
            await _customerWriteRepository.AddAsync(new() { Id = customerId, Name ="Tom" });
            await _orderServiceWrite.AddAsync(new() { Description = "CJZ", Address= "TEst",CustomerId = customerId });
            await _orderServiceWrite.SaveAsync();
            return Ok(_orderServiceWrite.Table);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Order order = await _orderServiceRead.GetByIdAsync("2");
            order.Address = "Sumg";
            await _orderServiceWrite.SaveAsync();
            return Ok(order);

        
        }

    }
}

