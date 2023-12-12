using ApplicationBanking.repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationBanking.repository.Implements
{
    public class AccountRepository : IAccountRepository
    {
        private readonly bankingContext _context;

        public AccountRepository(bankingContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAccount(Account Account)
        {
            _context.Accounts.Add(Account);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAccount(Account Account)
        {
            _context.Accounts.Remove(Account);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Account> GetAccountById(string id)
        {
            Account Account = await _context.Accounts.Where(c => c.id == id).FirstOrDefaultAsync();
            return Account;
        }

        public async Task<List<Account>> GetAccountsByClientId(string ClientId)
        {
            return await _context.Accounts.Where(c => c.clientId == ClientId).ToListAsync();
        }

        public async Task<List<Account>> GetAccounts()
        {
            return await _context.Accounts.OrderByDescending(p => p.id).ToListAsync();
        }

        public async Task<bool> UpdateAccount(Account Account)
        {
            bool result = false;
            Account FindAccount = await _context.Accounts.Where(c => c.id == Account.id).FirstOrDefaultAsync();
            if (FindAccount != null)
            {
                FindAccount.balance = Account.balance;
                result = await _context.SaveChangesAsync() > 0;
            }

            return result;
        }
    }
}
