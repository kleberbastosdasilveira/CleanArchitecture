﻿using CleanArchitecture.Application.DTOs.Login.DTO;
using CleanArchitecture.Application.DTOs.User.DTO;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.Mvc.WebUI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAuthenticateService _authenticate;
        public AccountController(IAuthenticateService authenticate, INotificador notificador) : base(notificador)
        {
            _authenticate = authenticate;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            if (!ModelState.IsValid) return View(model);
            var resultado = await _authenticate.Authenticate(model.Email, model.Passoword);
            if (resultado)
            {
                return Redirect("/");

            }
            else
            {

                if (!OPeracaoValida()) return View(model);
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDTO model)
        {
            var resultado = await _authenticate.RegisterUder(model);
            if (resultado)
            {
                return Redirect("/");
            }
            else
            {
                if (!OPeracaoValida()) return View(model);
                return View(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _authenticate.Logout();
            return Redirect("/Account/Login");
        }

        public async Task<IActionResult>Atualizar(string id)
        {
            return null;
        }
    }
}