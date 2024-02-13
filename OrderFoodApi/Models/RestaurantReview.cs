namespace OrderFoodApi.Models
{
    public class RestaurantReview
    {
        public int Id { get; set; }
        public int StarsNumber { get; set; }
        public string Content { get; set; }
        public Restaurant Restaurant { get; set; }
        public int RestaurantId { get; set; }
    }
}
