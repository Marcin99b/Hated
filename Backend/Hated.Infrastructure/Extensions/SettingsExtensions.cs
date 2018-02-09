using Microsoft.Extensions.Configuration;

namespace Hated.Infrastructure.Extensions
{
    public static class SettingsExtensions
    {
        public static T GetSettings<T>(this IConfiguration configuration) where T : new()
        {
            var configurationValue = new T();
            configuration.GetSection(typeof(T).Name.Replace("Settings", string.Empty))
                .Bind(configurationValue);
            return configurationValue;
        }
    }
}
