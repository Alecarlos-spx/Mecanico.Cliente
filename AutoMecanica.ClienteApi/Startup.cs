using System;
using System.Collections.Generic;
using System.Text;
using AutoMecanica.ClienteApi;
using AutoMecanica.ClienteApi.Domain.Interfaces.Repositories;
using AutoMecanica.ClienteApi.Host;
using AutoMecanica.ClienteApi.Host.Filters;
using AutoMecanica.ClienteApi.Infra.Dapper.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AutoMecanica.ClienteAPI.Host
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
            services.AddTransient<IClienteRepository, ClienteRepository>();

            var appStatus = Configuration.GetValue<string>("AppStatus");

            var appSettingsSection = Configuration.GetSection("");


            if (appStatus == "Producao")
            {
                appSettingsSection = Configuration.GetSection("AppSettings-Producao");
                services.Configure<AppSettings>(appSettingsSection);
            }
            else
            {
                appSettingsSection = Configuration.GetSection("AppSettings");
                services.Configure<AppSettings>(appSettingsSection);

            }


            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5),
                    ValidIssuer = appSettings.Emissor,
                    ValidAudience = appSettings.ValidoEm
                };
            });



            services.AddMvcCore()
               .AddJsonFormatters()
               .AddApiExplorer()
               .AddVersionedApiExplorer(p =>
               {
                   p.GroupNameFormat = "'v'VVV";
                   p.SubstituteApiVersionInUrl = true;
               });



            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ErrorResponseFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            //config Versionamento
            services.AddApiVersioning(p =>
            {
                p.DefaultApiVersion = new ApiVersion(1, 0);
                p.ReportApiVersions = true;
                p.AssumeDefaultVersionWhenUnspecified = true;
            });


            // Inseri no pepiline a configuração feita para o swagger
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityRequirement(
                    new Dictionary<string, IEnumerable<string>>
                    {
                        { "Bearer", new string[]{ } }
                    });

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey",
                    Description = "Insira o token JWT dessa maneira: Bearer { seu token }"
                });

                c.EnableAnnotations();

                c.DescribeAllEnumsAsStrings();
                c.DescribeStringEnumsInCamelCase();

                //adicionando o filtro para incluir respostas 401 nas operações
                c.OperationFilter<AuthResponsesOperationFilter>();
                //adicionando o filtro para incluir descrições nas tags
                c.DocumentFilter<TagDescriptionsDocumentFilter>();



            });

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(opt =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    opt.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());

                }
                opt.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List);
            });

            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();

            //app.UseHttpsRedirection();
            //app.UseMvc();
        }
    }
}
