using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AutoMecanica.ClienteApi.Host.Filters
{
    public class AuthResponsesOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            operation.Responses.Add(
            "401",
            new Response { Description = "Unauthorized" });
            operation.Responses.Add(
            "500",
            new Response { Description = "Internal server error" });

        }
    }
     
}
