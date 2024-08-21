namespace bangazon.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public bool Open { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public int PaymentId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
