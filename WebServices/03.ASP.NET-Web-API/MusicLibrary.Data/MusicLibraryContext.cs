namespace MusicLibrary.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using MusicLibrary.Models;

    public class MusicLibraryContext: DbContext
    {
        public MusicLibraryContext()
            : base("name=MusicLibraryDb")
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlbumMappings());
            modelBuilder.Configurations.Add(new SongMappings());
            modelBuilder.Configurations.Add(new ArtistMappings());

            base.OnModelCreating(modelBuilder);
        }
    }
}
