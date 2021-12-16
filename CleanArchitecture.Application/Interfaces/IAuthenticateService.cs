using CleanArchitecture.Application.DTOs.User.DTO;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IAuthenticateService
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> RegisterUder(UserDTO user);   
        Task<UserDTO> UserAtualizer(string userName);  
        Task<bool> AtualizarUser(UserDTO user);

        Task Logout();
    }
}
