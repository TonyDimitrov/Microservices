using CarRental.Ads.Data;
using CarRental.Infrastructure.Messages;
using MassTransit;

namespace CarRental.Ads.Services
{
    public class CarAdService : ICarAdService
    {
        private readonly IBus _bus;
        private readonly IInMemoryDatabase _database;

        public CarAdService(IInMemoryDatabase database, IBus bus)
        {
            _database = database;
            _bus = bus;
        }

        public async Task<CarAdd> Get(int id)
        {
            return await Task.FromResult(_database.CarAdds.FirstOrDefault(ca => ca.Id == id));
        }

        public async Task Crete(CarAdd carAdd)
        {
            _database.CarAdds.Add(carAdd);

            await _bus.Publish(new CarAdCreatedMessage { CarId = 1, DealerId = 1});
        }
    }
}
