
using CadastroCedulas.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroCedulas
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options => 
            { 
                options.UseSqlServer(Configuration.GetConnectionString("Default")); 
            });

            /*AddSingleton:
              cria uma �nica inst�ncia do servi�oquando � solicitado 
              pela primeira vez e reutiliza essa mesma inst�ncia em todos
              os locais  em que esse servi�o � necess�rio.*/

            //services.AddSingleton<IRepository, Repository>();

            /*AddTransient:
              Sempre gerar� uma nova instancia para cada item encontrado que possua
              tal depend�ncia, ou seja, se houver 5 depend�ncias ser�o 5 inst�ncias diferentes.*/

            //services.AddTransient<IRepository, Repository>();

            /*AddScoped:
              garante que uma requisi��o seja criada uma inst�ncia de uma classe onde se houver
              outras depend�cias, essa depend�cia seja utilizada por todas as inst�ncias.*/
            
            services.AddScoped<IRepository, Repository>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
