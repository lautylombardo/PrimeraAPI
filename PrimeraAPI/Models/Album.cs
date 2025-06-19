namespace PrimeraAPI.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public int BandId { get; set; }
        public Band Band { get; set; }

        public List<Song> Songs { get; set; }
    }

}
