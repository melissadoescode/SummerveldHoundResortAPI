using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SummerveldHoundResort.Infrastructure.Factories;
using SummerveldHoundResort.Infrastructure.Interfaces;
using SummerveldHoundResort.Infrastructure.Interfaces.Dapper;
using SummerveldHoundResort.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummerveldHoundResort.WebAPI
{
    public class StartupIoC
    {
        public static void Setup(IServiceCollection services)
        {
            SetupScoped(services);
            SetupTransient(services);
            SetupSingleton(services);
        }

        private static void SetupTransient(IServiceCollection services)
        {
            // Transient - Always a new instance
            services
                .AddTransient<IDbConnectionFactory, DbConnectionFactory>()
                .AddTransient<IUnitOfWork, UnitOfWork>();
        }

        private static void SetupScoped(IServiceCollection services)
        {
            // Scoped - Creates a new instance per web request 
            services
                // Database
                .AddScoped<IDoggoRepository, DoggoRepository>()
                .AddScoped<IIconRepository, IconRepository>()
                .AddScoped<ILifeEventRepository, LifeEventRepository>()
                .AddScoped<IDoggoAlbumRepository, DoggoAlbumRepository>()
                .AddScoped<IDoggoContentRepository, DoggoContentRepository>()
                .AddScoped<IDoggoPhotoRepository, DoggoPhotoRepository>();
        }

        private static void SetupSingleton(IServiceCollection services)
        {
            // Singleton - Always the same instance 
        }
    }
}
