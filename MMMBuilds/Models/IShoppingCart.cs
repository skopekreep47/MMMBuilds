namespace MMMBuilds.Models
{
    public interface IShoppingCart
    {
        void AddToCart(Mechanism mech);
        int RemoveFromCart(Mechanism mech);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
