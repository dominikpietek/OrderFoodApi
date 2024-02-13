using OrderFoodApi.Attributes;
using System.ComponentModel.DataAnnotations;

namespace OrderFoodApi.Models
{
    public class Deliverer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [PhoneNumber]
        public string PhoneNumber { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<DelivererReview> Reviews { get; set; } = new List<DelivererReview>();
    }
}
