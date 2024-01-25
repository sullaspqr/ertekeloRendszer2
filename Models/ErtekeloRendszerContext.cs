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

    public virtual DbSet<Végsőpont2> Végsőponts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("server=localhost;database=ertekelo-rendszer;user=root;password=;ssl mode=none;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ertekelesek>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ertekelesek");

            entity.HasIndex(e => e.ScreeningId, "screening_id");

            entity.HasIndex(e => e.SzempontId, "szempont_id");

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

            entity.HasOne(d => d.Screening).WithMany(p => p.Ertekeleseks)
                .HasForeignKey(d => d.ScreeningId)
                .HasConstraintName("ertekelesek_ibfk_1");

            entity.HasOne(d => d.Szempont).WithMany(p => p.Ertekeleseks)
                .HasForeignKey(d => d.SzempontId)
                .HasConstraintName("ertekelesek_ibfk_2");
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
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("screening");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nev)
                .HasMaxLength(255)
                .HasColumnName("nev");
        });

        modelBuilder.Entity<Szempont>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("szempont");

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
            entity.Property(e => e.VégsőPont1)
                .HasPrecision(42)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("Végsőpont1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
