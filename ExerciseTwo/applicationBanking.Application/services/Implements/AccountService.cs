
using applicationBanking.Application.Commons.Utilities;
using ApplicationBanking.repository.Interfaces;
using ApplicationBanking.services.Interfaces;
using AutoMapper;

namespace ApplicationBanking.services.Implements
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _AccountRepository;
        private readonly IclientRepository _clientRepository;
        private readonly IAccountMovementRepository _accountMovementRepository;
        private readonly IMapper _mapper;

        public AccountService(IclientRepository clientRepository, IMapper mapper, IAccountRepository accountRepository, IAccountMovementRepository accountMovementRepository)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _AccountRepository = accountRepository;
            _accountMovementRepository = accountMovementRepository;
        }
        public async Task<Dictionary<Enumeraciones.CodigosHttp, object>> AddAccount(AccountDTO Account)
        {
            Dictionary<Enumeraciones.CodigosHttp, object> result = new Dictionary<Enumeraciones.CodigosHttp, object>();

            try
            {
				var findClient = await _clientRepository.GetClientById(Account.clientId);

                if (findClient == null)
                {
                    result.Add(Enumeraciones.CodigosHttp.BadRequest, "El cliente al cual quiere asociarle una cuenta, no existe");

                }
                else
                {
                    var findAccount = await _AccountRepository.GetAccountById(Account.id);

                    if (findAccount != null)
                    {
                        result.Add(Enumeraciones.CodigosHttp.BadRequest, "La cuenta ya existe");
                    }
                    else
                    {

						Account.id = Guid.NewGuid().ToString();

                        bool response = await _AccountRepository.AddAccount(_mapper.Map<Account>(Account));

                        if (response)
                        {
                            result.Add(Enumeraciones.CodigosHttp.Ok, Account);
                        }
                        else
                        {
                            result.Add(Enumeraciones.CodigosHttp.InternalServerError, "Error al crear la cuenta");
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

        public async Task<Dictionary<Enumeraciones.CodigosHttp, object>> DeleteAccount(AccountDTO Account)
        {
            Dictionary<Enumeraciones.CodigosHttp, object> result = new Dictionary<Enumeraciones.CodigosHttp, object>();

            try
            {
                AccountDTO accountDTO = _mapper.Map<AccountDTO>(_AccountRepository.GetAccountById(Account.id));

                if (accountDTO == null)
                {
                    result.Add(Enumeraciones.CodigosHttp.BadRequest, "La cuenta no existe");
                }
                else
                {
                    if (accountDTO.balance > 0)
                    {
                        result.Add(Enumeraciones.CodigosHttp.InternalServerError, "La cuenta no puede ser eliminada porque tiene saldo, retire el saldo antes de eliminar");
                    }
                    else
                    {
                        bool response = await _AccountRepository.DeleteAccount(_mapper.Map<Account>(accountDTO));

                        if (response)
                        {
                            result.Add(Enumeraciones.CodigosHttp.Ok, "Cuenta eliminada correctamente");
                        }
                        else
                        {
                            result.Add(Enumeraciones.CodigosHttp.InternalServerError, "Error al eliminar la cuenta");
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

        public async Task<Dictionary<Enumeraciones.CodigosHttp, object>> GetAccountById(string id)
        {
            Dictionary<Enumeraciones.CodigosHttp, object> result = new Dictionary<Enumeraciones.CodigosHttp, object>();

            try
            {
                var account = await _AccountRepository.GetAccountById(id);

                if (account == null)
                {
                    result.Add(Enumeraciones.CodigosHttp.BadRequest, "La cuenta no existe");
                }
                else
                {
					AccountDTO accountDTO = _mapper.Map<AccountDTO>(account);
					result.Add(Enumeraciones.CodigosHttp.Ok, accountDTO);
                }
            }
            catch (Exception e)
            {
                result.Add(Enumeraciones.CodigosHttp.InternalServerError, e.Message);
            }

            return result;
        }

        public async Task<Dictionary<Enumeraciones.CodigosHttp, object>> GetAccounts()
        {
            Dictionary<Enumeraciones.CodigosHttp, object> result = new Dictionary<Enumeraciones.CodigosHttp, object>();

            try
            {
				List<AccountDTO> accountDTOs = new List<AccountDTO>();
				var Accounts = await _AccountRepository.GetAccounts();

				if (Accounts == null)
                {
                    result.Add(Enumeraciones.CodigosHttp.BadRequest, "No existen cuentas");
                }
                else
                {
				    accountDTOs = _mapper.Map<List<AccountDTO>>(Accounts);
					result.Add(Enumeraciones.CodigosHttp.Ok, accountDTOs);
                }
            }
            catch (Exception e)
            {
                result.Add(Enumeraciones.CodigosHttp.InternalServerError, e.Message);
            }

            return result;
        }

        public async Task<Dictionary<Enumeraciones.CodigosHttp, object>> GetAccountsByClientId(string ClientId)
        {
            Dictionary<Enumeraciones.CodigosHttp, object> result = new Dictionary<Enumeraciones.CodigosHttp, object>();

            try
            {
                var accounts = await _AccountRepository.GetAccountsByClientId(ClientId);

                if (accounts == null)
                {
                    result.Add(Enumeraciones.CodigosHttp.BadRequest, $"No existen cuentas asociadas al cliente");
                }
                else
                {
					List<AccountDTO> accountDTOs = _mapper.Map<List<AccountDTO>>(accounts);
					result.Add(Enumeraciones.CodigosHttp.Ok, accountDTOs);
                }
            }
            catch (Exception e)
            {
                result.Add(Enumeraciones.CodigosHttp.InternalServerError, e.Message);
            }

            return result;
        }

        public async Task<Dictionary<Enumeraciones.CodigosHttp, object>> UpdateAccount(AccountDTO Account)
        {
            Dictionary<Enumeraciones.CodigosHttp, object> result = new Dictionary<Enumeraciones.CodigosHttp, object>();

            try
            {
                AccountDTO accountDTO = _mapper.Map<AccountDTO>(_AccountRepository.GetAccountById(Account.id));

                if (accountDTO == null)
                {
                    result.Add(Enumeraciones.CodigosHttp.BadRequest, "La cuenta no existe");
                }
                else
                {
                    bool response = await _AccountRepository.UpdateAccount(_mapper.Map<Account>(accountDTO));

                    if (response)
                    {
                        result.Add(Enumeraciones.CodigosHttp.Ok, accountDTO);
                    }
                    else
                    {
                        result.Add(Enumeraciones.CodigosHttp.InternalServerError, "Error al actualizar la cuenta");
                    }
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
