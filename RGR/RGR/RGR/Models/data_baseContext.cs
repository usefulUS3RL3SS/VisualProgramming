using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RGR
{
    public partial class data_baseContext : DbContext
    {
        public data_baseContext()
        {
        }

        public data_baseContext(DbContextOptions<data_baseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<League> Leagues { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\alexe\\Desktop\\Visual-Programming\\RGR\\data_base.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.NameCountry)
                    .HasColumnType("STRING")
                    .HasColumnName("name_country");
            });

            modelBuilder.Entity<League>(entity =>
            {
                entity.ToTable("League");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasColumnType("STRING")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.IdCountry).HasColumnName("id_country");

                entity.Property(e => e.IdTeam).HasColumnName("id_team");

                entity.Property(e => e.Name)
                    .HasColumnType("STRING")
                    .HasColumnName("name");

                entity.Property(e => e.Position)
                    .HasColumnType("STRING")
                    .HasColumnName("position");

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.IdCountry);

                entity.HasOne(d => d.IdTeamNavigation)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.IdTeam);
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Result");

                entity.Property(e => e.IdLeague).HasColumnName("id_league");

                entity.Property(e => e.IdTeam).HasColumnName("id_team");

                entity.Property(e => e.Place).HasColumnName("place");

                entity.HasOne(d => d.IdLeagueNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdLeague);

                entity.HasOne(d => d.IdTeamNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdTeam);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Ast)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("AST");

                entity.Property(e => e.Blk)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("BLK");

                entity.Property(e => e.Drb)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("DRB");

                entity.Property(e => e.Fg)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("FG");

                entity.Property(e => e.FgPercent)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("FG_percent");

                entity.Property(e => e.Fga)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("FGA");

                entity.Property(e => e.Ft)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("FT");

                entity.Property(e => e.FtPercent)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("FT_percent");

                entity.Property(e => e.Fta)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("FTA");

                entity.Property(e => e.Mp).HasColumnName("MP");

                entity.Property(e => e.Name)
                    .HasColumnType("STRING")
                    .HasColumnName("name");

                entity.Property(e => e.Orb)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("ORB");

                entity.Property(e => e.Pf)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("PF");

                entity.Property(e => e.Pts)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("PTS");

                entity.Property(e => e.Stl)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("STL");

                entity.Property(e => e.Tov)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("TOV");

                entity.Property(e => e.Trb)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("TRB");

                entity.Property(e => e._2p)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("2P");

                entity.Property(e => e._2pPercent)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("2P_percent");

                entity.Property(e => e._2pa)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("2PA");

                entity.Property(e => e._3p)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("3P");

                entity.Property(e => e._3pPercent)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("3P_percent");

                entity.Property(e => e._3pa)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("3PA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
