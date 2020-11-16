using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Kcb.Service.Common.Api
{
    /// <summary>
    /// Init class Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Static method Main
        /// </summary>
        /// <param name="args">args</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        
        /// <summary>
        /// Static method CreateHostBuilder 
        /// </summary>
        /// <param name="args">args</param>
        /// <returns>IHostBuilder</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseKestrel();
                    //webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                    //webBuilder.UseIISIntegration();
                    webBuilder.UseStartup<Startup>();
                });
    }
}
