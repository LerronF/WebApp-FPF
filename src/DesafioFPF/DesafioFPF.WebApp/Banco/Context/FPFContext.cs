using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DesafioFPF.WebApp.Banco.Entities;

#nullable disable

namespace DesafioFPF.WebApp.Banco.Context
{
    public partial class FPFContext : DbContext
    {
        public FPFContext()
        {
        }

        public FPFContext(DbContextOptions<FPFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Rule> Rules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = itriad00307.itriad.org.local)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = XE) ));User ID=SYSTEM;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.IdRule)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID_RULE");

                entity.Property(e => e.ModifiedAt)
                    .HasPrecision(6)
                    .HasColumnName("MODIFIED_AT");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(104)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Salary)
                    .HasColumnType("NUMBER(10,4)")
                    .HasColumnName("SALARY");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RULE_FK");
            });

            modelBuilder.Entity<Rule>(entity =>
            {
                entity.ToTable("RULE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVE");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.ModifiedAt)
                    .HasPrecision(6)
                    .HasColumnName("MODIFIED_AT");

                entity.Property(e => e.Name)
                    .HasMaxLength(54)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.HasSequence("LOGMNR_DIDS$");

            modelBuilder.HasSequence("LOGMNR_EVOLVE_SEQ$");

            modelBuilder.HasSequence("LOGMNR_SEQ$");

            modelBuilder.HasSequence("LOGMNR_UIDS$").IsCyclic();

            modelBuilder.HasSequence("MVIEW$_ADVSEQ_GENERIC");

            modelBuilder.HasSequence("MVIEW$_ADVSEQ_ID");

            modelBuilder.HasSequence("ROLLING_EVENT_SEQ$");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
