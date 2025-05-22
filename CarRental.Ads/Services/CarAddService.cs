using CarRental.Ads.Data;

namespace CarRental.Ads.Services
{
    public class CarAddService : ICarAddService
    {
        IInMemoryDatabase _database;
        public CarAddService(IInMemoryDatabase database)
        {
            _database = database;
        }

        public Task<CarAdd> Get(int id)
        {
            return Task.FromResult(new CarAdd { Id = id });
        }

        public void Crete(CarAdd carAdd)
        {
            _database.CarAdds.Add(carAdd);
        }
    }
}
