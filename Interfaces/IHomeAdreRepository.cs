using Bank.Model;

namespace Bank.Interfaces
{
    public interface IHomeAdreRepository
    {
        Task<List<HomeAdre>> GetAllAsync();
        Task<HomeAdre?> GetByIdAsync(int id);
        Task<HomeAdre> CreateHomeAdreAsync(HomeAdre HomeAdre);
        Task<bool> DeleteHomeAdreAsync(int id);
        Task<HomeAdre?> UpdateHomeAdreAsync(int id, HomeAdre HomeAdre);
    }
}
