namespace ApplicationBanking.repository.Interfaces
{
    public interface IAccountRepository
    {
        public Task<bool> AddAccount(Account Account);
        
        public Task<bool> UpdateAccount(Account client);

        public Task<bool> DeleteAccount(Account client);

        public Task<Account> GetAccountById(string id);

        public Task<List<Account>> GetAccountsByClientId(string ClientId);
        public Task<List<Account>> GetAccounts();
    }
}
