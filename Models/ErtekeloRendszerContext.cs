using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ertekeloRendszer.Models;

public partial class ErtekeloRendszerContext : DbContext
{
    public ErtekeloRendszerContext()
    {
    }

    public ErtekeloRendszerContext(DbContextOptions<ErtekeloRendszerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ertekelesek> Ertekeleseks { get; set; }

    public virtual DbSet<Getter> Getters { get; set; }

    public virtual DbSet<Screening> Screenings { get; set; }

    public virtual DbSet<Szempont> Szemponts { get; set; }

    public virtual DbSet<Végsőpont2> Végsőpont2s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseMySQL("server=localhost;database=ertekelo-rendszer;user=root;password=;ssl mode=none;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ertekelesek>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ertekelesek");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Pontertek)
                .HasColumnType("int(11)")
                .HasColumnName("pontertek");
            entity.Property(e => e.ScreeningId)
                .HasColumnType("int(11)")
                .HasColumnName("screening_id");
            entity.Property(e => e.SzempontId)
                .HasColumnType("int(11)")
                .HasColumnName("szempont_id");
        });

        modelBuilder.Entity<Getter>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("getter");

            entity.Property(e => e.Nev)
                .HasMaxLength(255)
                .HasColumnName("nev");
            entity.Property(e => e.Pontertek)
                .HasColumnType("int(11)")
                .HasColumnName("pontertek");
            entity.Property(e => e.SzempontNev)
                .HasMaxLength(255)
                .HasColumnName("szempont-nev");
            entity.Property(e => e.Szorzo)
                .HasColumnType("int(11)")
                .HasColumnName("szorzo");
            entity.Property(e => e.VégsőPont)
                .HasColumnType("bigint(21)")
                .HasColumnName("végső pont");
        });

        modelBuilder.Entity<Screening>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("screening");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nev)
                .HasMaxLength(255)
                .HasColumnName("nev");
        });

        modelBuilder.Entity<Szempont>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("szempont");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.SzempontNev)
                .HasMaxLength(255)
                .HasColumnName("szempont-nev");
            entity.Property(e => e.Szorzo)
                .HasColumnType("int(11)")
                .HasColumnName("szorzo");
        });

        modelBuilder.Entity<Végsőpont2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("végsőpont2");

            entity.Property(e => e.Nev)
                .HasMaxLength(255)
                .HasColumnName("nev");
            entity.Property(e => e.VégsőPont)
                .HasPrecision(42)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("végső pont");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
