using AdaTech.Delivery.Library.Models;
using AdaTech.Delivery.Library.ModelsBuilding;
using AdaTech.Delivery.Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdaTech.Delivery.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryMenController : ControllerBase
    {
        private readonly DeliveryManService _deliveryManService;

        public DeliveryMenController(DeliveryManService deliveryManService)
        {
            _deliveryManService = deliveryManService;
        }

        [HttpGet]
        public IActionResult GetAllDeliveryMen()
        {
            var deliveryMen = _deliveryManService.GetAllDeliveryMen();
            return Ok(deliveryMen);
        }

        [HttpPost]
        public IActionResult PostDeliveryMan([FromBody] DeliveryManRequest deliveryManRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deliveryMan = new DeliveryMan
            {
                Name = deliveryManRequest.Name,
                LastName = deliveryManRequest.LastName,
                Email = deliveryManRequest.Email,
                PhoneNumber = deliveryManRequest.PhoneNumber,
                CPF = deliveryManRequest.CPF,
                DateBirth = deliveryManRequest.DateBirth,
            };

            _deliveryManService.AddDeliveryMan(deliveryMan);

            return CreatedAtAction(nameof(GetDeliveryMan), new { id = deliveryMan.Id }, deliveryMan);
        }

        [HttpGet("byCPF")]
        public IActionResult GetDeliveryMan(string cpf)
        {
            var deliveryMan = _deliveryManService.GetDeliveryManByCPF(cpf);
            if (deliveryMan == null)
            {
                return NotFound();
            }
            return Ok(deliveryMan);
        }
    }
}
