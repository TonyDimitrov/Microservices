using CarRental.Ads.Data;

namespace CarRental.Ads.Services
{
    public interface ICarAddService
    {
        Task<CarAdd> Get(int id);
        void Crete(CarAdd carAdd);
    }
}
