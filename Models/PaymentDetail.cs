namespace bangazon.Models
{
    public class PaymentDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ?PaymentType { get; set; }
        public string ?CardNumber { get; set; }
        public string ?Ccv { get; set; }
        public string ?Zip {  get; set; }
    }
}
