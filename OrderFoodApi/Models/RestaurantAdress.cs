namespace OrderFoodApi.Models
{
    public class RestaurantAdress
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string HomeNumber { get; set; }
        public Restaurant Restaurant { get; set; }
        public int RestaurantId { get; set; }
    }
}
