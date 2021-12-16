using AutoMapper;
using CleanArchitecture.Application.DTOs.User;
using CleanArchitecture.Application.DTOs.User.DTO;
using CleanArchitecture.Application.DTOs.User.Validation;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Account;
using CleanArchitecture.Domain.Entities;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{

    public class AuthenticateService : BaseServices, IAuthenticateService
    {
        private readonly IAuthenticate _authenticate;
        private readonly IMapper _mapper;
        public AuthenticateService(IAuthenticate authenticate, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _authenticate = authenticate;
            _mapper = mapper;
        }
        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _authenticate.Authenticate(email, password);
            if (!result)
            {
                Notificar("Ocorreu um erro ao registrar as suas informações, verifique todos os campos!!");
                return false;
            }
            return result;
        }
        public async Task<bool> RegisterUder(UserDTO user)
        {
            if (!ExecultarValidacao(new UserValidation(), user)) return false;
            var result = await _authenticate.RegisterUder(_mapper.Map<User>(user), user.Password);
            if (!result)
            {
                Notificar("Ocorreu um erro ao registrar as suas informações, verifique todos os campos!!");
                return false;
            }
            return result;
        }
        public async Task Logout()
        {
            await _authenticate.Logout();
        }

        public async Task<UserDTO> UserAtualizer(string userName)
        {
           return   _mapper.Map<UserDTO>( await _authenticate.UserAtualizer(userName));
        }

        public async Task<bool> AtualizarUser(UserDTO user)
        {
            var result = await _authenticate.AtualizarUser(_mapper.Map<User>(user));
            if (!result)
            {
                Notificar("Ocorreu um erro ao atualizar as suas informações, verifique todos os campos!!");
                return false;
            }
            return result;
        }
    }
}
