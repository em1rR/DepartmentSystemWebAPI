using DepartmentSystemWebAPI.DTO;
using DepartmentSystemWebAPI.Exceptions;
using DepartmentSystemWebAPI.GenericDTO;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentSystemWebAPI.Controllers

{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[controller]")]
    public class ErrorHandlingController : ControllerBase
    {
        public ApiResponse<String> HandleError()
        {
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = exceptionHandlerFeature!.Error;
            ApiResponse<String> response = new ApiResponse<String>();

            if (exception is NotFoundException notFoundException)
            {
                response.Status = true;
                response.Message = "Something went wronggggg";
                response.Data = null;
            }
            else if(exception is Test test)
            {
                response.Status = true;
                response.Message = "testtt";
                response.Data = null;
            }

            return response;
        }
    }
}
