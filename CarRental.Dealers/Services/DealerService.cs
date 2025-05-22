using CarRental.Dealers.Data;

namespace CarRental.Dealers.Services
{
    public class DealerService : IDealerService
    {
        IInMemoryData _inMemoryData;

        public DealerService(IInMemoryData inMemoryData)
        {
            _inMemoryData = inMemoryData;
        }
         
        public async Task<Dealer> GetAsync(int id)
        {            
            return await Task.FromResult(_inMemoryData.Dealers.FirstOrDefault(x => x.Id == id));
        }

        public void Create(Dealer dealer)
        {
            _inMemoryData.Dealers.Add(dealer);
        }
    }
}
