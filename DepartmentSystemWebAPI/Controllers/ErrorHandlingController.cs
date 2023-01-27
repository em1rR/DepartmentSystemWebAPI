using DepartmentSystemWebAPI.DTO;
using DepartmentSystemWebAPI.Entities;
using DepartmentSystemWebAPI.Exceptions;
using DepartmentSystemWebAPI.GenericDTO;
using DepartmentSystemWebAPI.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentSystemWebAPI.Controllers

{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[controller]")]
    public class ErrorHandlingController : ControllerBase
    {
        private IExceptionLogServices _exceptionLogServices;
        public ErrorHandlingController(IExceptionLogServices exceptionLogServices)
        {
            _exceptionLogServices = exceptionLogServices;
        }
        public async Task<ApiResponse<String>> HandleError()
        {
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = exceptionHandlerFeature!.Error;
            ApiResponse<String> response = new ApiResponse<String>();
            ApiResponse<ExceptionLog> exceptionLog = new ApiResponse<ExceptionLog>();

            //if (exception is NotFoundException notFoundException)
            //{
            //    response.Status = true;
            //    response.Message = "Something went wronggggg";
            //    response.Data = null;
            //}
            //else if(exception is Test test)
            //{
            //    response.Status = true;
            //    response.Message = "testtt";
            //    response.Data = null;
            //}
            if(exception != null)
            {
                response.Status = false;
                response.Message = exception.Message;
                response.Data = null;

                await _exceptionLogServices.PostException(exception);

                
            }

            return response;
        }
    }
}
