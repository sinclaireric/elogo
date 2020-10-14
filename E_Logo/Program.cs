using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using E_LOGO.Models;
using Microsoft.AspNetCore;

namespace E_LOGO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Seed().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                 WebHost.CreateDefaultBuilder(args)
                   .UseSetting(WebHostDefaults.DetailedErrorsKey, "true")
                .UseStartup<Startup>();
    }
}
