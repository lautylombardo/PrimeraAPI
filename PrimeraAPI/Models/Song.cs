﻿namespace PrimeraAPI.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }

}
