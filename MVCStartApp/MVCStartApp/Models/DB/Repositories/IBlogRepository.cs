using System.Threading.Tasks;

namespace MVCStartApp.Models.DB.Repositories
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User []> GetUsers();
    }
}