using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using System;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.OpenApi.Models;

namespace Sam.SwaggerVersioning.Infrastructure.SwaggerConfigurations
{
    public static class SwaggerConfigurationExtentions
    {
        public static IApplicationBuilder UseSwaggerWithVersioning(this IApplicationBuilder app)
        {
            var provider = app.ApplicationServices.GetRequiredService<IApiVersionDescriptionProvider>();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });

            return app;
        }

        public static IServiceCollection AddSwaggerWithVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(setup =>
            {
                setup.DefaultApiVersion = new ApiVersion(1, 0);
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });

            services.AddSwaggerGen(setup =>
            {
                //var jwtSecurityScheme = new OpenApiSecurityScheme
                //{
                //    Scheme = "bearer",
                //    BearerFormat = "JWT",
                //    Name = "JWT Authentication",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.Http,
                //    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                //    Reference = new OpenApiReference
                //    {
                //        Id = JwtBearerDefaults.AuthenticationScheme,
                //        Type = ReferenceType.SecurityScheme
                //    }
                //};

                //setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                //setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                //    {
                //        { jwtSecurityScheme, Array.Empty<string>() }
                //    });
            });
            services.ConfigureOptions<ConfigureSwaggerOptions>();

            return services;
        }
    }
}
