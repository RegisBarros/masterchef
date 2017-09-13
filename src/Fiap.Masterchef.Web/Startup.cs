using Fiap.Masterchef.Core.Application.Interfaces;
using Fiap.Masterchef.Core.Applicaton;
using Fiap.Masterchef.Core.Repositories;
using Fiap.Masterchef.Core.Services;
using Fiap.Masterchef.Infra.Data.Contexts;
using Fiap.Masterchef.Infra.Repositories;
using Fiap.Masterchef.Infra.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace Fiap.Masterchef.Web
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
            services.AddDbContext<MasterchefContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IReceitaApplicationService, ReceitaApplicationService>();
            services.AddTransient<IReceitaRepository, ReceitaRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IFotoService, FotoService>();

            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Receitas}/{action=Index}/{id?}");
            });
        }
    }
}
