using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCStartApp.Models.DB.Repositories;

namespace MVCStartApp.Controllers
{
    public class LogsController : Controller
    {
        private readonly IRequestRepository _repo;

        public LogsController(IRequestRepository repo) =>
            _repo = repo;

        public async Task<IActionResult> Index()
        {
            var requests = await _repo.GetRequests();
            return View(requests);
        }
    }
}