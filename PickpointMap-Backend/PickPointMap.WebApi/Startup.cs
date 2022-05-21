using PickpointMap_Backend.Interface;
using PickpointMap_Backend.Mappings;
using PickpointMap_Backend.Middleware;
using System.Reflection;
using Pickpoint.Map.Application.Common;
using PickpointMap_Backend.Persistence.APT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Options;
using PickpointMap_Backend.PickPointMap.WebApi;
using Pickpoint.Map.Application.Interface;
using PickpointMap_Backend.PickPointMap.WebApi.Services;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

internal class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration) => Configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(IPickpointMapDbContext).Assembly));

        });

        services.AddApplication();
        services.AddPersistence(Configuration);
        services.AddControllers();

        //Настройка того кто к нам может стучаться. В данной настройке стучиться кто угодно и откуда угодно
        services.AddCors(option =>
        {
            option.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        });


        services.AddAuthentication(config =>
        {
            config.DefaultAuthenticateScheme =
                JwtBearerDefaults.AuthenticationScheme;
            config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
               .AddJwtBearer("Bearer", options =>
               {
                   options.Authority = "https://localhost:44386/";
                   options.Audience = "NotesWebAPI";
                   options.RequireHttpsMetadata = false;
               });

        services.AddVersionedApiExplorer(options =>
            options.GroupNameFormat = "'v'VVV");
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>,
                ConfigureSwaggerOptions>();
        services.AddSwaggerGen();
        services.AddApiVersioning();

        services.AddSingleton<ICurrentUserService, CurrentUserService>();
        services.AddHttpContextAccessor();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
        IApiVersionDescriptionProvider provider)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseSwagger();
        app.UseSwaggerUI(config =>
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                config.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
                config.RoutePrefix = string.Empty;
            }
        });
        app.UseCastomExceptionHandler();
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseCors("AllowAll");
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseApiVersioning();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

}