namespace MusicLibrary.Services.Models
{
    using System;
    using System.Linq.Expressions;
    using MusicLibrary.Models;

    public class ArtistModel
    {
        public static Expression<Func<Artist, ArtistModel>> FromArtist
        {
            get
            {
                return x => new ArtistModel { Id = x.Id, Name = x.Name, Country = x.Country, BirthDate = x.BirthDate };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime? BirthDate { get; set; }

        public Artist CreateArtist()
        {
            return new Artist { Name = this.Name, Country = this.Country, BirthDate = this.BirthDate };
        }

        public void UpdateArtist(Artist artist)
        {
            if (this.Name != null)
            {
                artist.Name = this.Name;
            }

            if (this.Country != null)
            {
                artist.Country = this.Country;
            }

            if (this.BirthDate != null)
            {
                artist.BirthDate = this.BirthDate;
            }
        }
    }
}