using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions option):base(option)
        {

        }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<BlogToTag> BlogToTags { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<CastToSocial> CastToSocials { get; set; }
        public DbSet<CustomUser> CustomUsers { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<MovieComment> MovieComments { get; set; }
        public DbSet<MovieToCast> MovieToCasts { get; set; }
        public DbSet<MovieToDirector> MovieToDirectors { get; set; }
        public DbSet<MovieToGenre> MovieToGenres { get; set; }
        public DbSet<MovieToWriter> MovieToWriters { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }

    }
}
