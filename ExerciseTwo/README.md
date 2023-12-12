# Estructura de Carpetas del Proyecto
 
.dockerignore 
ApplicationBanking.sln 
Dockerfile 
manualUsuarioDos.pdf 
applicationBanking.Api\applicationBanking.Api.csproj 
applicationBanking.Api\applicationBanking.Api.csproj.user 
applicationBanking.Api\appsettings.Development.json 
applicationBanking.Api\appsettings.json 
applicationBanking.Api\Program.cs 
applicationBanking.Api\Controllers\LoginController.cs 
applicationBanking.Api\Controllers\OperationsController.cs 
applicationBanking.Api\Filters\ValidateJwtFilter.cs 
applicationBanking.Api\Models\Accountmodel.cs 
applicationBanking.Api\Models\AccountMovementsModel.cs 
applicationBanking.Api\Models\ClientModel.cs 
applicationBanking.Api\Properties\launchSettings.json 
applicationBanking.Application\applicationBanking.Application.csproj 
applicationBanking.Application\Commons\Utilities\Enumeraciones.cs 
applicationBanking.Application\Models\JWT_Values.cs 
applicationBanking.Application\Models\LoginDto.cs 
applicationBanking.Application\services\Implements\AccountMovementService.cs 
applicationBanking.Application\services\Implements\AccountService.cs 
applicationBanking.Application\services\Implements\ClientService.cs 
applicationBanking.Application\services\Implements\JwtService.cs 
applicationBanking.Application\services\Interfaces\IAccountMovementService.cs 
applicationBanking.Application\services\Interfaces\IAccountService.cs 
applicationBanking.Application\services\Interfaces\IClientService.cs 
applicationBanking.Application\services\Interfaces\IJwtService.cs 
applicationBanking.Domain\applicationBanking.Domain.csproj 
applicationBanking.Domain\Entities\Implements\AccountMovementEntities.cs 
applicationBanking.Domain\Entities\Interfaces\IAccountMovementEntities.cs 
applicationBanking.Domain\Entities\Models\AccountModel.cs 
applicationBanking.Domain\Entities\Models\AccountMovementHistoryModel.cs 
applicationBanking.Domain\Entities\Models\AccountMovementModel.cs 
applicationBanking.Infrastructure\applicationBanking.Infrastructure.csproj 
applicationBanking.Infrastructure\Context\Account.cs 
applicationBanking.Infrastructure\Context\AccountMovement.cs 
applicationBanking.Infrastructure\Context\bankingContext.cs 
applicationBanking.Infrastructure\Context\Client.cs 
applicationBanking.Infrastructure\DTOs\AccountDTO.cs 
applicationBanking.Infrastructure\DTOs\AccountMovementDTO.cs 
applicationBanking.Infrastructure\DTOs\ClientDTO.cs 
applicationBanking.Infrastructure\Mapping\MapperConfig.cs 
applicationBanking.Infrastructure\Mapping\MappingProfile.cs 
applicationBanking.Infrastructure\repository\Implements\AccountMovementRepository.cs 
applicationBanking.Infrastructure\repository\Implements\AccountRepository.cs 
applicationBanking.Infrastructure\repository\Implements\ClientRepository.cs 
applicationBanking.Infrastructure\repository\Interfaces\IAccountMovementRepository.cs 
applicationBanking.Infrastructure\repository\Interfaces\IAccountRepository.cs 
applicationBanking.Infrastructure\repository\Interfaces\IClientRepository.cs 
applicationBanking.Infrastructure.IoC\applicationBanking.Infrastructure.IoC.csproj 
applicationBanking.Infrastructure.IoC\IoCRegister.cs 

# Solucion desplegada en Contenedores con docker y expuesta a traves de un tunel con cloudflared usando Open Api

Este proyecto implementado en un contenedor docker que se encuentra expuesto a través de un tunel cloudflared para su acceso en linea

* Url de acceso: https://asian-issue-meta-amendment.trycloudflare.com/swagger/index.html

# Manual de usuario

Para obtener instrucciones detalladas de como utilizar esta solución, se debe proceder a revisar el documento manualUsuarioDos.pdf adjunto en la solución.
