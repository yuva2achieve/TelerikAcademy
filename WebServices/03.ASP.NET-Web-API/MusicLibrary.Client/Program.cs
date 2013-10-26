using System;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using MusicLibrary.Data;
using MusicLibrary.Data.Migrations;
using MusicLibrary.Models;
using System.Collections.Generic;

namespace MusicLibrary.Client
{
    class Program
    {
        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri("http://localhost:57758/") };

        internal static void Main(string[] args)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicLibraryContext, Configuration>());

            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            //GetAllArtists();
            //GetArtistById(2);
            //AddArtist("Joro 1", "Bulgaria", new DateTime(1987, 1, 24));
            //UpdateArtist(2, "Updated name", "Bulgaria", DateTime.Now);
            //DeleteArtist(2);

            //GetAllSongs();
            //GetSongById(1);
            //AddSong("Just test song", "Rap", DateTime.Now);
            //UpdateSong(1, "Updated title", "Rock", DateTime.Now);
            //DeleteSong(1);

            //GetAllAlbums();
            //GetAlbumById(1);
            //AddAlbum("Just test album", "Nakov", DateTime.Now);
            //UpdateAlbum(1, "Updated title", "Producer", DateTime.Now);
            //DeleteSong(1);

        }

        internal static void GetAllArtists()
        {
            HttpResponseMessage response = Client.GetAsync("api/artist").Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content.ReadAsAsync<IEnumerable<Artist>>().Result;
                foreach (var artist in artists)
                {
                    Console.WriteLine("{0,4} {1,-20} {2} {3}", artist.Id, artist.Name, artist.Country, artist.BirthDate);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void GetArtistById(int id)
        {
            HttpResponseMessage response = Client.GetAsync("api/artist/" + id).Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var artist = response.Content.ReadAsAsync<Artist>().Result;

                Console.WriteLine("{0,4} {1,-20} {2} {3}", artist.Id, artist.Name, artist.Country, artist.BirthDate);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void AddArtist(string name, string country, DateTime? birthDate = null)
        {
            var artist = new Artist { Name = name, Country = country, BirthDate = birthDate };

            var response = Client.PostAsJsonAsync("api/artist", artist).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void UpdateArtist(int id, string name, string country, DateTime? birthDate = null)
        {
            var artist = new Artist { Name = name, Country = country, BirthDate = birthDate };
            var response = Client.PutAsJsonAsync("api/artist/" + id, artist).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist updated!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void DeleteArtist(int id)
        {
            HttpResponseMessage response = Client.DeleteAsync("api/artist/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist deleted!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void GetAllSongs()
        {
            HttpResponseMessage response = Client.GetAsync("api/song").Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var songs = response.Content.ReadAsAsync<IEnumerable<Song>>().Result;
                foreach (var song in songs)
                {
                    Console.WriteLine("{0,4} {1,-20} {2} {3}", song.Id, song.Title, song.Genre, song.ReleaseDate);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void GetSongById(int id)
        {
            HttpResponseMessage response = Client.GetAsync("api/song/" + id).Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var song = response.Content.ReadAsAsync<Song>().Result;

                Console.WriteLine("{0,4} {1,-20} {2} {3}", song.Id, song.Title, song.Genre, song.ReleaseDate);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void AddSong(string title, string genre, DateTime? releaseDate = null)
        {
            var song = new Song() { Title = title, Genre = genre, ReleaseDate = releaseDate };

            var response = Client.PostAsJsonAsync("api/song", song).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void UpdateSong(int id, string title, string genre, DateTime? releaseDate = null)
        {
            var song = new Song() { Title = title, Genre = genre, ReleaseDate = releaseDate };

            var response = Client.PutAsJsonAsync("api/song/" + id, song).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song updated!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void DeleteSong(int id)
        {
            HttpResponseMessage response = Client.DeleteAsync("api/song/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song deleted!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void GetAllAlbums()
        {
            HttpResponseMessage response = Client.GetAsync("api/album").Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsAsync<IEnumerable<Album>>().Result;
                foreach (var album in albums)
                {
                    Console.WriteLine("{0,4} {1,-20} {2} {3}", album.Id, album.Title, album.Producer, album.ReleaseDate);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void GetAlbumById(int id)
        {
            HttpResponseMessage response = Client.GetAsync("api/album/" + id).Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var album = response.Content.ReadAsAsync<Album>().Result;

                Console.WriteLine("{0,4} {1,-20} {2} {3}", album.Id, album.Title, album.Producer, album.ReleaseDate);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void AddAlbum(string title, string producer, DateTime? releaseDate = null)
        {
            var album = new Album() { Title = title, Producer = producer, ReleaseDate = releaseDate };

            var response = Client.PostAsJsonAsync("api/album", album).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void UpdateAlbum(int id, string title, string producer, DateTime? releaseDate = null)
        {
            var album = new Album() { Title = title, Producer = producer, ReleaseDate = releaseDate };

            var response = Client.PutAsJsonAsync("api/album/" + id, album).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album updated!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void DeleteAlbum(int id)
        {
            HttpResponseMessage response = Client.DeleteAsync("api/album/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album deleted!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
