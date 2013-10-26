namespace MusicLibrary.Models
{
    using System;
    using System.Linq;

    public class Song
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string Genre { get; set; }

        public Artist Artist { get; set; }
    }
}