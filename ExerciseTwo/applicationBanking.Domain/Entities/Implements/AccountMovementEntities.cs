using applicationBanking.Domain.Entities.Models;
using ApplicationBanking.repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace ApplicationBanking.repository.Implements
{
	public class AccountMovementEntities : IAccountMovementEntities
	{

		public Task<List<AccountMovementHistoryModel>> GetAccountMovementsHistory(ref AccountModel Account, List<AccountMovementModel> accountMovements)
		{
			List<AccountMovementHistoryModel> movements = new List<AccountMovementHistoryModel>();

			foreach (var AccountMovement in accountMovements)
			{
				AccountMovementHistoryModel accountMovementHistoryModel = new AccountMovementHistoryModel();
				
				if (Account.balance >= AccountMovement.amount && AccountMovement.type.Equals("Retiro"))
				{

					accountMovementHistoryModel.id = AccountMovement.id;

					accountMovementHistoryModel.accountId = AccountMovement.accountId;

					accountMovementHistoryModel.balance = Account.balance;
					
					Account.balance -= AccountMovement.amount;

					accountMovementHistoryModel.Endbalance = Account.balance;

					accountMovementHistoryModel.type = "Retiro";
					
					accountMovementHistoryModel.amount = AccountMovement.amount;

					accountMovementHistoryModel.date = DateTime.Now.ToShortDateString();

					movements.Add(accountMovementHistoryModel);

				}
				else 
				{
					if (AccountMovement.type.Equals("Consignación"))
					{

						accountMovementHistoryModel.id = AccountMovement.id;

						accountMovementHistoryModel.accountId = AccountMovement.accountId;

						accountMovementHistoryModel.balance = Account.balance;

						Account.balance += AccountMovement.amount;

						accountMovementHistoryModel.Endbalance = Account.balance;

						accountMovementHistoryModel.type = "Consignación";

						accountMovementHistoryModel.amount = AccountMovement.amount;

						accountMovementHistoryModel.date = DateTime.Now.ToShortDateString();

						movements.Add(accountMovementHistoryModel);

					}
					else
					{
						accountMovementHistoryModel.id = AccountMovement.id;

						accountMovementHistoryModel.accountId = AccountMovement.accountId;

						accountMovementHistoryModel.balance = Account.balance;

						Account.balance = AccountMovement.amount;

						accountMovementHistoryModel.Endbalance = Account.balance;

						accountMovementHistoryModel.type = "Apertura de cuenta";

						accountMovementHistoryModel.amount = AccountMovement.amount;

						accountMovementHistoryModel.date = AccountMovement.date.ToString();

						movements.Add(accountMovementHistoryModel);

					}
				}

				
			}

			return Task.FromResult(movements.OrderByDescending(c => c.date).ToList());

		}
	}
}
