using System;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using Dapr.Actors.AspNetCore;

namespace MyActor.WebApiClient
{
    public class Program
    {
        private const int AppChannelHttpPort = 3000;

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>()
                        .UseActors(runtime =>
                        {
                            runtime.RegisterActor<MyActor>();
                        })
                        .UseUrls($"http://localhost:{AppChannelHttpPort}/");
                });
    }
}