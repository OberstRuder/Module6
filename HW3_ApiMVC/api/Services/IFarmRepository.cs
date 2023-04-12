using HW1.Models;
using System.Numerics;

namespace HW1.Services
{
    public interface IFarmRepository
    {
        Task CreateFarmAsync(Farm farm);
        Task DeleteFarmAsync(int id);
        Task<Farm[]> GetFarmAsync();
        Task<Farm> GetFarmAsync(int id);
        Task UpdateFarmAsync(int id, Farm request);
    }
}
