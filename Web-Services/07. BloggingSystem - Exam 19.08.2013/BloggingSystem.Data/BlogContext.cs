using System;
using System.Data.Entity;
using BloggingSystem.Models;

namespace BloggingSystem.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("BlogSystemDatabase")
        {
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(usr => usr.SessionKey)
                .IsFixedLength()
                .HasMaxLength(50);
            base.OnModelCreating(modelBuilder);
        }
    }
}