using System.Collections.Generic;

namespace bounty.Domain
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
        void CreateAccount(Account account);
    }
}
