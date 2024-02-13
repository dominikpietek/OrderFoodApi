namespace OrderFoodApi.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public RestaurantAdress Adress { get; set; }
        public List<Dish> Menu { get; set; } = new List<Dish>();
        public List<RestaurantReview> Reviews { get; set; } = new List<RestaurantReview>();
    }
}
