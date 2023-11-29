using Microsoft.AspNetCore.Mvc;
using MMMBuilds.Models;
using MMMBuilds.ViewModels;

namespace MMMBuilds.Controllers
{
    public class MechController : Controller
    {
        private readonly IMechRepository _mechRepository;
        private readonly ICategoryRepository _categoryRepository;

        public MechController(IMechRepository mechRepository, ICategoryRepository categoryRepository)
        {
            _mechRepository = mechRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            MechListViewModel mechListViewModel = new MechListViewModel(_mechRepository.AllMechs, "All Mechanisms");

            return View(mechListViewModel);
        }

        public IActionResult Details(int id)
        {
            var mech = _mechRepository.GetMechById(id);
            if (mech == null)
            {
                return NotFound();
            }
            return View(mech);
        }
    }
}