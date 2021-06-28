using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DAL.DbContexts
{
    public class MyDbContext : IdentityDbContext<User,MyRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlServer("Server =(localdb)\\MSSQLLocalDB; Database =Game; Trusted_Connection = True; ");
        }

            DbSet <Developer> Developers { get; set; }
        DbSet <Game> Games { get; set; }
        DbSet <Genre> Genres { get; set;}
        DbSet <Publisher> Publishers { get; set; }
        DbSet <UserBought> UserBoughts { get; set; }
        

        public MyDbContext(DbContextOptions<MyDbContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            //Developer
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Developer>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Developer>()
                .Property(d => d.Name)
                .HasMaxLength(45).IsRequired();
            modelBuilder.Entity<Developer>()
                .Property(d => d.Id_Publisher)
                .IsRequired();
            modelBuilder.Entity<Developer>()
                .HasOne<Publisher>()
                .WithMany()
                .HasForeignKey(p => p.Id_Publisher);

            //User
            modelBuilder.Entity<User>()
               .Property(u => u.Money)
               .IsRequired();

            //Game
            modelBuilder.Entity<Game>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Game>()
                .Property(g => g.Name)
                .HasMaxLength(45).IsRequired();
            modelBuilder.Entity<Game>()
                .Property(g => g.Id_Dev)
                .IsRequired();
            modelBuilder.Entity<Game>()
                .Property(g => g.Id_Genre)
                .IsRequired();
            modelBuilder.Entity<Game>()
                .Property(g => g.Cost)
                .IsRequired();
            modelBuilder.Entity<Game>()
               .HasOne<Developer>()
                .WithMany()
                .HasForeignKey(p => p.Id_Dev);
            modelBuilder.Entity<Game>()
                .HasOne<Genre>()
                .WithMany()
                .HasForeignKey(p => p.Id_Genre);

            //Genre
            modelBuilder.Entity<Genre>()
                .HasKey(g => g.Id);
            modelBuilder.Entity<Genre>()
                .Property(g => g.Name)
                .HasMaxLength(45).IsRequired();

            //Publisher
            modelBuilder.Entity<Publisher>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Publisher>()
                .Property(p => p.Name)
                .HasMaxLength(45).IsRequired();

            //UserBought
            modelBuilder.Entity<UserBought>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<UserBought>()
                .Property(u => u.Id_Game)
                .IsRequired();
            modelBuilder.Entity<UserBought>()
                .Property(u => u.Id_User)
                .IsRequired();
            modelBuilder.Entity<UserBought>()
                .HasOne<Game>()
                .WithMany()
                .HasForeignKey(p => p.Id_Game);
            modelBuilder.Entity<UserBought>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.Id_User);

        }
    }
}
