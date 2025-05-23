using CarRental.Infrastructure.Messages;
using CarRental.Dealers.Services;
using MassTransit;

namespace CarRental.Dealers.Messages
{
    public class CarAdCreatedConsumer : IConsumer<CarAdCreatedMessage>
    {
        private readonly IDealerService _service;

        public CarAdCreatedConsumer(IDealerService service)
            => _service = service;
        
        public async Task Consume(ConsumeContext<CarAdCreatedMessage> context)
        {
            var msg = context.Message;
            var dealer = await _service.GetAsync(msg.DealerId);
            if (dealer != null)
                _service.Update(msg.DealerId, msg.CarId);
        }
    }
}
