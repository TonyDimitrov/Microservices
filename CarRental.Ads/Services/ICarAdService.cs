using CarRental.Ads.Data;

namespace CarRental.Ads.Services
{
    public interface ICarAdService
    {
        Task<CarAdd> Get(int id);
        Task Crete(CarAdd carAdd);
    }
}
