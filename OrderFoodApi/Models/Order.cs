using Microsoft.OpenApi.Models;
using OrderFoodApi.Enums;

namespace OrderFoodApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int WaitingTime { get; set; }
        //public list<int> DishIds { get; set; } = new int[10]; // fix it later
        public StatusEnum Status { get; set; }
        public string PhoneNumber { get; set; }
        public User Customer { get; set; }
        public int CustomerId { get; set; }
        public Deliverer Deliverer { get; set; }
        public int DelivererId { get; set; }
    }
}
