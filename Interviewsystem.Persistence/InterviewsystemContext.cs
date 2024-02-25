using Interviewsystem.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
namespace Interviewsystem.Persistence;
public partial class InterviewsystemContext : DbContext
{
    public InterviewsystemContext()
    {
    }

    public InterviewsystemContext(DbContextOptions<InterviewsystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CandidateResultEntity> CandidateResults { get; set; } = null!;
    public virtual DbSet<QuestionEntity> Questions { get; set; } = null!;
    public virtual DbSet<TechnologyEntity> Technologies { get; set; } = null!;
    public virtual DbSet<UserEntity> Users { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CandidateResultEntity>(entity =>
        {
            entity.ToTable("CandidateResult");

            entity.HasKey(e => e.CandidateResultId);

            entity.Property(e => e.CandidateFullname)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<QuestionEntity>(entity =>
        {
            entity.ToTable("Question");

            entity.HasKey(e => e.QuestionId);

            entity.Property(e => e.AnswerElement).IsUnicode(false);

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");

            entity.Property(e => e.QuestionContent).IsUnicode(false);

            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Techno)
                .WithMany(p => p.Questions)
                .HasForeignKey(d => d.TechnoId)
                .HasConstraintName("FK_Question_Technology");
        });

        modelBuilder.Entity<TechnologyEntity>(entity =>
        {
            entity.HasKey(e => e.TechnoId);

            entity.ToTable("Technology");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");

            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.ToTable("User");

            entity.HasKey(e => e.UserId);

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");

            entity.Property(e => e.Fullname)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
