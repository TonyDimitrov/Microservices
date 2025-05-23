namespace CarRental.Ads.Data
{
    public class InMemoryDatabase : IInMemoryDatabase
    {
        public List<CarAdd> CarAdds { get; set; } = new List<CarAdd>
        {
            new CarAdd { Id = 1, Brand = "Fiat"},
            new CarAdd { Id = 2, Brand = "Renaught"},
            new CarAdd { Id = 3, Brand = "BMW"},
        };
    }
}
