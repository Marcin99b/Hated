using Autofac;
using Hated.Infrastructure.Extensions;
using Hated.Infrastructure.Mongo;
using Hated.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;

namespace Hated.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>())
                .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<MongoSettings>())
                .SingleInstance();
        }
    }
}
