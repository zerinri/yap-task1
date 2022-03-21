using System.Threading.Tasks;
using Server.Common.Entities;
using Server.Core.Entities;

namespace server.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}