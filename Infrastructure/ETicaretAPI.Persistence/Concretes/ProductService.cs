using System;
using ETicaretAPI.Application.Abstraction;
using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Persistence.Concretes
{
    public class ProductService : IProductService
    {

     public List<Product> GetProducts()
         => new()
             {
               new()
                 {
                    Id = Guid.NewGuid(),
                   Name="Product",
                   Price=100,
                   Stock=10
                 },
               new()
                 {
                    Id = Guid.NewGuid(),
                   Name="Product2",
                   Price=1100,
                   Stock=1
                 },
               new()
                 {
                    Id = Guid.NewGuid(),
                   Name="Product3",
                   Price=2100,
                   Stock=14
                 },
               new()
                 {
                    Id = Guid.NewGuid(),
                   Name="Product4",
                   Price=500,
                   Stock=20
                 }
             };
    }
}

