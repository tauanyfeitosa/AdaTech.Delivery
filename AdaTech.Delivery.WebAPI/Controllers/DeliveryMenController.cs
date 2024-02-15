using AdaTech.Delivery.Library.Models;
using AdaTech.Delivery.Library.ModelsBuilding;
using AdaTech.Delivery.Library.Services;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using AdaTech.Delivery.WebAPI.Utilities.Filter;
using System.Runtime.CompilerServices;

namespace AdaTech.Delivery.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryMenController : ControllerBase
    {
        private readonly DeliveryManService _deliveryManService;
        private readonly IConfiguration _configuration;

        public DeliveryMenController(DeliveryManService deliveryManService, IConfiguration configuration)
        {
            _deliveryManService = deliveryManService;
            _configuration = configuration;
        }

        [Authorize]
        [HttpGet]
        [TypeFilter(typeof(SuperUserAndStaffAuthorizationFilter))]
        public IActionResult GetAllDeliveryMen()
        {
            var deliveryMen = _deliveryManService.GetAllDeliveryMen();
            return Ok(deliveryMen);
        }

        [HttpPost]
        public IActionResult PostDeliveryMan([FromBody] DeliveryManRequest deliveryManRequest)
        {

            var deliveryMan = _deliveryManService.CreateDeliveryMan(deliveryManRequest);

            return CreatedAtAction(nameof(GetDeliveryMan), new { id = deliveryMan.Id }, deliveryMan);
        }


        [HttpGet("byCPF")]
        public IActionResult GetDeliveryMan(string cpf)
        {
            var deliveryMan = _deliveryManService.GetDeliveryManByCPF(cpf);
            if (deliveryMan == null)
            {
                throw new KeyNotFoundException($"Nenhum entregador encontrado com o CPF: {cpf}.");
            }
            return Ok(deliveryMan);
        }


        [Authorize]
        [HttpPost("testMiddleware")]
        [TypeFilter(typeof(SuperUserAndStaffAuthorizationFilter))]
        public IActionResult TestMiddleware([FromQuery] bool test)
        {
            if (test)
            {
                return Ok("Middleware testado com sucesso!");
            }

            throw new System.Exception("teste de erro!");
        }

        [HttpGet("login")]
        public IActionResult Login([FromQuery] string cpf, [FromQuery] string senha)
        {

            var deliveryMan = _deliveryManService.GetDeliveryManByCPF(cpf);
            if (deliveryMan == null)
            {
                throw new KeyNotFoundException($"Nenhum entregador encontrado com o CPF: {cpf}.");
            }

            if (deliveryMan.Senha != senha)
            {
                throw new UnauthorizedAccessException("Senha incorreta.");
            }

            deliveryMan.IsLogged = true;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, deliveryMan.Name),
                new Claim(ClaimTypes.Role, "DeliveryMan"),
                new Claim("IsSuperUser", deliveryMan.IsSuperUser.ToString()),
                new Claim("IsStaff", deliveryMan.IsStaff.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

            if (string.IsNullOrEmpty(encodedToken))
            {
                throw new InvalidOperationException("Não foi possível gerar o token de autenticação.");
            }

            return Ok(new { token = encodedToken });
        }

        [HttpPost("logout")]
        public IActionResult Logout([FromQuery] string cpf)
        {
            var deliveryMan = _deliveryManService.GetDeliveryManByCPF(cpf);
            if (deliveryMan == null)
            {
                throw new KeyNotFoundException($"Nenhum entregador encontrado com o CPF: {cpf}.");
            }

            deliveryMan.IsLogged = false;

            return Ok("Logout realizado com sucesso.");
        }

    }
}
