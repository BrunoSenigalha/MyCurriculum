
using Microsoft.EntityFrameworkCore;
using MyCurriculum.Entities;
using MyCurriculum.Repositories;
using MyCurriculum.Repositories.Interfaces;
using System.Text.Json.Serialization;

namespace MyCurriculum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string mySqlConnection = builder.Configuration.GetConnectionString("MainConnection");
            builder.Services.AddDbContext<EntitiesContext>(options =>
                options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

            builder.Services.AddControllers().AddJsonOptions(options =>
                options.JsonSerializerOptions
                .ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddScoped<CurriculumRepository>();
            builder.Services.AddScoped<LinkRepository>();
            builder.Services.AddScoped<ProfessionalExpRepository>();
            builder.Services.AddScoped<CourseRepository>();
            builder.Services.AddScoped<ToolRepository>();
            builder.Services.AddScoped<LanguageRepository>();
            builder.Services.AddScoped<ProjectRepository>();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
