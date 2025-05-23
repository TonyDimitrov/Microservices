using CarRental.Dealers.Data;
using CarRental.Dealers.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Dealers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DealerController : ControllerBase
    {
        IDealerService _dealerService;

        public DealerController(IDealerService dealerService)
        {
            _dealerService = dealerService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _dealerService.GetAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("create")]        
        public async Task<IActionResult> Create(Dealer dealer)
        {
            _dealerService.Create(dealer);

            return await Task.FromResult(Ok(204));
        }
    }
}
