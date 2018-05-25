using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
// Uncomment for SPA.
using Microsoft.AspNetCore.SpaServices.AngularCli;
// Used for MVC
//using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using DevOpsEnvMgmt.Models;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.Http;

namespace DevOpsEnvMgmt
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
            services.AddScoped<DBDevOps.DataProvider.IHPALMSnapshot, DBDevOps.DataProvider.HPALMSnapshotDataProvider>();
            services.AddScoped<DBDevOps.DataProvider.ITFSLabels, DBDevOps.DataProvider.TFSLabelsDataProvider>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Enable CORS before services.AddMvc()
            services.AddCors();

            services.AddMvc();
			
			services.AddSingleton<IConfiguration>(Configuration);

            // In production, the Angular files will be served from this directory
            // Uncomment for SPA.
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // added for normal, non-spa.  Remove for SPA.
                //app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                //{
                //    HotModuleReplacement = true
                //});
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // Used with CORS: Allow any method to use API
            app.UseCors(options => options.WithOrigins("http://localhost").AllowAnyMethod());
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseStaticFiles();
            // Uncomment for SPA.
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                // for non-SPA.
                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });

            //app.Map("/Client", appSpa =>
            //{

                app.UseSpa(spa =>
                //appSpa.UseSpa(spa =>
                {
                     // To learn more about options for serving an Angular SPA from ASP.NET Core,
                     // see https://go.microsoft.com/fwlink/?linkid=864501

                     spa.Options.SourcePath = "ClientApp";

                    if (env.IsDevelopment())
                    {
                        spa.UseAngularCliServer(npmScript: "start");
                    }
                });
            //});
        }
    }
}
