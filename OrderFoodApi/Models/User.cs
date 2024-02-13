using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace OrderFoodApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public UserAdress Adress { get; set; }
        public int Balance { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
