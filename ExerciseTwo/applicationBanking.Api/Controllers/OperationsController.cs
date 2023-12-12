using applicationBanking.Api.Models;
using applicationBanking.Application.Commons.Utilities;
using applicationBanking.Domain.Entities.Models;
using ApplicationBanking.Filters;
using ApplicationBanking.repository.Interfaces;
using ApplicationBanking.services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace applicationBanking.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	[ServiceFilter(typeof(ValidateJwtFilter))]
	public class OperationsController : ControllerBase
	{
		private readonly IAccountService _accountService;
		private readonly IAccountMovementService _accountMovementService;
		private readonly IClientService _clientService;
		private readonly IAccountMovementEntities _accountMovementEntities;
		private readonly IMapper _mapper;

		public OperationsController(IClientService clientService, IAccountService accountService, IAccountMovementService accountMovementService, IAccountMovementEntities accountMovementEntities, IMapper mapper)
		{
			_clientService = clientService;
			_accountService = accountService;
			_accountMovementService = accountMovementService;
			_accountMovementEntities = accountMovementEntities;
			_mapper = mapper;
		}

		[HttpGet]
		[Route("ObtenerClientes")]
		public async Task<IActionResult> ObtenerClientes()
		{
			string mensaje = "";
			var response = await _clientService.GetClients();
			var EnumResponse = Enumeraciones.GetEnumValueAttribute(response.Keys.FirstOrDefault());
			int code = int.Parse(EnumResponse.Value.FirstOrDefault());
			switch (code)
			{
				case 400:
					mensaje = response.Values.FirstOrDefault() as string;
					return BadRequest(new { mensaje = mensaje });
				case 200:
					var clientes = response.Values.FirstOrDefault() as List<ClientDTO>;
					return Ok(clientes);
				case 404:
					mensaje = response.Values.FirstOrDefault() as string;
					return NotFound(mensaje);
				default:
					mensaje = response.Values.FirstOrDefault() as string;
					return Problem(mensaje);

			}

		}

		[HttpGet]
		[Route("ObtenerClientesPorIdentificacion/{Identificacion}")]
		public async Task<IActionResult> ObtenerClientesPorIdentificacion(string Identificacion)
		{
			string mensaje = "";
			var response = await _clientService.GetClientByIdentify(Identificacion);
			var EnumResponse = Enumeraciones.GetEnumValueAttribute(response.Keys.FirstOrDefault());
			int code = int.Parse(EnumResponse.Value.FirstOrDefault());
			switch (code)
			{
				case 400:
					mensaje = response.Values.FirstOrDefault() as string;
					return BadRequest(new { mensaje = mensaje });
				case 200:
					var cliente = response.Values.FirstOrDefault() as ClientDTO;
					return Ok(cliente);
				case 404:
					mensaje = response.Values.FirstOrDefault() as string;
					return NotFound(mensaje);
				default:
					mensaje = response.Values.FirstOrDefault() as string;
					return Problem(mensaje);

			}

		}

		[HttpGet]
		[Route("ObtenerCuentas")]
		public async Task<IActionResult> ObtenerCuentas()
		{
			string mensaje = "";
			var response = await _accountService.GetAccounts();
			var EnumResponse = Enumeraciones.GetEnumValueAttribute(response.Keys.FirstOrDefault());
			int code = int.Parse(EnumResponse.Value.FirstOrDefault());
			switch (code)
			{
				case 400:
					mensaje = response.Values.FirstOrDefault() as string;
					return BadRequest(new { mensaje = mensaje });
				case 200:
					var cuentas = response.Values.FirstOrDefault() as List<AccountDTO>;
					return Ok(cuentas);
				case 404:
					mensaje = response.Values.FirstOrDefault() as string;
					return NotFound(mensaje);
				default:
					mensaje = response.Values.FirstOrDefault() as string;
					return Problem(mensaje);

			}

		}

		[HttpGet]
		[Route("ObtenerMovimientos")]
		public async Task<IActionResult> ObtenerMovimientos()
		{
			string mensaje = "";
			var response = await _accountMovementService.GetAccountMovements();
			var EnumResponse = Enumeraciones.GetEnumValueAttribute(response.Keys.FirstOrDefault());
			int code = int.Parse(EnumResponse.Value.FirstOrDefault());
			switch (code)
			{
				case 400:
					mensaje = response.Values.FirstOrDefault() as string;
					return BadRequest(new { mensaje = mensaje });
				case 200:
					var cuentas = response.Values.FirstOrDefault() as List<AccountMovementDTO>;
					return Ok(cuentas);
				case 404:
					mensaje = response.Values.FirstOrDefault() as string;
					return NotFound(mensaje);
				default:
					mensaje = response.Values.FirstOrDefault() as string;
					return Problem(mensaje);

			}

		}

		[HttpGet]
		[Route("ObtenerMovimientosPorCuentaId/{CuentaId}")]
		public async Task<IActionResult> ObtenerMovimientosPorCuentaId(string CuentaId)
		{
			string mensaje = "";
			var response = await _accountMovementService.GetAccountMovementsByAccountId(CuentaId);
			var EnumResponse = Enumeraciones.GetEnumValueAttribute(response.Keys.FirstOrDefault());
			int code = int.Parse(EnumResponse.Value.FirstOrDefault());
			switch (code)
			{
				case 400:
					mensaje = response.Values.FirstOrDefault() as string;
					return BadRequest(new { mensaje = mensaje });
				case 200:
					var cuentas = response.Values.FirstOrDefault() as List<AccountMovementDTO>;
					return Ok(cuentas);
				case 404:
					mensaje = response.Values.FirstOrDefault() as string;
					return NotFound(mensaje);
				default:
					mensaje = response.Values.FirstOrDefault() as string;
					return Problem(mensaje);

			}

		}

		[HttpGet]
		[Route("ObtenerCuentasPorClienteId/{Id}")]
		public async Task<IActionResult> ObtenerCuentasPorClienteId(string Id)
		{
			string mensaje = "";
			var response = await _accountService.GetAccountsByClientId(Id);
			var EnumResponse = Enumeraciones.GetEnumValueAttribute(response.Keys.FirstOrDefault());
			int code = int.Parse(EnumResponse.Value.FirstOrDefault());
			switch (code)
			{
				case 400:
					mensaje = response.Values.FirstOrDefault() as string;
					return BadRequest(new { mensaje = mensaje });
				case 200:
					var Cuenta = response.Values.FirstOrDefault() as List<AccountDTO>;
					return Ok(Cuenta);
				case 404:
					mensaje = response.Values.FirstOrDefault() as string;
					return NotFound(mensaje);
				default:
					mensaje = response.Values.FirstOrDefault() as string;
					return Problem(mensaje);

			}

		}

		[HttpPost]
		[Route("AdicionarCliente")]
		public async Task<IActionResult> AdicionarCliente(ClientModel client)
		{
			string mensaje = "";
			ClientDTO clientDTO = new ClientDTO();
			clientDTO.name = client.name;
			clientDTO.identify = client.identify;
			var response = await _clientService.AddClient(clientDTO);
			var EnumResponse = Enumeraciones.GetEnumValueAttribute(response.Keys.FirstOrDefault());
			int code = int.Parse(EnumResponse.Value.FirstOrDefault());
			switch (code)
			{
				case 400:
					mensaje = response.Values.FirstOrDefault() as string;
					return BadRequest(new { mensaje = mensaje });
				case 200:
					var Cliente = response.Values.FirstOrDefault() as ClientDTO;
					return Ok(Cliente);
				case 404:
					mensaje = response.Values.FirstOrDefault() as string;
					return NotFound(mensaje);
				default:
					mensaje = response.Values.FirstOrDefault() as string;
					return Problem(mensaje);

			}

		}

		[HttpPost]
		[Route("AdicionarCuenta")]
		public async Task<IActionResult> AdicionarCuenta(Accountmodel Account)
		{
			string mensaje = "";
			var response = await _clientService.GetClientByIdentify(Account.clientIdentification);
			var EnumResponse = Enumeraciones.GetEnumValueAttribute(response.Keys.FirstOrDefault());
			int code = int.Parse(EnumResponse.Value.FirstOrDefault());
			switch (code)
			{
				case 400:
					mensaje = response.Values.FirstOrDefault() as string;
					return BadRequest(new { mensaje = mensaje });
				case 200:
					var Cliente = response.Values.FirstOrDefault() as ClientDTO;
					AccountDTO accountDTO = new AccountDTO();
					accountDTO.clientId = Cliente.id;
					accountDTO.balance = Account.balance;
					accountDTO.type = Account.typeAccount;

					if (AddAccount(ref accountDTO, ref mensaje))
					{
						//se adiciona movimiento de apertura de cuenta
						AccountMovementDTO accountMovementDTO = new AccountMovementDTO();
						accountMovementDTO.type = "Apertura de cuenta";
						accountMovementDTO.amount = accountDTO.balance;
						accountMovementDTO.accountId = accountDTO.id;
						response = await _accountMovementService.AddAccountMovement(accountMovementDTO);
						EnumResponse = Enumeraciones.GetEnumValueAttribute(response.Keys.FirstOrDefault());
						code = int.Parse(EnumResponse.Value.FirstOrDefault());
						if(code == 200)
						{
							accountMovementDTO = response.Values.FirstOrDefault() as AccountMovementDTO;
						}
						else
						{
							mensaje = response.Values.FirstOrDefault() as string;
						}

						if (string.IsNullOrEmpty(accountMovementDTO.id))
						{
							return Problem("No fue posible adicionar el movimiento a la cuenta");
						}
						else
						{
							//reporte de movimiento apertura de cuenta
							response = await _accountMovementService.GetAccountMovementsByAccountId(accountDTO.id);
							EnumResponse = Enumeraciones.GetEnumValueAttribute(response.Keys.FirstOrDefault());
							code = int.Parse(EnumResponse.Value.FirstOrDefault());
							List<AccountMovementHistoryModel> accountMovementHistoryModels = new List<AccountMovementHistoryModel>();
							if (code == 200)
							{
								var movimientos = response.Values.FirstOrDefault() as List<AccountMovementDTO>;
								var cuenta = _mapper.Map<AccountModel>(accountDTO);
								accountMovementHistoryModels = _accountMovementEntities.GetAccountMovementsHistory(ref cuenta, _mapper.Map<List<AccountMovementModel>>(movimientos)).GetAwaiter().GetResult();
								return Ok(accountMovementHistoryModels);
							}
							else
							{
								mensaje = response.Values.FirstOrDefault() as string;
								return Problem(mensaje);
							}
						}

						
					}
					else
					{
						return Problem(mensaje);
					}

					
				case 404:
					mensaje = response.Values.FirstOrDefault() as string;
					return NotFound(mensaje);
				default:
					mensaje = response.Values.FirstOrDefault() as string;
					return Problem(mensaje);

			}

		}


		[HttpPost]
		[Route("AdicionarMovimiento")]
		public async Task<IActionResult> AdicionarMovimiento(AccountMovementsModel Account)
		{
			string mensaje = "";
			var response = await _accountService.GetAccountById(Account.accountId);
			var EnumResponse = Enumeraciones.GetEnumValueAttribute(response.Keys.FirstOrDefault());
			int code = int.Parse(EnumResponse.Value.FirstOrDefault());
			switch (code)
			{
				case 400:
					mensaje = response.Values.FirstOrDefault() as string;
					return BadRequest(new { mensaje = mensaje });
				case 200:
					var accountDTO = response.Values.FirstOrDefault() as AccountDTO;
					AccountMovementDTO accountMovementDTO = new AccountMovementDTO();
					accountMovementDTO.type = Account.type;
					accountMovementDTO.amount = Account.amount;
					accountMovementDTO.accountId = accountDTO.id;
					response = await _accountMovementService.AddAccountMovement(accountMovementDTO);
					EnumResponse = Enumeraciones.GetEnumValueAttribute(response.Keys.FirstOrDefault());
					code = int.Parse(EnumResponse.Value.FirstOrDefault());
					if (code == 200)
					{
						accountMovementDTO = response.Values.FirstOrDefault() as AccountMovementDTO;
					}
					else
					{
						mensaje = response.Values.FirstOrDefault() as string;
					}

					if (string.IsNullOrEmpty(accountMovementDTO.id))
					{
						return Problem("No fue posible adicionar el movimiento a la cuenta");
					}
					else
					{
						//reporte de movimiento apertura de cuenta
						response = await _accountMovementService.GetAccountMovementsByAccountId(accountDTO.id);
						EnumResponse = Enumeraciones.GetEnumValueAttribute(response.Keys.FirstOrDefault());
						code = int.Parse(EnumResponse.Value.FirstOrDefault());
						List<AccountMovementHistoryModel> accountMovementHistoryModels = new List<AccountMovementHistoryModel>();
						if (code == 200)
						{
							var movimientos = response.Values.FirstOrDefault() as List<AccountMovementDTO>;
							var cuenta = _mapper.Map<AccountModel>(accountDTO);
							accountMovementHistoryModels = _accountMovementEntities.GetAccountMovementsHistory(ref cuenta, _mapper.Map<List<AccountMovementModel>>(movimientos)).GetAwaiter().GetResult();
							return Ok(accountMovementHistoryModels);
						}
						else
						{
							mensaje = response.Values.FirstOrDefault() as string;
							return Problem(mensaje);
						}
					}

				case 404:
					mensaje = response.Values.FirstOrDefault() as string;
					return NotFound(mensaje);
				default:
					mensaje = response.Values.FirstOrDefault() as string;
					return Problem(mensaje);

			}

		}


		private bool AddAccount(ref AccountDTO accountDTO, ref string mensaje)
		{
			var response = _accountService.AddAccount(accountDTO).GetAwaiter().GetResult();
			var EnumResponse = Enumeraciones.GetEnumValueAttribute(response.Keys.FirstOrDefault());
			int code = int.Parse(EnumResponse.Value.FirstOrDefault());
			var cuenta = response.Values.FirstOrDefault() as AccountDTO;
			mensaje = code == 200 ? "" : response.Values.FirstOrDefault() as string;
			accountDTO = code == 200 ? cuenta : accountDTO;
			return code == 200;
		}
	}
}
