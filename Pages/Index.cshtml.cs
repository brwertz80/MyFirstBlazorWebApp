using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MyFirstBlazorWebApp.Models;
using MyFirstBlazorWebApp.Services;

namespace MyFirstBlazorWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        //Added in ASP.NET Core 101 [5 of 13] (https://youtu.be/aP02__gMLtw?t=389)
        public JsonFileProductService ProductService;
        //Added in ASP.NET Core 101 [5 of 13] (https://youtu.be/aP02__gMLtw?t=421)
        public IEnumerable<Product> Products { get; private set; }

        //Added in ASP.NET Core 101 [5 of 13] (https://youtu.be/aP02__gMLtw?t=281)
        public IndexModel(
            ILogger<IndexModel> logger, 
            JsonFileProductService productService)
        {
            _logger = logger;
            //Added in ASP.NET Core 101 [5 of 13] (https://youtu.be/aP02__gMLtw?t=667)
            ProductService = productService;
        }

        public void OnGet()
        {
            //Added in ASP.NET Core 101 [5 of 13] (https://youtu.be/aP02__gMLtw?t=492)
            Products = ProductService.GetProducts();
        }
    }
}
