using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using VideoData.Models;
using VideoVerhuur.Models;
using VideoVerhuur.Services;

namespace VideoVerhuur.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _service;
        private readonly VideoVerhuurDbContext _context;

        public HomeController(ILogger<HomeController> logger, IUserService service, VideoVerhuurDbContext context)
        {
            _logger = logger;
            _service = service;
            string? userSession = HttpContext?.Session?.GetString("userservice");
            if (!string.IsNullOrEmpty(userSession))
            {
                _service = JsonConvert.DeserializeObject<UserService>(userSession)!;
            }
            else
            {
                _context = context;
            }
        }

        public IActionResult Index()
        {
            if (_service.IsAangemeld())
                return RedirectToAction("GenreMenu");
            @ViewBag.Warning = "";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void SaveSession()
        {
            HttpContext.Session.SetString("userservice", JsonConvert.SerializeObject(_service));
        }

        private void NewSession()
        {
            HttpContext.Session.SetString("userservice", JsonConvert.SerializeObject(null));
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel login)
        {

            @ViewBag.Warning = "";
            _service.TryLogin(login.Naam, login.Postcode);
            if (_service.IsAangemeld())
            {
                SaveSession();
                return RedirectToAction("GenreMenu");
            }

            else
                @ViewBag.Warning = "Onbekende klant, probeer opnieuw";
            return View();
        }

        public IActionResult GenreMenu()
        {
            return View(_context.Genres.ToList());
        }

        public IActionResult GenreOplijsting(int id)
        {
            return View(_context.Films.Include(film => film.Genre).Where(film => film.GenreId == id).ToList());
        }
    }
}