using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HW2_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HW2_website.Controllers
{
    public class FarmController : Controller
    {
        private readonly ILogger<FarmController> _logger;
        private readonly HttpClient _httpClient;

        public async Task<List<Farm>> ReadFarm()
        {
            HttpResponseMessage farmResponse = await _httpClient.GetAsync("farm");
            var farmResponseContent = JsonConvert.DeserializeObject<List<Farm>>(await farmResponse.Content.ReadAsStringAsync());

            return farmResponseContent;
        }

        public FarmController(ILogger<FarmController> logger, IHttpClientFactory factory)
        {
            _logger = logger;
            _httpClient = factory.CreateClient("farmClient");
        }

        public async Task<IActionResult> Index()
        {
            var farm = await ReadFarm();
            return View(farm.ToList());
        }

        public async Task<ActionResult> Details(int id)
        {
            var farmRead = await ReadFarm();
            var farm = farmRead.FirstOrDefault(f => f.Id == id);
            return View(farm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string kindOfAnimal, string name, int weight)
        {
            var farmRead = await ReadFarm();
            var farm = new Farm
            {
                Id = farmRead.ToList().Max(f => f.Id) + 1,
                KindOfAnimal = kindOfAnimal,
                Name = name,
                Weight = weight
            };

            var json = JsonConvert.SerializeObject(farm);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage farmResponse = await _httpClient.PostAsync("farm", content);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var farmRead = await ReadFarm();
            var farm = farmRead.FirstOrDefault(f => f.Id == id);
            return View(farm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, string kindOfAnimal, string name, int weight)
        {
            var farm = new Farm
            {
                Id = id,
                KindOfAnimal = kindOfAnimal,
                Name = name,
                Weight = weight
            };

            var json = JsonConvert.SerializeObject(farm);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage farmResponse = await _httpClient.PutAsync($"farm/{id}", content);

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var farmRead = await ReadFarm();
            var farm = farmRead.FirstOrDefault(f => f.Id == id);
            return View(farm);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpResponseMessage farmResponse = await _httpClient.DeleteAsync($"farm/{id}");
            return RedirectToAction("Index");
        }
    }
}