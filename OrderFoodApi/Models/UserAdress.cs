using System.ComponentModel.DataAnnotations;

namespace OrderFoodApi.Models
{
    public class UserAdress
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string HomeNumber { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
