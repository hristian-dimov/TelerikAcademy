using System;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MusicStore.Repositories
{
    public abstract class DbRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext dbContext;
        private readonly DbSet<T> entitySet;

        public DbRepository(DbContext context)
        {
            this.dbContext = context;
            this.entitySet = this.dbContext.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.entitySet;
        }

        public T Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public void Add(T item)
        {
            this.entitySet.Add(item);
            this.dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var deletedAlbum = this.entitySet.Find(id);
            this.entitySet.Remove(deletedAlbum);
            this.dbContext.SaveChanges();
        }

        public void Update(int id, T item)
        {
            DbEntityEntry entry = this.dbContext.Entry(item);

            if (entry.State == EntityState.Detached)
            {
                this.entitySet.Attach(item);
            }

            entry.State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
    }
}
