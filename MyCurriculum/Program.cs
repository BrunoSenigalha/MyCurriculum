
using Microsoft.EntityFrameworkCore;
using MyCurriculum.Domain.Entities;
using MyCurriculum.Infraestructure.Context;
using MyCurriculum.Infraestructure.Repositories;
using MyCurriculum.Infraestructure.Repositories.Interfaces;
using System.Text.Json.Serialization;

namespace MyCurriculum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string? MainConnection = builder.Configuration.GetConnectionString("MainConnection");

            if (string.IsNullOrEmpty(MainConnection))
            {
                throw new InvalidOperationException("MainConnection string is not configured.");
            }

            builder.Services.AddDbContext<EntitiesContext>(options =>
                options.UseSqlServer(MainConnection));

            builder.Services.AddControllers().AddJsonOptions(options =>
                options.JsonSerializerOptions
                .ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddScoped<ICurriculumRepository, CurriculumRepository>();
            builder.Services.AddScoped<IAcademicExperienceRepository, AcademicExperienceRepository>();
            builder.Services.AddScoped<IAddressRepository, AddressRepository>();
            builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
            builder.Services.AddScoped<ILinkRepository, LinkRepository>();
            builder.Services.AddScoped<IProfessionalExpRepository, ProfessionalExpRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
            builder.Services.AddScoped<IToolRepository, ToolRepository>();
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
