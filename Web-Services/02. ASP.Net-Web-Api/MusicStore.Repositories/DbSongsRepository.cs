using System;
using System.Data.Entity;
using MusicStore.Models;

namespace MusicStore.Repositories
{
    public class DbSongsRepository : DbRepository<Song>
    {
        public DbSongsRepository(DbContext context)
            : base(context)
        {
        }
    }
}
