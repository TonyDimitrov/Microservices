namespace CarRental.Infrastructure.Messages
{
    public class CarAdCreatedMessage
    {
        public int CarId { get; set; }
        public int DealerId { get; set; }
    }
}
