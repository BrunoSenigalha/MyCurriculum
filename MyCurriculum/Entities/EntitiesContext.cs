using Microsoft.EntityFrameworkCore;
using MyCurriculum.Models;

namespace MyCurriculum.Entities
{
    public class EntitiesContext(DbContextOptions<EntitiesContext> options) : DbContext(options)
    {
        public DbSet<Curriculum> Curriculum { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Tool> Tools { get; set;}
        public DbSet<ProjectTool> ProjectTools { get; set; }
        public DbSet<ProfessionalExp> ProfessionalExp { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<AcademicExperience> AcademicExperiences { get; set; }

        // Para definir a chave composta
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectTool>()
                .HasKey(pt => new { pt.ProjectId, pt.ToolId });

            modelBuilder.Entity<ProjectTool>()
                .HasOne(pt => pt.Project)
                .WithMany(p => p.ProjectTool)
                .HasForeignKey(pt => pt.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectTool>()
                .HasOne(pt => pt.Tool)
                .WithMany(t => t.ProjectTool)
                .HasForeignKey(pt => pt.ToolId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
