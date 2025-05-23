namespace CarRental.Identity.Data
{
    public class InMemoryDatabase : IInMemoryDatabase
    {
        public List<UserInputModel> Users { get; set; } = new List<UserInputModel>
        {
            new UserInputModel
            {
                 Id = 1,
                 Email = "toni@gmail.com",
                 Password = "123456"
            },
            new UserInputModel
            {
                 Id = 2,
                 Email = "t@t.com",
                 Password = "123456"
            }
        };
    }
}
