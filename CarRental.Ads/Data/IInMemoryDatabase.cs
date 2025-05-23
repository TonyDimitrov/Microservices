namespace CarRental.Ads.Data
{
    public interface IInMemoryDatabase
    {
        List<CarAdd> CarAdds { get; set; }
    }
}
