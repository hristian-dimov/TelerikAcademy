using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MusicStore.Data;
using MusicStore.Models;
using MusicStore.Repositories;

namespace MusicStore.Controllers
{
    public class AlbumsController : ApiController
    {
        private readonly IRepository<Album> albumsRepository;

        public AlbumsController(IRepository<Album> repository)
        {
            this.albumsRepository = repository;
        }

        public AlbumsController()
        {
            var context = new MusicStoreContext();
            this.albumsRepository = new DbAlbumsRepository(context);
        }

        // GET api/albums
        public IEnumerable<AlbumModel> GetAll()
        {
            var albumEntities = this.albumsRepository.All().ToList();

            var albumModels =
                from albumEntity in albumEntities
                select new AlbumModel()
                {
                    AlbumId = albumEntity.AlbumId,
                    Title = albumEntity.Title,
                    RealeaseDate = albumEntity.ReleaseDate,
                    Producer = albumEntity.Producer
                };

            return albumModels.ToList();
        }
        

        // GET api/albums/5
        public AlbumModelFull Get(int id)
        {
            var albumEntity = this.albumsRepository.Get(id);

            var albumModel = new AlbumModelFull()
            {
                AlbumId = albumEntity.AlbumId,
                Title = albumEntity.Title,
                RealeaseDate = albumEntity.ReleaseDate,
                Producer = albumEntity.Producer,

                Artists = (
                    from artistEntity in albumEntity.Artists
                    select new ArtistModel()
                    {
                        ArtistId = artistEntity.ArtistId,
                        Name = artistEntity.Name,
                        Country = artistEntity.Country,
                        DateOfBirth = artistEntity.DateOfBirth
                    }),

                Songs = (
                    from songEnitity in albumEntity.Songs
                    select new SongModel()
                    {
                        SongId = songEnitity.SongId,
                        Title = songEnitity.Title,
                        Genre = songEnitity.Genre,
                    })
            };

            return albumModel;
        }

        // POST api/albums
        public void Post([FromBody]Album album)
        {
            this.albumsRepository.Add(album);
        }

        // PUT api/albums/5
        public void Put(int id, [FromBody]Album album)
        {
            this.albumsRepository.Update(id, album);
        }

        // DELETE api/albums/5
        public void Delete(int id)
        {
            this.albumsRepository.Delete(id);
        }
    }
}