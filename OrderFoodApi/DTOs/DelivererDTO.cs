using System.ComponentModel.DataAnnotations;
using OrderFoodApi.Attributes;

namespace OrderFoodApi.DTOs
{
    public class DelivererDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [PhoneNumber]
        public string PhoneNumber { get; set; }
    }
}
