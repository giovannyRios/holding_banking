﻿using ApplicationBanking.Application.Models;
using ApplicationBanking.services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace applicationBanking.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly IJwtService _jwtService;

		public LoginController(IConfiguration configuration, IJwtService jwtService)
		{
			_configuration = configuration;
			_jwtService = jwtService;
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Login([FromBody] LoginDto datosLogin)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState.Values.SelectMany(x => x.Errors).Select(e => e.ErrorMessage).ToList());


			string token = "";
			//Usuario dummy, para una implementacion real se debe implementar DB, ActiveDirectory u otro repositorio de usuarios
			string usuario = datosLogin.user ?? "";
			string password = datosLogin.pass ?? "";
			if (usuario == _configuration.GetSection("AuthorizeUser").Value && password == _configuration.GetSection("AuthorizePass").Value)
			{
				var customClaims = new Dictionary<string, string>()
				{
					{ "Usuario",usuario }
				};

				token = _jwtService.generateToken(_configuration.GetSection("Jwt").Get<JWT_Values>(), customClaims);
			}

			if (string.IsNullOrEmpty(token))
			{
				return Unauthorized("Usuario o contraseña incorrectos");
			}

			return Ok(token);
		}
	}
}
