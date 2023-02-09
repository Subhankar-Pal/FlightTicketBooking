using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FlightRepositories.Data
{
    public partial class FlightTBookingContext : DbContext
    {
        public FlightTBookingContext()
        {
        }

        public FlightTBookingContext(DbContextOptions<FlightTBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Airline> Airlines { get; set; } = null!;
        public virtual DbSet<AirlinesTicketsChennaiToMumbai> AirlinesTicketsChennaiToMumbais { get; set; } = null!;
        public virtual DbSet<PassengerDetail> PassengerDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS; database=FlightTBooking; integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airline>(entity =>
            {
                entity.Property(e => e.AirlineName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AirlinesTicketsChennaiToMumbai>(entity =>
            {
                entity.HasKey(e => new { e.FlightId, e.SeatNo, e.Price })
                    .HasName("PK__Airlines__80EFF2E7AAB956EC");

                entity.ToTable("AirlinesTicketsChennaiToMumbai");

                entity.Property(e => e.FlightId).ValueGeneratedOnAdd();

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ArrivalTime).HasColumnType("datetime");

                entity.Property(e => e.DepartureTime).HasColumnType("datetime");

                entity.Property(e => e.FlightAvailability)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Airline)
                    .WithMany(p => p.AirlinesTicketsChennaiToMumbais)
                    .HasForeignKey(d => d.AirlineId)
                    .HasConstraintName("FK__AirlinesT__Airli__4BAC3F29");
            });

            modelBuilder.Entity<PassengerDetail>(entity =>
            {
                entity.HasKey(e => e.PassengerId)
                    .HasName("PK__Passenge__88915FB0D83754F2");

                entity.Property(e => e.PassengerEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassengerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassengerPhoneNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.AirlinesTicketsChennaiToMumbai)
                    .WithMany(p => p.PassengerDetails)
                    .HasForeignKey(d => new { d.FlightId, d.SeatNo, d.Price })
                    .HasConstraintName("FK__PassengerDetails__4E88ABD4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
