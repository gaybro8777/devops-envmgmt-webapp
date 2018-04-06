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
            services.AddScoped<DBDevOps.DataProvider.IAppEnvs, DBDevOps.DataProvider.AppEnvsDataProvider>();
            services.AddScoped<DBDevOps.DataProvider.IApplications, DBDevOps.DataProvider.ApplicationsDataProvider>();
            services.AddScoped<DBDevOps.DataProvider.IEnvironments, DBDevOps.DataProvider.EnvironmentsDataProvider>();
            services.AddScoped<DBDevOps.DataProvider.IEnvReqStatusTypes, DBDevOps.DataProvider.EnvReqStatusTypesDataProvider>();
            services.AddScoped<DBDevOps.DataProvider.IEnvRequests, DBDevOps.DataProvider.EnvRequestsDataProvider>();
            services.AddScoped<DBDevOps.DataProvider.IEnvServers, DBDevOps.DataProvider.EnvServersDataProvider>();
            services.AddScoped<DBDevOps.DataProvider.IEnvStatus, DBDevOps.DataProvider.EnvStatusDataProvider>();
            services.AddScoped<DBDevOps.DataProvider.IProjectTeam, DBDevOps.DataProvider.ProjectTeamDataProvider>();
            services.AddScoped<DBDevOps.DataProvider.IReleases, DBDevOps.DataProvider.ReleasesDataProvider>();
            services.AddScoped<DBDevOps.DataProvider.IRoles, DBDevOps.DataProvider.RolesDataProvider>();
            services.AddScoped<DBDevOps.DataProvider.IServers, DBDevOps.DataProvider.ServersDataProvider>();
            services.AddScoped<DBDevOps.DataProvider.IServerType, DBDevOps.DataProvider.ServerTypeDataProvider>();
            services.AddScoped<DBDevOps.DataProvider.IUserRoles, DBDevOps.DataProvider.UserRolesDataProvider>();
            services.AddScoped<DBDevOps.DataProvider.IUsers, DBDevOps.DataProvider.UsersDataProvider>();

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

            app.UseStaticFiles();
            // Uncomment for SPA.
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=}/{action=Index}/{id?}");

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
