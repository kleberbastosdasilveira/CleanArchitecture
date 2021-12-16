using CleanArchitecture.Domain.Entities;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> RegisterUder(User user, string password);   
        Task<bool> AtualizarUser(User user);
        Task<User> UserAtualizer(string userName);
        Task Logout();
    }
}
