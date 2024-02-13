﻿namespace OrderFoodApi.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Restaurant Restaurant { get; set; }
        public int RestaurantId { get; set; }
        public int Price { get; set; }
    }
}
