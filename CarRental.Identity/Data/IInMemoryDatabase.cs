namespace CarRental.Identity.Data
{
    public interface IInMemoryDatabase
    {
        List<UserInputModel> Users { get; set; }
    }
}