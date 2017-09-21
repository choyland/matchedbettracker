using System.Threading.Tasks;
using MatchedBetTracker.Model.Entities;

namespace MatchedBetTracker.Repository.Repositories.Interfaces
{
    public interface IUserRepository
    {
        string StatusMessage { get; set; }
        Task CreateUser(User user);
        Task<User> GetUser();
    }
}
