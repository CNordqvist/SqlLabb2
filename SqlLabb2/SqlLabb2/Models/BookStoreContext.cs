using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SqlLabb2.Models;

public partial class BookStoreContext : DbContext
{
    public BookStoreContext()
    {
    }

    public BookStoreContext(DbContextOptions<BookStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Butiker> Butikers { get; set; }

    public virtual DbSet<Böcker> Böckers { get; set; }

    public virtual DbSet<Författare> Författares { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<LagerSaldo> LagerSaldos { get; set; }

    public virtual DbSet<Ordrar> Ordrars { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<TitlarPerFörfattare> TitlarPerFörfattares { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-UM71DMA;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Finnish_Swedish_CI_AS");

        modelBuilder.Entity<Butiker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__butiker__3214EC27BBFC110C");

            entity.ToTable("Butiker");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.KontaktMail)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Namn)
                .HasMaxLength(26)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Böcker>(entity =>
        {
            entity.HasKey(e => e.Isbn13).HasName("PK__Böcker__3BF79E038F623084");

            entity.ToTable("Böcker");

            entity.Property(e => e.Isbn13)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("ISBN13");
            entity.Property(e => e.FörfattarId).HasColumnName("FörfattarID");
            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.Pris).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.PubId).HasColumnName("PubID");
            entity.Property(e => e.PublishingDate).HasColumnType("date");
            entity.Property(e => e.Språk)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(26)
                .IsUnicode(false);

            entity.HasOne(d => d.Författar).WithMany(p => p.Böckers)
                .HasForeignKey(d => d.FörfattarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Böcker__Författa__2F10007B");

            entity.HasOne(d => d.Genre).WithMany(p => p.Böckers)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Böcker__GenreID__30F848ED");

            entity.HasOne(d => d.Pub).WithMany(p => p.Böckers)
                .HasForeignKey(d => d.PubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Böcker__PubID__300424B4");
        });

        modelBuilder.Entity<Författare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Författa__3214EC274A3F60EC");

            entity.ToTable("Författare");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Efternamn)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Födelsedatum).HasColumnType("date");
            entity.Property(e => e.Förnamn)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK");

            entity.ToTable("Genre");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LagerSaldo>(entity =>
        {
            entity.HasKey(e => new { e.ButikId, e.Isbn13 }).HasName("PK__LagerSal__9669121A998A22E2");

            entity.ToTable("LagerSaldo");

            entity.Property(e => e.ButikId).HasColumnName("ButikID");
            entity.Property(e => e.Isbn13)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("ISBN13");
        });

        modelBuilder.Entity<Ordrar>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Ordrar__C3905BAFADBB1183");

            entity.ToTable("Ordrar");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("OrderID");
            entity.Property(e => e.ButikId).HasColumnName("ButikID");
            entity.Property(e => e.Isbn13)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("ISBN13");
            entity.Property(e => e.OrderDate).HasColumnType("date");

            entity.HasOne(d => d.Butik).WithMany(p => p.Ordrars)
                .HasForeignKey(d => d.ButikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ordrar__ButikID__2C3393D0");

            entity.HasOne(d => d.Isbn13Navigation).WithMany(p => p.Ordrars)
                .HasForeignKey(d => d.Isbn13)
                .HasConstraintName("FK__Ordrar__ISBN13__47DBAE45");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Publishe__3214EC27CB5964F7");

            entity.ToTable("Publisher");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TitlarPerFörfattare>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("TitlarPerFörfattare");

            entity.Property(e => e.LagerVärde).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.Namn)
                .HasMaxLength(41)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
