using Microsoft.AspNetCore.Mvc;
using MMMBuilds.Models;
using MMMBuilds.ViewModels;

namespace MMMBuilds.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IMechRepository _mechRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IMechRepository mechRepository, IShoppingCart shoppingCart)
        {
            _mechRepository = mechRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int mechId)
        {
            var selectedMech = _mechRepository.AllMechs.FirstOrDefault(p => p.MechId == mechId);

            if (selectedMech != null)
            {
                _shoppingCart.AddToCart(selectedMech);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int mechId)
        {
            var selectedMech = _mechRepository.AllMechs.FirstOrDefault(p => p.MechId == mechId);

            if (selectedMech != null)
            {
                _shoppingCart.RemoveFromCart(selectedMech);
            }
            return RedirectToAction("Index");
        }
    }
}
