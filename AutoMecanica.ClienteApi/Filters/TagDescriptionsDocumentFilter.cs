using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AutoMecanica.ClienteApi.Host.Filters
{
    public class TagDescriptionsDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Tags = new[] {
            new Tag { Name = "Cliente", Description = "Consulta e mantém os Clientes" },
            
        };
        }
    }
}
