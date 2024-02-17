using OrderFoodApi.Models;

namespace OrderFoodApi.DTOs
{
    public static class Mapper
    {
        public static DelivererDTO FromDeliverer(Deliverer deliverer)
        {
            return new DelivererDTO()
            {
                Id = deliverer.Id,
                Name = deliverer.Name,
                Surname = deliverer.Surname,
                PhoneNumber = deliverer.PhoneNumber
            };
        }
        public static Deliverer ToDeliverer(DelivererDTO delivererDto)
        {
            return new Deliverer()
            {
                Id = delivererDto.Id,
                Name = delivererDto.Name,
                Surname = delivererDto.Surname,
                PhoneNumber = delivererDto.PhoneNumber
            };
        }
    }
}
