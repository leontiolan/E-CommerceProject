namespace ECommerceAdminClient.Models
{
    public class OrderSummaryDTO
    {
        public long id { get; set; }
        public DateTime orderDate { get; set; }
        public string status { get; set; }
        public double orderPrice { get; set; }
    }
}