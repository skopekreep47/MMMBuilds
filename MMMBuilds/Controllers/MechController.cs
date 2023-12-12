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

        public ViewResult List(string category)
        {
            IEnumerable<Mechanism> mechs;
            string? currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                mechs = _mechRepository.AllMechs.OrderBy(m => m.MechId);
                currentCategory = "All Mechanisms";
            }
            else
            {
                mechs = _mechRepository.AllMechs.Where(m => m.Category.CategoryName == category).OrderBy(m => m.MechId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }
            
            return View(new MechListViewModel(mechs, currentCategory));
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