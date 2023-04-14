using HW1.Models;

namespace HW1.Services
{
    public class FarmRepository : IFarmRepository
    {
        private readonly List<Farm> _farm = new List<Farm> 
        {
            new Farm
            {
                Id = 1,
                KindOfAnimal = "Cow",
                Name = "Betsy",
                Weight = 1000
            },
            new Farm
            {
                Id = 2,
                KindOfAnimal = "Horse",
                Name = "Thunder",
                Weight = 1500
            },
            new Farm
            {
                Id = 3,
                KindOfAnimal = "Pig",
                Name = "Wilbur",
                Weight = 250
            },
            new Farm
            {
                Id = 4,
                KindOfAnimal = "Chicken",
                Name = "Henrietta",
                Weight = 3
            },
            new Farm
            {
                Id = 5,
                KindOfAnimal = "Goat",
                Name = "Billy",
                Weight = 75
            }
        };

        public Task CreateFarmAsync(Farm farm)
        {
            _farm.Add(farm);
            return Task.CompletedTask;
        }

        public Task DeleteFarmAsync(int id)
        {
            _farm.RemoveAll(i => i.Id == id);
            return Task.CompletedTask;
        }

        public Task<Farm[]> GetFarmAsync()
        {
            return Task.FromResult(_farm.ToArray());
        }

        public Task<Farm> GetFarmAsync(int id)
        {
            var farm = _farm.FirstOrDefault(i => i.Id == id);
            return Task.FromResult(farm);
        }

        public Task UpdateFarmAsync(int id, Farm request)
        {
            var farm = _farm.FirstOrDefault(i => i.Id == id);
            farm.KindOfAnimal = request.KindOfAnimal;
            farm.Name = request.Name;
            farm.Weight = request.Weight;
            return Task.CompletedTask;
        }
    }
}
