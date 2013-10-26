namespace MusicLibrary.Data
{
    using System;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using MusicLibrary.Models;

    public class AlbumMappings : EntityTypeConfiguration<Album>
    {
        public AlbumMappings()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Title).IsMaxLength();
            this.Property(x => x.Producer).IsMaxLength();
            this.Property(x => x.ReleaseDate).IsOptional();
        }
    }
}
