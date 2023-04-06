using System.Collections.Generic;
using System.Linq;
using HW2_website.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW2_website.Controllers
{
    public class FarmController : Controller
    {
        private static List<Farm> farm = new List<Farm>
        {
            new Farm { Id = 1, KindOfAnimal = "Cow", Name = "Betsy", Weight = 800 },
            new Farm { Id = 2, KindOfAnimal = "Pig", Name = "Wilbur", Weight = 120 },
            new Farm { Id = 3, KindOfAnimal = "Chicken", Name = "Henrietta", Weight = 2 },
        };

        public  ActionResult Index()
        {
            return View(farm);
        }

        public ActionResult Details(int id)
        {
            var farm = FarmController.farm.FirstOrDefault(f => f.Id == id);

            return View(farm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Farm farm)
        {
            if (ModelState.IsValid)
            {
                farm.Id = FarmController.farm.Max(f => f.Id) + 1;
                FarmController.farm.Add(farm);

                return RedirectToAction("Index");
            }

            return View(farm);
        }

        public ActionResult Edit(int id)
        {
            var farm = FarmController.farm.FirstOrDefault(f => f.Id == id);

            return View(farm);
        }

        [HttpPost]
        public ActionResult Edit(Farm farm)
        {
            if (ModelState.IsValid)
            {
                var existingFarm = FarmController.farm.FirstOrDefault(f => f.Id == farm.Id);

                existingFarm.KindOfAnimal = farm.KindOfAnimal;
                existingFarm.Name = farm.Name;
                existingFarm.Weight = farm.Weight;

                return RedirectToAction("Index");
            }

            return View(farm);
        }

        public ActionResult Delete(int id)
        {
            var farm = FarmController.farm.FirstOrDefault(f => f.Id == id);

            return View(farm);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var farm = FarmController.farm.FirstOrDefault(f => f.Id == id);

            FarmController.farm.Remove(farm);

            return RedirectToAction("Index");
        }
    }
}