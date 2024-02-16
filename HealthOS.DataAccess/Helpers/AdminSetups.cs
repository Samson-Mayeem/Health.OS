using Microsoft.Extensions.Options;

namespace HealthOS.DataAccess.Helpers
{
    public class AdminSetups
    {
        private AppSettings _appSettings;
        public AdminSetups(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;

            Secret = appSettings.Value.Secret;
        }

        public static string Secret { get; set; }
    }
}
