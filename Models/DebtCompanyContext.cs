using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Debt_Management.Models;

public partial class DebtCompanyContext : DbContext
{
    public DebtCompanyContext()
    {
    }

    public DebtCompanyContext(DbContextOptions<DebtCompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AdminRequire> AdminRequires { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server =(local); database = DebtCompany; uid=sa;pwd=123456;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC27F760B86C");

            entity.ToTable("Account");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Dob)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("DOB");
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(45)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Admin");

            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(45)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AdminRequire>(entity =>
        {
            entity.HasKey(e => e.RequireId).HasName("PK__AdminReq__011D97B2390F856F");

            entity.ToTable("AdminRequire");

            entity.Property(e => e.Date)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.ProductName).HasMaxLength(45);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SupplierName).HasMaxLength(45);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC2784D2011A");

            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ProductName).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
