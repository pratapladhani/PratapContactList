using System.Collections.Generic;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace ContactList
{
    public class AddFileParamTypes : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.operationId == "AssetUpload_PostFormData")  // controller and action name
            {
                operation.consumes.Add("multipart/form-data");
                operation.parameters = new List<Parameter>
                {
                    new Parameter
                    {
                        name = "file",
                        required = true,
                        type = "file",
                        @in = "formData",
                        vendorExtensions = new Dictionary<string, object> { {"x-ms-media-kind", "image" } }
                    }
                };
            }
        }
    }
}