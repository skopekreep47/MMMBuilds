namespace MMMBuilds.Models
{
    public class OrderRepository: IOrderRepository
    {
        private readonly MMMBuildsDbContext _mMMBuildsDbContext;
        private readonly IShoppingCart _shoppingCart;
        public OrderRepository(MMMBuildsDbContext mMMBuildsDbContext, IShoppingCart shoppingCart)
        {
            _mMMBuildsDbContext = mMMBuildsDbContext;
            _shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
            order.OrderDetails = new List<OrderDetail>();

            //add order and details
            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    MechId = shoppingCartItem.Mechanism.MechId,
                    Price = shoppingCartItem.Mechanism.Price
                };
                order.OrderDetails.Add(orderDetail);
            }
            _mMMBuildsDbContext.Orders.Add(order);
            _mMMBuildsDbContext.SaveChanges();
        }
    }
}
