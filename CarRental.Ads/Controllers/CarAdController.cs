using CarRental.Ads.Data;
using CarRental.Ads.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Ads.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarAdController : ControllerBase
    {
        ICarAdService _service;
        public CarAdController(ICarAdService service)
        {
            _service = service;
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result =  _service.Get(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> Create(CarAdd carAdd)
        {
            await _service.Crete(carAdd);

            return Ok(204);
        }
    }
}
