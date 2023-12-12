namespace ApplicationBanking.repository.Interfaces
{
    public interface IAccountMovementRepository
    {

        public Task<bool> AddAccountMovement(AccountMovement AccountMovement);

        public Task<bool> UpdateAccountMovement(AccountMovement AccountMovement);

        public Task<bool> DeleteAccountMovement(AccountMovement AccountMovement);

        public Task<AccountMovement> GetAccountMovementById(string id);

        public Task<List<AccountMovement>> GetAccountMovementsByAccountId(string AccountId);

        public Task<List<AccountMovement>> GetAccountMovementsByAccountIdAndDate(string AccountId, string date);
        public Task<List<AccountMovement>> GetAccountMovements();
    }
}
