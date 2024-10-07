using System.Threading.Tasks;

namespace MVCStartApp.Models.DB.Repositories
{
    public interface IRequestRepository
    {
        Task AddRequest(Request request);
        Task<Request []> GetRequests();
    }
}