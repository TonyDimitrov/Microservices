namespace CarRental.Dealers.Data
{
    public class InMemoryData : IInMemoryData
    {
        public List<Dealer> Dealers { get; set; } = new List<Dealer>
        {
            new Dealer
            {
                Id = 1,
                FName = "Test1",
            },
            new Dealer
            {
                Id = 2,
                FName = "Test2",
            },
            new Dealer
            {
                Id = 3,
                FName = "Test3",
            },
        };
    }
}
