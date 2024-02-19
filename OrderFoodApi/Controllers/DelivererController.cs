using Microsoft.AspNetCore.Mvc;
using OrderFoodApi.Databases;
using OrderFoodApi.DTOs;
using OrderFoodApi.Interfaces;
using OrderFoodApi.Models;
using OrderFoodApi.Repository;

namespace OrderFoodApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DelivererController : Controller
    {
        private readonly IRepository<Deliverer> _dr;

        public DelivererController(IRepository<Deliverer> dr)
        {
            _dr = dr;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<DelivererDTO>))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetDeliverersAsync()
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var Deliverers = await _dr.GetAllAsync();
                List<DelivererDTO> DeliverersDto = new List<DelivererDTO>();
                foreach (Deliverer deliverer in Deliverers)
                {
                    DeliverersDto.Add(Mapper.FromDeliverer(deliverer));
                }
                return Ok(DeliverersDto);
            }
            catch
            {
                return StatusCode(500, "Can't connect to database!");
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(DelivererDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetDelivererAsync([FromQuery] int id)
        {
            if (!await _dr.IsExistsAsync(id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(Mapper.FromDeliverer(await _dr.GetAsync(id)));
        }
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(DelivererDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateDeliverer([FromBody] DelivererDTO deliverer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (! await _dr.AddAsync(Mapper.ToDeliverer(deliverer)))
                {
                    return StatusCode(500, "Something went wrong during saving!");
                }
                return Ok("Succesfully created!");
            }
            catch
            {
                return StatusCode(500, "Can't connect to database!");
            }
        }
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateDelivererAsync([FromBody] DelivererDTO delivererDto)
        {
            try
            { 
                if (!await _dr.IsExistsAsync(delivererDto.Id))
                {
                    return NotFound("No deliverer to delete!");
                }
            }
            catch
            {
                return StatusCode(500, "Can't connect to database!");
            }
            if (!await _dr.UpdateAsync(Mapper.ToDeliverer(delivererDto)))
            {
                return StatusCode(500, "Something went wrong during saving!");
            }
            return Ok("Succesfully updated!");
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteDelivererAsync(int id)
        {
            if(!await _dr.IsExistsAsync(id))
            {
                return NotFound("No deliverer to delete!");
            }
            return Ok(await _dr.DeleteAsync(id));
        }
    }
}
