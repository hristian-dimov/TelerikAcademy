using System;
using System.Data.Entity;
using MusicStore.Models;

namespace MusicStore.Repositories
{
    public class DbArtistsRepository : DbRepository<Artist>
    {
        public DbArtistsRepository(DbContext context)
            : base(context)
        {
        }
    }
}
