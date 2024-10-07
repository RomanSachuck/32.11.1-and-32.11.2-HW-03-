using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCStartApp.Models.DB;
using MVCStartApp.Models.DB.Repositories;

namespace MVCStartApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogRepository _repo;

        public UsersController(IBlogRepository repo)
        {
            _repo = repo;
        }

        public async Task <IActionResult> Index()
        {
            var users = await _repo.GetUsers();
            return View(users);
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public async Task <IActionResult> Register(User user)
        {
            await _repo.AddUser(user);
            return View(user);
        }
    }
}