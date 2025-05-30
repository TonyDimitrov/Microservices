﻿using CarRental.Dealers.Data;
using System.Reflection.Metadata.Ecma335;

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

        public bool Update(int dealerId, int carAdId)
        {
            var dealer =_inMemoryData.Dealers.FirstOrDefault(d => d.Id == dealerId);
            if (dealer == null) return false;

            dealer.CarAds.Add(carAdId);

            return true;
        }
    }
}
