namespace MMMBuilds.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int MechId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Mechanism Mech { get; set; } = default!;
        public Order Order { get; set; } = default!;
    }
}
