using HW1.Models;
using System.Numerics;

namespace HW1.Services
{
    public interface IFarmRepository
    {
        Task AddFarm(Farm farm);
        Task DeleteFarm(int id);
        Task<Farm[]> GetFarm();
        Task<Farm> GetFarm(int id);
        Task UpdateFarm(Farm request);
    }
}
