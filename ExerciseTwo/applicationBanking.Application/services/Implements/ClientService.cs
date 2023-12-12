
using applicationBanking.Application.Commons.Utilities;
using ApplicationBanking.repository.Interfaces;
using ApplicationBanking.services.Interfaces;
using AutoMapper;
using System.Net;

namespace ApplicationBanking.services.Implements
{
    public class ClientService : IClientService
    {
        private readonly IclientRepository _clientRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public ClientService(IclientRepository clientRepository, IMapper mapper, IAccountRepository accountRepository)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _accountRepository = accountRepository;
        }

        public async Task<Dictionary<Enumeraciones.CodigosHttp, object>> AddClient(ClientDTO client)
        {
            Dictionary<Enumeraciones.CodigosHttp, object> result = new Dictionary<Enumeraciones.CodigosHttp, object>();

            try
            {
                var clientDTO = await _clientRepository.GetClientByIdentify(client.identify);

                if (clientDTO != null)
                {
                    result.Add(Enumeraciones.CodigosHttp.BadRequest, "El cliente ya existe");
                }
                else
                {
					client.id = Guid.NewGuid().ToString();

                    bool response = await _clientRepository.AddClient(_mapper.Map<Client>(client));

                    if (response)
                    {
                        result.Add(Enumeraciones.CodigosHttp.Ok, client);
                    }
                    else
                    {
                        result.Add(Enumeraciones.CodigosHttp.InternalServerError, "Error al crear el cliente");
                    }
                }
            }
            catch (Exception e)
            {
                result.Add(Enumeraciones.CodigosHttp.InternalServerError, e.Message);
            }

            return result;
        }

        public async Task<Dictionary<Enumeraciones.CodigosHttp, object>> DeleteClient(ClientDTO client)
        {
            Dictionary<Enumeraciones.CodigosHttp, object> result = new Dictionary<Enumeraciones.CodigosHttp, object>();

            try
            {
                ClientDTO clientDTO = _mapper.Map<ClientDTO>(_clientRepository.GetClientById(client.id));

                if (clientDTO == null)
                {
                    result.Add(Enumeraciones.CodigosHttp.NotFound, "El cliente no existe");
                }
                else
                {

                    var AccountsClient = await _accountRepository.GetAccountsByClientId(client.id);
                    
                    if(AccountsClient != null)
                    {
                        result.Add(Enumeraciones.CodigosHttp.BadRequest, $"El cliente {client.name} tiene cuentas asociadas, por lo cual no puede ser eliminado");
                    }
                    else
                    {
                        bool response = await _clientRepository.DeleteClient(_mapper.Map<Client>(clientDTO));

                        if (response)
                        {
                            result.Add(Enumeraciones.CodigosHttp.Ok, clientDTO);
                        }
                        else
                        {
                            result.Add(Enumeraciones.CodigosHttp.InternalServerError, "Error al eliminar el cliente");
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

        public async Task<Dictionary<Enumeraciones.CodigosHttp, object>> GetClientById(string id)
        {
            Dictionary<Enumeraciones.CodigosHttp, object> result = new Dictionary<Enumeraciones.CodigosHttp, object>();

            try
            {
                ClientDTO clientDTO = _mapper.Map<ClientDTO>(await _clientRepository.GetClientById(id));

                if (clientDTO == null)
                {
                    result.Add(Enumeraciones.CodigosHttp.NotFound, "El cliente no existe");
                }
                else
                {
                    result.Add(Enumeraciones.CodigosHttp.Ok, clientDTO);
                }
            }
            catch (Exception e)
            {
                result.Add(Enumeraciones.CodigosHttp.InternalServerError, e.Message);
            }

            return result;
        }

        public async Task<Dictionary<Enumeraciones.CodigosHttp, object>> GetClientByIdentify(string identify)
        {
            Dictionary<Enumeraciones.CodigosHttp, object> result = new Dictionary<Enumeraciones.CodigosHttp, object>();

            try
            {
                ClientDTO clientDTO = _mapper.Map<ClientDTO>(await _clientRepository.GetClientByIdentify(identify));

                if (clientDTO == null)
                {
                    result.Add(Enumeraciones.CodigosHttp.NotFound, "El cliente no existe");
                }
                else
                {
                    result.Add(Enumeraciones.CodigosHttp.Ok, clientDTO);
                }
            }
            catch (Exception e)
            {
                result.Add(Enumeraciones.CodigosHttp.InternalServerError, e.Message);
            }

            return result;
        }

        public async Task<Dictionary<Enumeraciones.CodigosHttp, object>> GetClients()
        {
            Dictionary<Enumeraciones.CodigosHttp, object> result = new Dictionary<Enumeraciones.CodigosHttp, object>();

            try
            {
                List<ClientDTO> clientsDTO = _mapper.Map<List<ClientDTO>>(await _clientRepository.GetClients());

                if (clientsDTO == null || clientsDTO.Count <= 0)
                {
                    result.Add(Enumeraciones.CodigosHttp.NotFound, "No existen clientes");
                }
                else
                {
                    result.Add(Enumeraciones.CodigosHttp.Ok, clientsDTO);
                }
            }
            catch (Exception e)
            {
                result.Add(Enumeraciones.CodigosHttp.InternalServerError, e.Message);
            }

            return result;
        }

        public async Task<Dictionary<Enumeraciones.CodigosHttp, object>> UpdateClient(ClientDTO client)
        {
            Dictionary<Enumeraciones.CodigosHttp, object> result = new Dictionary<Enumeraciones.CodigosHttp, object>();

            try
            {
                ClientDTO clientDTO = _mapper.Map<ClientDTO>(_clientRepository.GetClientById(client.id));

                if (clientDTO == null)
                {
                    result.Add(Enumeraciones.CodigosHttp.NotFound, "El cliente no existe");
                }
                else
                {
                    clientDTO.name = client.name;
                    clientDTO.identify = client.identify;

                    bool response = await _clientRepository.UpdateClient(_mapper.Map<Client>(clientDTO));

                    if (response)
                    {
                        result.Add(Enumeraciones.CodigosHttp.Ok, clientDTO);
                    }
                    else
                    {
                        result.Add(Enumeraciones.CodigosHttp.InternalServerError, "Error al actualizar el cliente");
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
