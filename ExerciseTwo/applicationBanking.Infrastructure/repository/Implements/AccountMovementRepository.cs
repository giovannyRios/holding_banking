using ApplicationBanking.repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationBanking.repository.Implements
{
    public class AccountMovementRepository : IAccountMovementRepository
    {
        private readonly bankingContext _context;

        public AccountMovementRepository(bankingContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAccountMovement(AccountMovement AccountMovement)
        {
            _context.AccountMovements.Add(AccountMovement);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAccountMovement(AccountMovement AccountMovement)
        {
            _context.AccountMovements.Remove(AccountMovement);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<AccountMovement> GetAccountMovementById(string id)
        {
            AccountMovement AccountMovement = await _context.AccountMovements.Where(c => c.id == id).FirstOrDefaultAsync();
            return AccountMovement;
        }

        public async Task<List<AccountMovement>> GetAccountMovementsByAccountId(string AccountId)
        {
            return await _context.AccountMovements.Where(c => c.accountId == AccountId).ToListAsync();
        }

        public async Task<List<AccountMovement>> GetAccountMovementsByAccountIdAndDate(string AccountId, string date)
        {
            return await _context.AccountMovements.Where(c => c.accountId == AccountId && c.date == date).ToListAsync();
        }

        public async Task<List<AccountMovement>> GetAccountMovements()
        {
            return await _context.AccountMovements.OrderByDescending(p => p.date).ToListAsync();
        }

        public async Task<bool> UpdateAccountMovement(AccountMovement AccountMovement)
        {
            bool result = false;
            AccountMovement FindAccountMovement = await _context.AccountMovements.Where(c => c.id == AccountMovement.id).FirstOrDefaultAsync();
            if (FindAccountMovement != null)
            {
                FindAccountMovement.amount = AccountMovement.amount;
                FindAccountMovement.date = AccountMovement.date;
                FindAccountMovement.type = AccountMovement.type;
                result = await _context.SaveChangesAsync() > 0;
            }

            return result;
        }
    }
}
