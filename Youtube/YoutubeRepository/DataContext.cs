using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeEntity.Class;


namespace YoutubeRepository
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<React> Reacts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistVideo> PlaylistVideos { get; set; }
        public DbSet<PasswordRecovery> PasswordRecoverys { get; set; }
        public DbSet<APIKey> APIKeys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
