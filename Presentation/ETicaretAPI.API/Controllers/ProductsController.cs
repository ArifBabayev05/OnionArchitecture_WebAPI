using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories;
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


        public ProductsController(IProductReadRepository productServiceRead, IProductWriteRepository productServiceWrite)
        {
            _productServiceRead = productServiceRead;
            _productServiceWrite = productServiceWrite;
        }
        
        

        [HttpGet]
        public async void GetProducts()
        {
            await _productServiceWrite.AddRangeAsync(new()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 1",
                    Price = 300,
                    CreatedDate = DateTime.UtcNow,
                    Stock = 10
                }
            });
            await _productServiceWrite.SaveAsync();
            
        }
        

    }
}

