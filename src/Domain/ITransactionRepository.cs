using System.Collections.Generic;

namespace bounty.Domain
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetTransactionsByAccount(ushort accountId);
        void SaveTransaction(Transaction transaction);
    }
}
