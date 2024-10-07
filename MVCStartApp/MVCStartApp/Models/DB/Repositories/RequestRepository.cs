using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MVCStartApp.Models.DB.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly BlogContext _context;
        
        public RequestRepository(BlogContext context) =>
            _context = context;

        public async Task AddRequest(Request request)
        {
            request.Date = DateTime.Now;
            request.Id = Guid.NewGuid();
            
            EntityEntry<Request> entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);
            
            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetRequests() =>
            await _context.Requests.ToArrayAsync();
    }
}