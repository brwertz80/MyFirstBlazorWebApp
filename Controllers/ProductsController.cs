using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myWebApp.Models;
using myWebApp.Services;

namespace myWebApp.Controllers
{
    // Removed the 'api/' from the Route (https://youtu.be/VI40Y3kFcNc?t=257)
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return this.ProductService.GetProducts();
        }

        // Added in ASP.NET Core 101[9 of 13] (https://youtu.be/oPKq9fNJ6c0?t=625)
        // [HttpPatch] "[FromBody]"
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get(
            [FromQuery] string ProductId, 
            [FromQuery] int Rating)
        {
            ProductService.AddRating(ProductId, Rating);
            return Ok();
        }
    }
}