namespace CarRental.Dealers.Data
{
    public class Dealer
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public List<int> CarAds { get; set; } = new List<int>();
    }
}
