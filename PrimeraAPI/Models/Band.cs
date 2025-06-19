namespace PrimeraAPI.Models
{
    public class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        public bool Active { get; set; }

        public List<Album> Albums { get; set; }
        public List<Member> Members { get; set; }
    }


}
