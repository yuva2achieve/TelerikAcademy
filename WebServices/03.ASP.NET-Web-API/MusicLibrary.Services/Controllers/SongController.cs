namespace MusicLibrary.Services.Controllers
{
    using MusicLibrary.Data;
    using MusicLibrary.Models;
    using MusicLibrary.Services.Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class SongController : ApiController
    {
        private IRepository<Song> data;

        public SongController(IRepository<Song> data)
        {
            this.data = data;
        }

        public SongController()
        {
            MusicLibraryContext context = new MusicLibraryContext();
            this.data = new EfRepository<Song>(context);
        }

        // GET api/artist
        [HttpGet]
        public IEnumerable<SongModel> Get()
        {
            var songs = this.data.All().Select(SongModel.FromSong);

            return songs;
        }

        // GET api/artist/5
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var song = this.data.All().Where(x => x.Id == id).Select(SongModel.FromSong).FirstOrDefault();

            if (song == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found!");
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, song);
        }

        // GET api/artist/country
        [HttpGet]
        public IEnumerable<SongModel> Get(string genre)
        {
            var songs = this.data.All().Where(x => x.Genre == genre).Select(SongModel.FromSong);

            return songs;
        }

        // POST api/artist
        [HttpPost]
        public HttpResponseMessage Post([FromBody]SongModel value)
        {
            var song = value.CreateSong();
            this.data.Add(song);

            var message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(this.Request.RequestUri + song.Id.ToString(CultureInfo.InvariantCulture));
            return message;
        }

        // PUT api/artist/5
        [HttpPut]
        public void Put(int id, [FromBody]SongModel value)
        {
            var song = this.data.Get(id);
            value.UpdateSong(song);
            this.data.Update(id, song);
        }

        // DELETE api/artist/5
        [HttpDelete]
        public void Delete(int id)
        {
            this.data.Delete(id);
        }
    }
}
