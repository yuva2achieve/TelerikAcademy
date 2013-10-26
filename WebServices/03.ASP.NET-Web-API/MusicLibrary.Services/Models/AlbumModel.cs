
namespace MusicLibrary.Services.Models
{
    using MusicLibrary.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class AlbumModel
    {
        public static Expression<Func<Album, AlbumModel>> FromAlbum
        {
            get
            {
                return x => new AlbumModel { Id = x.Id, Title = x.Title, Producer = x.Producer, ReleaseDate = x.ReleaseDate };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string Producer { get; set; }

        public Album CreateAlbum()
        {
            return new Album { Title = this.Title, Producer = this.Producer, ReleaseDate = this.ReleaseDate };
        }

        public void UpdateAlbum(Album album)
        {
            if (this.Title != null)
            {
                album.Title = this.Title;
            }

            if (this.Producer != null)
            {
                album.Producer = this.Producer;
            }

            if (this.ReleaseDate != null)
            {
                album.ReleaseDate = this.ReleaseDate;
            }
        }
    }
}