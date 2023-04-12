using HW1.Models;
using HW1.Services;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace HW1.Controllers
{
    [Route("farm")]
    [ApiController]
    public class FarmController : Controller
    {

        private readonly IFarmRepository _farmRepository;
        public FarmController(IFarmRepository farmRepository)
        {
            _farmRepository = farmRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetFarmAsync()
        {
            return Ok(await _farmRepository.GetFarmAsync());
        }


        [HttpGet("{id}")]
        public async Task<Farm> GetFarmAsync(int id)
        {
            return await _farmRepository.GetFarmAsync(id);
        }


        [HttpPost]
        public async Task<IActionResult> CreateFarmAsync([FromBody] Farm farm)
        {
            await _farmRepository.CreateFarmAsync(farm);
            return StatusCode(201);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFarmAsync(int id, [FromBody] Farm request)
        {
            await _farmRepository.UpdateFarmAsync(id, request);
            return StatusCode(201);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarmAsync(int id)
        {
            await _farmRepository.GetFarmAsync(id);
            return NoContent();
        }
    }
}
