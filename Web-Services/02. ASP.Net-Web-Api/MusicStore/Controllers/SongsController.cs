using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MusicStore.Data;
using MusicStore.Models;
using MusicStore.Repositories;

namespace MusicStore.Controllers
{
    public class SongsController : ApiController
    {
        private readonly IRepository<Song> songsRepository;

        public SongsController(IRepository<Song> repository)
        {
            this.songsRepository = repository;
        }

        public SongsController()
        {
            var context = new MusicStoreContext();
            this.songsRepository = new DbSongsRepository(context);
        }

        // GET api/artists
        public IEnumerable<SongModel> Get()
        {
            var songEntities = this.songsRepository.All().ToList();

            var songModels =
                from songEntity in songEntities
                select new SongModel()
                {
                    SongId = songEntity.SongId,
                    Title = songEntity.Title,
                    Genre = songEntity.Genre,
                };

            return songModels.ToList();
        }

        // GET api/songs/5
        public SongModel Get(int id)
        {
            var songEntity = this.songsRepository.Get(id);

            var songModel = new SongModel()
            {
                SongId = songEntity.SongId,
                Title = songEntity.Title,
                Genre = songEntity.Genre,
            };

            return songModel;
        }

        // POST api/songs
        public void Post([FromBody]Song song)
        {
            this.songsRepository.Add(song);
        }

        // PUT api/songs/5
        public void Put(int id, [FromBody]Song song)
        {
            this.songsRepository.Update(id, song);
        }

        // DELETE api/songs/5
        public void Delete(int id)
        {
            this.songsRepository.Delete(id);
        }
    }
}
