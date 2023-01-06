using AlcanceVOLTS.API.Auth;
using AlcanceVOLTS.API.Setup;
using AlcanceVOLTS.Domain.Infra.Settings;
using AlcanceVOLTS.Domain.Services.Common;
using AlcanceVOLTS.Repository.Repositories.Common;

namespace AlcanceVOLTS.API
{
    public class Startup
    {
        public AppSettings AppSettings { get; }

        public Startup(IConfiguration configuration) => this.AppSettings = configuration.Get<AppSettings>();

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton(this.AppSettings)
                .AddSwagger()
                .AddJwtAuth(this.AppSettings)
                .AddSqlServerContexts(this.AppSettings)
                .AddHttpContextAcessor()
                .AddDistributedMemoryCache()
                .AddScopedByBaseType(typeof(ServiceBase))
                .AddScopedByBaseType(typeof(RepositoryBase))
                .AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app
                .UseCustomCors()
                .UseRouting()
                .UseAuthorization()
                .UseDatabaseInitialization()
                .UseSwaggerWithDocs()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
