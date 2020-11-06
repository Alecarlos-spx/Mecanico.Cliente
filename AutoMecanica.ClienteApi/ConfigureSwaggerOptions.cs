using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AutoMecanica.ClienteApi.Host
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            this.provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));

            }
        }

        private Info CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new Info()
            {
                Title = "API - Clientes",
                Version = "v1",
                Description = "Esta API é responsavel pela administração de clientes",
                Contact = new Contact() { Name = "Alexandre", Email = "alexandrecarlos2@gmail.com"}
            };

            if (description.IsDeprecated)
            {
                info.Description += "Esta versão está obsoleta";
            }
            return info;
        }
    }
}
