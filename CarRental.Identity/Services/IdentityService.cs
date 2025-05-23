using CarRental.Identity.Data;
using System.Security.AccessControl;

namespace CarRental.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IInMemoryDatabase _database;
        private readonly IJwtService _jwtService;
        public IdentityService(IInMemoryDatabase database, IJwtService jwtService)
        {
            _database = database;
            _jwtService = jwtService;
        }

        public UserInputModel Get(int id)
        {
            return _database.Users.FirstOrDefault(u => u.Id == id);
        }

        public void Create(UserInputModel model)
        {
            _database.Users.Add(model);
        }

        public string Login(string username, string password)
        {
            var user = _database.Users.FirstOrDefault(u => u.Email == username && u.Password == password);
            if (user != null)
                return _jwtService.GenerateToken(user.Id.ToString(), "admin");

            return string.Empty;
        }

        public bool Update(UserInputModel model)
        {
            var user = _database.Users.FirstOrDefault(u =>u.Id == model.Id);

            if (user == null) return false;

            user.Email = model.Email;
            user.Password = model.Password;

            return true;
        }
    }
}
