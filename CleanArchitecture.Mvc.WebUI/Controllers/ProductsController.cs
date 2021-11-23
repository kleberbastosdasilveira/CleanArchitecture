using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CleanArchitecture.Mvc.WebUI.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductService _producsService;
        public ProductsController(IProductService productService, INotificador notificador) : base(notificador)
        {
            _producsService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _producsService.GetProducts());
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            return View(await _producsService.GetProductsCategory(new ProductDTO()));
        }

        [HttpPost()]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {

            if (!ModelState.IsValid)
            {
                productDTO = await _producsService.GetProductsCategory(new ProductDTO());
                return View(productDTO);
            }

            var imgPrefixo = Guid.NewGuid() + "_";
            if (!await _producsService.UploadArquivo(productDTO.ImagemUpload, imgPrefixo))
            {
                productDTO = await _producsService.GetProductsCategory(new ProductDTO());
                return View(productDTO);
            }

            productDTO.Image = imgPrefixo + productDTO.ImagemUpload.FileName;
            await _producsService.Add(productDTO);

            if (!OPeracaoValida()) return View(productDTO);

            TempData["Sucesso"] = "Produto cadastrado com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var productDTO = await _producsService.GetProductCategory(id);
            if (productDTO == null) return View(id);
            return View(productDTO);
        }
    }
}
