namespace OrderFoodApi.Models
{
    public class DelivererReview
    {
        public int Id { get; set; }
        public int StarsNumber { get; set; }
        public string Content { get; set; }
        public Deliverer Deliverer { get; set; }
        public int DelivererId { get; set; }
    }
}
