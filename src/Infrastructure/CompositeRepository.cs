using System.Collections.Generic;
using bounty.Domain;
using LiteDB;

namespace bounty.Infrastructure
{
    public class CompositeRepository :
        IAccountRepository,
        ITransactionRepository
    {
        public IEnumerable<Account> GetAccounts()
        {
            using var context = TempDbContext();
            return context.GetCollection<Account>()
                .Query()
                .ToArray();
        }

        public void SaveAccount(Account account)
        {
            using var context = TempDbContext();
            var accounts = context
                .GetCollection<Account>();
            accounts.EnsureIndex(x => x.Name);
            accounts.Insert(account);
        }

        public IEnumerable<Transaction> GetTransactionsByAccount(ushort accountId)
        {
            using var context = TempDbContext();
            return context.GetCollection<Transaction>()
                .Query()
                .Where(t => t.AccountId == accountId)
                .ToArray();
        }

        public void SaveTransaction(Transaction transaction)
        {
            using var context = TempDbContext();
            var transactions = context
                .GetCollection<Transaction>();
            transactions.EnsureIndex(x => x.AccountId);
            transactions.EnsureIndex(x => x.Category);
            transactions.EnsureIndex(x => x.Status);
            transactions.EnsureIndex(x => x.Payee);
            transactions.Insert(transaction);
        }

        static ILiteDatabase TempDbContext() => new LiteDatabase("bounty.db");
    }
}
