namespace PrimeraAPI.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string AlbumType { get; set; } // Studio, Live, EP, etc.

        public int BandId { get; set; }
        public Band Band { get; set; }

        public List<Song> Songs { get; set; }
    }

}
