using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace WebSaleRepository.Extentions
{
    public class FileUploadOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            string fileUploadMimeTyo = "multipart/form-data";
            IEnumerable<System.Reflection.ParameterInfo> fileParams = context.MethodInfo.GetParameters().Where(p => p.ParameterType == typeof(IFormFile));
            if (!fileParams.Any())
            {
                return;
            }

            operation.Parameters.Clear();
            operation.RequestBody = new OpenApiRequestBody
            {
                Content = new Dictionary<string, OpenApiMediaType>
                  {
                      {
                          fileUploadMimeTyo, new OpenApiMediaType
                          {
                              Schema = new OpenApiSchema
                              {
                                  Type = "object",
                                  Properties = {
                                      {
                                          "file", new OpenApiSchema
                                          {
                                              Type = "file",
                                              Format = "binary"
                                          }
                                      }
                                  },
                                  Required = new HashSet<string> { "file" }
                              }
                          }
                      }
                  }
            };
        }
    }
}
