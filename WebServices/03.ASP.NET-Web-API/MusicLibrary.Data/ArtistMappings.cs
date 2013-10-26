namespace MusicLibrary.Data
{
    using System;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using MusicLibrary.Models;

    public class ArtistMappings : EntityTypeConfiguration<Artist>
    {
        public ArtistMappings()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Name).IsMaxLength();
            this.Property(x => x.Country).IsMaxLength();
            this.Property(x => x.BirthDate).IsOptional();
        }
    }
}