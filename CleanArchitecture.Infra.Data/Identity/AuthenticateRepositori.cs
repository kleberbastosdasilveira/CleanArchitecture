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
        public async Task<User> UserAtualizer(string userName)
        {
            var resultado = await _userManager.FindByNameAsync(userName);

            var applicationUser = new User
            {
                Name = resultado.Name,
                Documento = resultado.Documento,
                Email = resultado.Email,
                Endereco = new Address
                {
                    Bairro = resultado.Bairro,
                    Cep = resultado.Cep,
                    Cidade = resultado.Cidade,
                    Complemento = resultado.Complemento,
                    Estado = resultado.Estado,
                    Logradouro = resultado.Logradouro,
                    Numero = resultado.Numero
                }
            };
            return applicationUser;
        }

        public async Task<bool> RegisterUder(User user, string password)
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
            var resultado = await _userManager.FindByEmailAsync(user.Email);
            resultado.Name = user.Name;
            resultado.UserName = user.Name.Replace(" ", "_");
            resultado.Bairro = user.Endereco.Bairro;
            resultado.Cep = user.Endereco.Cep;
            resultado.Cidade = user.Endereco.Cidade;
            resultado.Complemento = user.Endereco.Complemento;
            resultado.Estado = user.Endereco.Estado;
            resultado.Numero = user.Endereco.Numero;

            var result = await _userManager.UpdateAsync(resultado);
            return result.Succeeded;
        }
    }
}
