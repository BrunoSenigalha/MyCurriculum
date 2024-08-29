using Microsoft.EntityFrameworkCore;
using MyCurriculum.Models;

namespace MyCurriculum.Entities
{
    public class EntitiesContext(DbContextOptions<EntitiesContext> options) : DbContext(options)
    {
        public DbSet<Curriculum> Curriculum { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Tool> Tools { get; set;}
        public DbSet<ProfessionalExp> ProfessionalExp { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<AcademicExperience> Formations { get; set; }

    }
}
