
namespace MusicLibrary.Services.Models
{
    using MusicLibrary.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class SongModel
    {
        public static Expression<Func<Song, SongModel>> FromSong
        {
            get
            {
                return x => new SongModel { Id = x.Id, Title = x.Title, Genre = x.Genre, ReleaseDate = x.ReleaseDate };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string Genre { get; set; }

        public Song CreateSong()
        {
            return new Song { Title = this.Title, Genre = this.Genre, ReleaseDate = this.ReleaseDate };
        }

        public void UpdateSong(Song song)
        {
            if (this.Title != null)
            {
                song.Title = this.Title;
            }

            if (this.Genre != null)
            {
                song.Genre = this.Genre;
            }

            if (this.ReleaseDate != null)
            {
                song.ReleaseDate = this.ReleaseDate;
            }
        }
    }
}