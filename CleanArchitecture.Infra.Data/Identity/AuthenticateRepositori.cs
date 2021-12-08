using CleanArchitecture.Domain.Account;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.Data.Identity
{
    public class AuthenticateRepositori : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthenticateRepositori(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> Authenticate(string email, string password)
        {
            var applicationUser = await _userManager.FindByEmailAsync(email);
            var result = await _signInManager.PasswordSignInAsync(applicationUser.UserName, password, false, lockoutOnFailure: false);

            return result.Succeeded;
        }

        public async Task<bool> RegisterUder(User user, string password)
        {
            var applicationUser = new ApplicationUser
            {
                Name = user.Name,
                UserName = user.Name.Replace(" ","_"),
                Documento = user.Documento,
                Logradouro = user.Endereco.Logradouro,
                Bairro = user.Endereco.Bairro,
                Cep = user.Endereco.Cep,
                Complemento = user.Endereco.Complemento,
                Cidade = user.Endereco.Cidade,
                Estado = user.Endereco.Estado,
                Email = user.Email
            };
            var result = await _userManager.CreateAsync(applicationUser, password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(applicationUser, isPersistent: false);
            }
            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> AtualizarUser(User user)
        {
            var applicationUser = new ApplicationUser
            {
                Name = user.Name,
                UserName = user.Name.Replace(" ", "_"),
                Documento = user.Documento,
                Logradouro = user.Endereco.Logradouro,
                Bairro = user.Endereco.Bairro,
                Cep = user.Endereco.Cep,
                Complemento = user.Endereco.Complemento,
                Cidade = user.Endereco.Cidade,
                Estado = user.Endereco.Estado,
                Email = user.Email
            };
            var result = await  _userManager.UpdateAsync(applicationUser);
            return result.Succeeded;
        }
    }
}
