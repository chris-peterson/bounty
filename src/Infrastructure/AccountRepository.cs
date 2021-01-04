using System.Collections.Generic;
using bounty.Domain;
using LiteDB;

namespace Infrastructure
{
    public class AccountRepository : IAccountRepository
    {
        public IEnumerable<Account> GetAccounts()
        {
            using var context = TempDbContext();
            return context.GetCollection<Account>()
                .Query()
                .ToArray();
        }

        public void CreateAccount(Account account)
        {
            using var context = TempDbContext();
            var accounts = context
                .GetCollection<Account>();
            accounts.EnsureIndex(x => x.Name);
            accounts.Insert(account);
        }

        static ILiteDatabase TempDbContext() => new LiteDatabase("bounty.db");
    }
}
