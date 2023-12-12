using applicationBanking.Domain.Entities.Models;

namespace ApplicationBanking.repository.Interfaces
{
    public interface IAccountMovementEntities
    {
		public Task<List<AccountMovementHistoryModel>> GetAccountMovementsHistory(ref AccountModel Account,List<AccountMovementModel> accountMovements);

    }
}
