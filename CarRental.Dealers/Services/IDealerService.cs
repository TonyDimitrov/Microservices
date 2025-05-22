using CarRental.Dealers.Data;

namespace CarRental.Dealers.Services
{
    public interface IDealerService
    {
        Task<Dealer> GetAsync(int id);

        void Create(Dealer dealer);
    }
}
