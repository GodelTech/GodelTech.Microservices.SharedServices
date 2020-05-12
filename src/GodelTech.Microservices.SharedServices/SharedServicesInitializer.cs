using GodelTech.Microservices.Core;
using GodelTech.Microservices.SharedServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GodelTech.Microservices.SharedServices
{
    public class SharedServicesInitializer : MicroserviceInitializerBase
    {
        public SharedServicesInitializer(IConfiguration configuration) 
            : base(configuration)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDirectoryService, DirectoryService>();
            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<IGuidFactory, GuidFactory>();
            services.AddSingleton<IJsonSerializer, JsonSerializer>();
            services.AddSingleton<IPathService, PathService>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddSingleton<IContentTypeResolver, ContentTypeResolver>();
            services.AddTransient<ITempFileFactory, TempFileFactory>();
        }
    }
}
