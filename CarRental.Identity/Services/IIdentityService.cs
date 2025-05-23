using CarRental.Identity.Data;

namespace CarRental.Identity.Services
{
    public interface IIdentityService
    {
        UserInputModel Get(int id);
        void Create(UserInputModel model);
        bool Update(UserInputModel model);
        string Login(string username, string password);
    }
}
