using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TaskImpiegati.Models;

public partial class TaskImpiegatiContext : DbContext
{
    public TaskImpiegatiContext()
    {
    }

    public TaskImpiegatiContext(DbContextOptions<TaskImpiegatiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CittaDiResidenza> CittaDiResidenzas { get; set; }

    public virtual DbSet<Impiegato> Impiegatos { get; set; }

    public virtual DbSet<ProvinciaDiResidenza> ProvinciaDiResidenzas { get; set; }

    public virtual DbSet<Reparto> Repartos { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-701IT76\\SQLEXPRESS01;Database=Task_Impiegati;User Id=Academy;Password=Academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CittaDiResidenza>(entity =>
        {
            entity.HasKey(e => e.CittaDiResidenzaId).HasName("PK__Citta_di__165F02B77B2644B8");

            entity.ToTable("Citta_di_residenza");

            entity.Property(e => e.CittaDiResidenzaId).HasColumnName("citta_di_residenzaID");
            entity.Property(e => e.NomeCitta)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome_citta");
            entity.Property(e => e.ProvinciaRif).HasColumnName("provinciaRIF");

            entity.HasOne(d => d.ProvinciaRifNavigation).WithMany(p => p.CittaDiResidenzas)
                .HasForeignKey(d => d.ProvinciaRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Citta_di___provi__47DBAE45");
        });

        modelBuilder.Entity<Impiegato>(entity =>
        {
            entity.HasKey(e => e.ImpiegatoId).HasName("PK__Impiegat__C7A20D129A32A088");

            entity.ToTable("Impiegato");

            entity.HasIndex(e => e.Matricola, "UQ__Impiegat__2C2751BAD9165869").IsUnique();

            entity.Property(e => e.ImpiegatoId).HasColumnName("impiegatoID");
            entity.Property(e => e.CittaDiResidenza)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("citta_di_residenza");
            entity.Property(e => e.Cognome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("cognome");
            entity.Property(e => e.DataDiNascita).HasColumnName("data_di_nascita");
            entity.Property(e => e.IndirizzoDiResidenza)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("indirizzo_di_residenza");
            entity.Property(e => e.Matricola)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("matricola");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.ProvinciaDiResidenza)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("provincia_di_residenza");
            entity.Property(e => e.Reparto)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("reparto");
            entity.Property(e => e.Ruolo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ruolo");
        });

        modelBuilder.Entity<ProvinciaDiResidenza>(entity =>
        {
            entity.HasKey(e => e.ProvinciaDiResidenzaId).HasName("PK__Provinci__4CF61251B885B277");

            entity.ToTable("Provincia_di_residenza");

            entity.Property(e => e.ProvinciaDiResidenzaId).HasColumnName("provincia_di_residenzaID");
            entity.Property(e => e.NomeProvincia)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome_provincia");
            entity.Property(e => e.Sigla)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("sigla");
        });

        modelBuilder.Entity<Reparto>(entity =>
        {
            entity.HasKey(e => e.RepartoId).HasName("PK__Reparto__612C4F3680C4B37D");

            entity.ToTable("Reparto");

            entity.Property(e => e.RepartoId).HasColumnName("repartoID");
            entity.Property(e => e.NomeReparto)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome_reparto");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
