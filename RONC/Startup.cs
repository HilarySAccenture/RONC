using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RONC
{
    public class Startup
    {
        private string _newsApiKey = null;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
      
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            _newsApiKey = Configuration["News:ServiceApiKey"];
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var newsApiKeyIsNull = string.IsNullOrEmpty(_newsApiKey);
            
            if (_newsApiKey != null)
            {
                Environment.SetEnvironmentVariable("NEWS_API_KEY", _newsApiKey);
            }
            
            var apiKey = Environment.GetEnvironmentVariable("NEWS_API_KEY");

            var apiKeyIsNullOrEmpty = string.IsNullOrEmpty(apiKey);
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) => { await context.Response.WriteAsync($"Hello World! Is the API Key Null Or Empty: {apiKeyIsNullOrEmpty}");});
        }
    }
}
