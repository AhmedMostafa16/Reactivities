using Application.Activities;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection service, IConfiguration config)
    {
        service.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebAPIv5", Version = "v1"}); });
        service.AddDbContext<DataContext>(opt => { opt.UseSqlite(config.GetConnectionString("DefaultConnection")); });
        service.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy",
                policy => { policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000"); });
        });
        service.AddMediatR(typeof(List.Handler).Assembly);
        service.AddAutoMapper(typeof(MappingProfiles).Assembly);
        return service;
    }
}