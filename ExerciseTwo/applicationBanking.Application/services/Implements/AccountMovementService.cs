using applicationBanking.Application.Commons.Utilities;
using ApplicationBanking.repository.Implements;
using ApplicationBanking.repository.Interfaces;
using ApplicationBanking.services.Interfaces;
using AutoMapper;

namespace ApplicationBanking.services.Implements
{
	public class AccountMovementService : IAccountMovementService
	{
		private readonly IAccountRepository _accountRepository;
		private readonly IAccountMovementRepository _accountMovementRepository;
		private readonly IMapper _mapper;

		public AccountMovementService(IAccountRepository accountRepository, IMapper mapper, IAccountMovementRepository accountMovementRepository)
		{
			_accountRepository = accountRepository;
			_mapper = mapper;
			_accountMovementRepository = accountMovementRepository;
		}
		public async Task<Dictionary<Enumeraciones.CodigosHttp, object>> AddAccountMovement(AccountMovementDTO AccountMovement)
		{
			Dictionary<Enumeraciones.CodigosHttp, object> result = new Dictionary<Enumeraciones.CodigosHttp, object>();

			try
			{
				var account = await _accountRepository.GetAccountById(AccountMovement.accountId);
				

				if (account == null)
				{
					result.Add(Enumeraciones.CodigosHttp.BadRequest, "La cuenta a la que quiere asociar un movimiento no existe");

				}
				else
				{
					if (account.balance < AccountMovement.amount && AccountMovement.type.Equals("Retiro"))
					{
						result.Add(Enumeraciones.CodigosHttp.BadRequest, "no cuenta con el saldo suficiente para realizar el movimiento");
					}
					else
					{
						if (AccountMovement.type.Equals("Retiro"))
						{
							account.balance -= AccountMovement.amount;
						}
						else 
						{
							if (AccountMovement.type.Equals("Consignación")) 
							{
								account.balance += AccountMovement.amount;
							}
							
						}

						bool response = false;

						if (!AccountMovement.type.Equals("Apertura de cuenta"))
						{
							response = await _accountRepository.UpdateAccount(account);

							if (response && (AccountMovement.type.Equals("Consignación") || AccountMovement.type.Equals("Retiro")))
							{

								AccountMovement.id = Guid.NewGuid().ToString();
								AccountMovement.date = DateTime.Now.ToShortDateString();

								response = await _accountMovementRepository.AddAccountMovement(_mapper.Map<AccountMovement>(AccountMovement));
								if (response)
								{
									result.Add(Enumeraciones.CodigosHttp.Ok, AccountMovement);
								}
								else
								{
									result.Add(Enumeraciones.CodigosHttp.InternalServerError, "Error al adicionar el movimiento");
								}
							}
							else
							{
								result.Add(Enumeraciones.CodigosHttp.InternalServerError, "Error al actualizar el saldo de la cuenta");
							}
						}
						else
						{
							AccountMovement.id = Guid.NewGuid().ToString();
							AccountMovement.date = DateTime.Now.ToString("dd/MM/yyyy");

							response = await _accountMovementRepository.AddAccountMovement(_mapper.Map<AccountMovement>(AccountMovement));
							if (response)
							{
								result.Add(Enumeraciones.CodigosHttp.Ok, AccountMovement);
							}
							else
							{
								result.Add(Enumeraciones.CodigosHttp.InternalServerError, "Error al adicionar el movimiento");
							}
						}
						
					}
				}
			}
			catch (Exception e)
			{
				result.Add(Enumeraciones.CodigosHttp.InternalServerError, e.Message);
			}

			return result;
		}

		public async Task<Dictionary<Enumeraciones.CodigosHttp, object>> GetAccountMovementById(string id)
		{
			Dictionary<Enumeraciones.CodigosHttp, object> result = new Dictionary<Enumeraciones.CodigosHttp, object>();

			try
			{
				AccountMovementDTO accountMovementDTO = _mapper.Map<AccountMovementDTO>(await _accountMovementRepository.GetAccountMovementById(id));

				if (accountMovementDTO == null)
				{
					result.Add(Enumeraciones.CodigosHttp.NotFound, "El movimiento no existe");
				}
				else
				{
					result.Add(Enumeraciones.CodigosHttp.Ok, accountMovementDTO);
				}
			}
			catch (Exception e)
			{
				result.Add(Enumeraciones.CodigosHttp.InternalServerError, e.Message);
			}

			return result;

		}

		public async Task<Dictionary<Enumeraciones.CodigosHttp, object>> GetAccountMovements()
		{
			Dictionary<Enumeraciones.CodigosHttp, object> result = new Dictionary<Enumeraciones.CodigosHttp, object>();

			try
			{
				var accountMovement = await _accountMovementRepository.GetAccountMovements();
				

				if (accountMovement == null)
				{
					result.Add(Enumeraciones.CodigosHttp.NotFound, "No existen movimientos");
				}
				else
				{
					List<AccountMovementDTO> accountMovementDTOs = _mapper.Map<List<AccountMovementDTO>>(accountMovement);
					result.Add(Enumeraciones.CodigosHttp.Ok, accountMovementDTOs);
				}
			}
			catch (Exception e)
			{
				result.Add(Enumeraciones.CodigosHttp.InternalServerError, e.Message);
			}

			return result;

		}

		public async Task<Dictionary<Enumeraciones.CodigosHttp, object>> GetAccountMovementsByAccountId(string AccountId)
		{
			Dictionary<Enumeraciones.CodigosHttp, object> result = new Dictionary<Enumeraciones.CodigosHttp, object>();

			try
			{
				List<AccountMovementDTO> accountMovementDTOs = new List<AccountMovementDTO>();

				var listaMovimientos = await _accountMovementRepository.GetAccountMovementsByAccountId(AccountId);

				if (listaMovimientos == null)
				{
					result.Add(Enumeraciones.CodigosHttp.NotFound, "No existen movimientos");
				}
				else
				{
					accountMovementDTOs = _mapper.Map<List<AccountMovementDTO>>(listaMovimientos);
					result.Add(Enumeraciones.CodigosHttp.Ok, accountMovementDTOs);
				}
			}
			catch (Exception e)
			{
				result.Add(Enumeraciones.CodigosHttp.InternalServerError, e.Message);
			}

			return result;
		}

		public async Task<Dictionary<Enumeraciones.CodigosHttp, object>> GetAccountMovementsByAccountIdAndDate(string AccountId, string date)
		{
			Dictionary<Enumeraciones.CodigosHttp, object> result = new Dictionary<Enumeraciones.CodigosHttp, object>();

			try
			{
				List<AccountMovementDTO> accountMovementDTOs = _mapper.Map<List<AccountMovementDTO>>(await _accountMovementRepository.GetAccountMovementsByAccountIdAndDate(AccountId, date));

				if (accountMovementDTOs == null)
				{
					result.Add(Enumeraciones.CodigosHttp.NotFound, "No existen movimientos");
				}
				else
				{
					result.Add(Enumeraciones.CodigosHttp.Ok, accountMovementDTOs);
				}
			}
			catch (Exception e)
			{
				result.Add(Enumeraciones.CodigosHttp.InternalServerError, e.Message);
			}

			return result;
		}
	}
}
