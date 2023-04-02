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
        private readonly ILogger<FarmController> _logger;
        private readonly IFarmRepository _farmRepository;
        public FarmController(ILogger<FarmController> logger, IFarmRepository farmRepository)
        {
            _logger = logger;
            _farmRepository = farmRepository;
        }

        [HttpGet]
        public async Task<Farm[]> GetFarm()
        {
            _logger.LogInformation("GetPhonesAsync is executed");
            return await _farmRepository.GetFarm();
        }


        [HttpGet("{id}")]
        public async Task<Farm> GetFarm(int id)
        {
            return await _farmRepository.GetFarm(id);
        }


        [HttpPost]
        public async Task Post([FromBody] Farm farm)
        {
            await _farmRepository.GetFarm(farm.Id);
        }


        [HttpPut]
        public async Task Put([FromBody] Farm request)
        {
            await _farmRepository.UpdateFarm(request);
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _farmRepository.GetFarm(id);
        }
    }
}
