using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

namespace FeatureTogglingSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var settings = config.Build();

                    if (hostingContext.HostingEnvironment.IsDevelopment())
                    {
                        config.AddAzureAppConfiguration(o => o.Connect(settings["ConnectionStrings:AppConfig"])
                            .Watch("FeatureToggleSampleSettings:Foo", TimeSpan.FromSeconds(1)));
                    }
                    else
                    {
                        config.AddAzureAppConfiguration(o => o.ConnectWithManagedIdentity(settings["AppConfig:Endpoint"])
                            .Watch("FeatureToggleSampleSettings:Foo", TimeSpan.FromSeconds(1)));
                    }
                })
                .UseStartup<Startup>();
    }
}
