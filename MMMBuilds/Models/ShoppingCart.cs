using Microsoft.EntityFrameworkCore;

namespace MMMBuilds.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly MMMBuildsDbContext _mmmBuildsDbContext;

        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        private ShoppingCart(MMMBuildsDbContext mmmBuildsDbContext)
        {
            _mmmBuildsDbContext = mmmBuildsDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            MMMBuildsDbContext context = services.GetService<MMMBuildsDbContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Mechanism mech)
        {
            var shoppingCartItem = _mmmBuildsDbContext.ShoppingCartItems.SingleOrDefault(s => s.Mechanism.MechId == mech.MechId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Mechanism = mech,
                    Amount = 1
                };

                _mmmBuildsDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _mmmBuildsDbContext.SaveChanges();
        }

        public int RemoveFromCart(Mechanism mech)
        {
            var shoppingCartItem =
                    _mmmBuildsDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Mechanism.MechId == mech.MechId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _mmmBuildsDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _mmmBuildsDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??=
                       _mmmBuildsDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Mechanism)
                           .ToList();
        }

        public void ClearCart()
        {
            var cartItems = _mmmBuildsDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _mmmBuildsDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _mmmBuildsDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _mmmBuildsDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Mechanism.Price * c.Amount).Sum();
            return total;
        }
    }

}
