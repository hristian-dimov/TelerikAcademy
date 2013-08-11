using System;
using System.Data.Entity;
using MusicStore.Models;

namespace MusicStore.Repositories
{
    public class DbAlbumsRepository : DbRepository<Album>
    {
        public DbAlbumsRepository(DbContext context)
            : base(context)
        {
        }
    }
}
