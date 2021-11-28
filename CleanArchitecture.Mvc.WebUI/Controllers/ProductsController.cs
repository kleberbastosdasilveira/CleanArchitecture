using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.DTOs.Product.DTO;
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
            if(productDTO.ImagemUpload != null)
            {
                if (!await _producsService.UploadArquivo(productDTO.ImagemUpload))
                {
                    productDTO = await _producsService.GetProductsCategory(new ProductDTO());
                    return View(productDTO);
                }

                productDTO.Image = productDTO.ImagemUpload.FileName;

            }
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
        public async Task<IActionResult> Edit(Guid id)
        {
            var productDTO = await _producsService.GetProductCategoryForEdit(id);
            if (!OPeracaoValida()) return RedirectToAction(nameof(Index));
            return View(productDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ProductEditDTO productEditDTO)
        {
            if (id != productEditDTO.Id)
            {
                productEditDTO = await _producsService.GetProductCategoryForEdit(id);
                return View(productEditDTO);
            }
            if (productEditDTO.ImagemUpload != null) 
            {
                if (!await _producsService.UploadArquivo(productEditDTO.ImagemUpload))
                {
                    productEditDTO = await _producsService.GetProductCategoryForEdit(id);
                    if (!OPeracaoValida()) return View(productEditDTO);
                    return View(productEditDTO);
                }
                productEditDTO.Image = productEditDTO.ImagemUpload.FileName;
            }


            await _producsService.Update(productEditDTO);
            if (!OPeracaoValida()) return View(productEditDTO);
            TempData["Sucesso"] = "Produto editado com sucesso!";
            return RedirectToAction(nameof(Index));

        }

        [HttpGet()]
        public async Task<IActionResult> Delete(Guid id)
        {
            var productDTO = await _producsService.GetProductCategory(id);
            if (productDTO == null) return View(id);
            return View(productDTO);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmacao(Guid id)
        {
            var productDTO = await _producsService.GetById(id);
            await _producsService.Remove(id);
            if (!OPeracaoValida()) return View(productDTO);
            TempData["Sucesso"] = "Produto excluido com sucesso!";
            return RedirectToAction(nameof(Index));
        }
    }
}
