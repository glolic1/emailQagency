using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QAgencyTask.Models;

public partial class QagencyTaskContext : DbContext
{
    public QagencyTaskContext()
    {
    }

    public QagencyTaskContext(DbContextOptions<QagencyTaskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Email> Emails { get; set; }

    public virtual DbSet<Importance> Importances { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=QAgencyTask;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Email>(entity =>
        {
            entity.ToTable("Email");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.EmailCc).HasColumnName("EmailCC");
            entity.Property(e => e.ImportanceId).HasColumnName("ImportanceID");

            entity.HasOne(d => d.Importance).WithMany(p => p.Emails)
                .HasForeignKey(d => d.ImportanceId)
                .HasConstraintName("FK_Email_Importance");
        });

        modelBuilder.Entity<Importance>(entity =>
        {
            entity.ToTable("Importance");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Importance1).HasColumnName("Importance");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
