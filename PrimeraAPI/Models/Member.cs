namespace PrimeraAPI.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Instrument { get; set; }
        public DateTime JoinDate { get; set; }

        public int BandId { get; set; }
        public Band Band { get; set; }
    }

}
