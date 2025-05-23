using CarRental.Identity.Data;
using CarRental.Identity.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _service;

        public IdentityController(IIdentityService service)
        {
            _service = service;
        }

        [HttpPost(nameof(Login))]
        public IActionResult Login(UserInputModel model)
        {
            var token = _service.Login(model.Email, model.Password);

            return Ok(token);
        }

        [HttpPost("register")]
        public IActionResult Create(UserInputModel model)
        {
            // TODO validate
            
            _service.Create(model);

            return Ok(204);
        }
    }
}
