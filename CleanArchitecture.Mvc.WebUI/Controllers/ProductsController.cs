using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.Mvc.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _producsService;
        public ProductsController(IProductService productService)
        {
            _producsService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _producsService.GetProducts());
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }
    }
}
