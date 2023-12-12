using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using ApplicationBanking.services.Interfaces;
using ApplicationBanking.Application.Models;

namespace ApplicationBanking.Filters
{
    public class ValidateJwtFilter:IActionFilter
    {
        private readonly IJwtService _jwtService;
        private readonly IConfiguration _configuration;
        public ValidateJwtFilter(IJwtService jwtService, IConfiguration configuration)
        {
            _jwtService = jwtService;
            _configuration = configuration;
        }
        public void OnActionExecuted(ActionExecutedContext context) { }


        public void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.GetTokenAsync("access_token").Result;
            JWT_Values jWT_Values = _configuration.GetSection("Jwt").Get<JWT_Values>();
            if (!_jwtService.validateToken(token, jWT_Values))
            {
                var unAuthorizedResult = new UnauthorizedObjectResult("Acceso denegado, su token ha vencido");
                context.Result = unAuthorizedResult;
            }
        }
    }
}
