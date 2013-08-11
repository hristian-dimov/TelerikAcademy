using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MusicStore.Data;
using MusicStore.Models;
using MusicStore.Repositories;

namespace MusicStore.Controllers
{
    public class ArtistsController : ApiController
    {
        private readonly IRepository<Artist> artistsRepository;

        public ArtistsController(IRepository<Artist> repository)
        {
            this.artistsRepository = repository;
        }

        public ArtistsController()
        {
            var context = new MusicStoreContext();
            this.artistsRepository = new DbArtistsRepository(context);
        }

        // GET api/artists
        public IEnumerable<ArtistModel> GetAll()
        {
            var artistEntities = this.artistsRepository.All().ToList();

            var artistModels =
                from albumEntity in artistEntities
                select new ArtistModel()
                {
                    ArtistId = albumEntity.ArtistId,
                    Name = albumEntity.Name,
                    Country = albumEntity.Country,
                    DateOfBirth = albumEntity.DateOfBirth
                };

            return artistModels.ToList();
        }

        // GET api/artists/5
        public ArtistModel Get(int id)
        {
            var artistEntity = this.artistsRepository.Get(id);

            var artistModel = new ArtistModel()
            {
                ArtistId = artistEntity.ArtistId,
                Name = artistEntity.Name,
                Country = artistEntity.Country,
                DateOfBirth = artistEntity.DateOfBirth
            };

            return artistModel;
        }

        // POST api/artists
        public void Post([FromBody]Artist artist)
        {
            this.artistsRepository.Add(artist);
        }

        // PUT api/artists/5
        public void Put(int id, [FromBody]Artist artist)
        {
            this.artistsRepository.Update(id, artist);
        }

        // DELETE api/artists/5
        public void Delete(int id)
        {
            this.artistsRepository.Delete(id);
        }
    }
}
