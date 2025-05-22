using CarRental.Ads.Data;

namespace CarRental.Ads.Services
{
    public interface IInMemoryDatabase
    {
        List<CarAdd> CarAdds { get; set; }
    }
}
