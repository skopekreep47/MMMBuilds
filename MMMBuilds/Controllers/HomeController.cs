using Microsoft.AspNetCore.Mvc;
using MMMBuilds.Models;
using MMMBuilds.ViewModels;

namespace MMMBuilds.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMechRepository _mechRepository;

        public HomeController(IMechRepository mechRepository)
        {
            _mechRepository = mechRepository;
        }

        public IActionResult Index()
        {
            var mechsOfTheWeek = _mechRepository.MechsOfTheWeek;
            var homeViewModel = new HomeViewModel(mechsOfTheWeek);
            return View(homeViewModel);
        }
    }
}
