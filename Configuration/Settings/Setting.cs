using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Configuration.Settings
{
    public static class Setting
    {

        public static string GetValue(string attributeName)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration[attributeName];
        }

        public static string GetValue(string pSection, string attributeName)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

            var section = configuration.GetSection(pSection);

            return section[attributeName];
        }

    }
}
