using System;
using Microsoft.EntityFrameworkCore;

namespace ExploreCali.Models
{
    public class BlogDataContext : DbContext 
    {
        public DbSet<Post> Posts { get; set; }

        public BlogDataContext(DbContextOptions<BlogDataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }

}
