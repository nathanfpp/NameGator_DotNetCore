using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Model;

namespace server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(x => {x.EnableEndpointRouting = false;});
            services.AddDbContext<ItemContext>(options => options.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=Item;Trusted_Connection=true;MultipleActiveResultSets=true"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ItemContext oContexto)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(config=> {
                config.AllowAnyHeader(); 
                config.AllowAnyMethod(); 
                config.AllowAnyOrigin();
            });
            app.UseMvc();

            InicializaDb.Initialize(oContexto);
        }
    }
}
