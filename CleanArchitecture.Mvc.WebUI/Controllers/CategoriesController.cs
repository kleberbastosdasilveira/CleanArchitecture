using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CleanArchitecture.Mvc.WebUI.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService, INotificador notificador) : base(notificador)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetCategories());
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid) return View(categoryDTO);
            await _categoryService.Add(categoryDTO);
            if (!OPeracaoValida()) return View(categoryDTO);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet()]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null) return NotFound();
            var categoriaEdit = await _categoryService.GetById(id);
            if (!OPeracaoValida()) return NotFound();
            return View(categoriaEdit);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid) return View(categoryDTO);
            await _categoryService.Update(categoryDTO);
            if (!OPeracaoValida()) return View(categoryDTO);
            TempData["Sucesso"] = "Categoria alterada com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(Guid id)
        {
            var categoriaId = await _categoryService.GetById(id);
            if (categoriaId == null) return View(id);
            return View(categoriaId);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmacao(Guid id)
        {
            var categoriaId = await _categoryService.GetById(id);
            await _categoryService.Remove(id);
            if (!OPeracaoValida()) return View(categoriaId);
            TempData["Sucesso"] = "Categoria excluido com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var categoriaId = await _categoryService.GetByIdDetais(id);
            if (categoriaId == null) return View(id);
            return View(categoriaId);
        }
    }
}
