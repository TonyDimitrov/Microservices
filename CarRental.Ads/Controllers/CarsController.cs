using CarRental.Ads.Data;
using CarRental.Ads.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Ads.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        IInMemoryDatabase _database;
        public CarsController(IInMemoryDatabase database)
        {
            _database = database;
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _database.CarAdds.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("create")]
        public IActionResult Create(CarAdd carAdd)
        {
            _database.CarAdds.Add(carAdd);

            return Ok(204);
        }
    }
}
