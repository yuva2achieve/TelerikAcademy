namespace MusicLibrary.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using MusicLibrary.Data;
    using MusicLibrary.Models;
    using MusicLibrary.Services.Models;

    public class ArtistController : ApiController
    {
        private IRepository<Artist> data;

        public ArtistController(IRepository<Artist> data)
        {
            this.data = data;
        }

        public ArtistController()
        {
            MusicLibraryContext context = new MusicLibraryContext();
            this.data = new EfRepository<Artist>(context);
        }

        // GET api/artist
        [HttpGet]
        public IEnumerable<ArtistModel> Get()
        {
            var artists = this.data.All().Select(ArtistModel.FromArtist);

            return artists;
        }

        // GET api/artist/5
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var artist = this.data.All().Where(x => x.Id == id).Select(ArtistModel.FromArtist).FirstOrDefault();

            if (artist == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found!");
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, artist);
        }

        // GET api/artist/country
        [HttpGet]
        public IEnumerable<ArtistModel> Get(string country)
        {
            var artists = this.data.All().Where(x => x.Country == country).Select(ArtistModel.FromArtist);
            
            return artists;
        }

        // POST api/artist
        [HttpPost]
        public HttpResponseMessage Post([FromBody]ArtistModel value)
        {
            var artist = value.CreateArtist();
            this.data.Add(artist);

            var message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(this.Request.RequestUri + artist.Id.ToString(CultureInfo.InvariantCulture));
            return message;
        }

        // PUT api/artist/5
        [HttpPut]
        public void Put(int id, [FromBody]ArtistModel value)
        {
            var artist = this.data.Get(id);
            value.UpdateArtist(artist);
            this.data.Update(id, artist);
        }

        // DELETE api/artist/5
        [HttpDelete]
        public void Delete(int id)
        {
            this.data.Delete(id);
        }
    }
}
