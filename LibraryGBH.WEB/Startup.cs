using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Core.Common.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using LibraryGBH.Business;
using LibraryGBH.Business.Engines;
using LibraryGBH.Business.Engines.Contracts;
using LibraryGBH.Business.Entities;
using LibraryGBH.Data;


namespace LibraryGBH.WEB
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
            var appSettings = Configuration.GetSection("AppSettings");
            var connectionStrings = Configuration.GetSection("ConnectionStrings");

            services.Configure<AppSettings>(appSettings);
            services.Configure<ConnectionStrings>(connectionStrings);

            var connections = connectionStrings.Get<ConnectionStrings>();
            var migrationAssembly = typeof(Startup).GetType().Assembly.GetName().Name;

            services.AddCors(options => {

                options.AddPolicy("CorsPolicy",builder => 
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod().AllowAnyHeader()
                    .AllowCredentials());
            });



            //IdentityCore
            services.AddIdentity<IdentityUser, IdentityRole>(options => { }).AddEntityFrameworkStores<LibraryGBHDataContext>();
            //services.AddScoped<IUserStore<IdentityUser>, UserOnlyStore<IdentityUser, IdentityDbContext>>();
            services.AddDbContext<IdentityDbContext>(opt => opt.UseSqlServer(new SqlConnection(connections.MainConnection), sql => sql.MigrationsAssembly(migrationAssembly)));

            //One instance per request
            services.AddDbContext<LibraryGBHDataContext>(options =>
            {

                var connection = new SqlConnection(connections.MainConnection);
                options.UseSqlServer(connection);
                


            });



            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDataRepositoryFactory, DataRepositoryFactory>();
            services.AddScoped<IBusinessEngineFactory, BusinessEngineFactory>();

            //New instance for injection
            services.AddTransient(typeof(IDataRepository<>), typeof(Repository<>));

            //Globally used objects
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Engines injection
            services.AddTransient<IBookEngine, BookEngine>();

            // Add application services.
            //services.AddTransient<IEmailSender, EmailSender>();

            //Antiforgery Setup
            services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");

            var cultureInfo = new CultureInfo("es-ES");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            //Cache Setup
            services.AddMemoryCache();

            services.AddMvc().AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
                opt.SerializerSettings.DateFormatString = "dd/MMM/yyyy";
                opt.SerializerSettings.Culture = new CultureInfo("es-ES");
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    ReactHotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            var supportedCultures = new[]
            {
                new CultureInfo("es-ES"),
                new CultureInfo("en-AU"),
                new CultureInfo("en-GB"),
                new CultureInfo("en"),
                new CultureInfo("es-MX"),
                new CultureInfo("es"),
                new CultureInfo("fr-FR"),
                new CultureInfo("fr"),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(new CultureInfo("es-ES")),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
