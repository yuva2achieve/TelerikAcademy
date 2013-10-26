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

    public class AlbumController : ApiController
    {
        private IRepository<Album> data;

        public AlbumController(IRepository<Album> data)
        {
            this.data = data;
        }

        public AlbumController()
        {
            MusicLibraryContext context = new MusicLibraryContext();
            this.data = new EfRepository<Album>(context);
        }

        // GET api/artist
        [HttpGet]
        public IEnumerable<AlbumModel> Get()
        {
            var albums = this.data.All().Select(AlbumModel.FromAlbum);

            return albums;
        }

        // GET api/artist/5
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var song = this.data.All().Where(x => x.Id == id).Select(AlbumModel.FromAlbum).FirstOrDefault();

            if (song == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found!");
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, song);
        }

        // GET api/artist/country
        [HttpGet]
        public IEnumerable<AlbumModel> Get(string producer)
        {
            var albums = this.data.All().Where(x => x.Producer == producer).Select(AlbumModel.FromAlbum);

            return albums;
        }

        // POST api/artist
        [HttpPost]
        public HttpResponseMessage Post([FromBody]AlbumModel value)
        {
            var album = value.CreateAlbum();
            this.data.Add(album);

            var message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(this.Request.RequestUri + album.Id.ToString(CultureInfo.InvariantCulture));
            return message;
        }

        // PUT api/artist/5
        [HttpPut]
        public void Put(int id, [FromBody]AlbumModel value)
        {
            var album = this.data.Get(id);
            value.UpdateAlbum(album);
            this.data.Update(id, album);
        }

        // DELETE api/artist/5
        [HttpDelete]
        public void Delete(int id)
        {
            this.data.Delete(id);
        }
    }
}
