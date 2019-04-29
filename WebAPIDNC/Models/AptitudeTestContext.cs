using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPIDNC.Models
{
    public partial class AptitudeTestContext : DbContext
    {
        public AptitudeTestContext()
        {
        }

        public AptitudeTestContext(DbContextOptions<AptitudeTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DifficultyLevel> DifficultyLevel { get; set; }
        public virtual DbSet<Option> Option { get; set; }
        public virtual DbSet<PaperInfo> PaperInfo { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<TeamInfo> TeamInfo { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        // Unable to generate entity type for table 'dbo.PaperDetails'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TeamMember'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DELL;Database=AptitudeTest;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DifficultyLevel>(entity =>
            {
                entity.HasKey(e => e.DifficultyId);

                entity.Property(e => e.DifficultyId).HasColumnName("DifficultyID");

                entity.Property(e => e.DiffLevel)
                    .HasColumnName("Diff_Level")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.Property(e => e.OptionId).HasColumnName("OptionID");

                entity.Property(e => e.QuesId).HasColumnName("QuesID");

                entity.HasOne(d => d.Ques)
                    .WithMany(p => p.Option)
                    .HasForeignKey(d => d.QuesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Option_Question");
            });

            modelBuilder.Entity<PaperInfo>(entity =>
            {
                entity.HasKey(e => e.PaperId);

                entity.Property(e => e.PaperId).HasColumnName("PaperID");

                entity.Property(e => e.Final)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Shift)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.PaperInfo)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_PaperInfo_Status1");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.QuesId);

                entity.Property(e => e.QuesId).HasColumnName("QuesID");

                entity.Property(e => e.DifficultyId).HasColumnName("DifficultyID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Difficulty)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.DifficultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Question_DifficultyLevel");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Question_Subject");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Value).HasMaxLength(50);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.CurrentStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            });

            modelBuilder.Entity<TeamInfo>(entity =>
            {
                entity.HasKey(e => e.TeamId);

                entity.ToTable("TeamInfo.");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.Property(e => e.Class)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
