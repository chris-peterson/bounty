using System.Linq;
using bounty.Domain;
using Microsoft.AspNetCore.Mvc;

namespace bounty.WebService.Controllers
{
    [ApiController]
    public class TransactionController
    {
        readonly ITransactionRepository _transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpGet]
        [Route("transactions")]
        public Transaction[] GetTransactions(ushort accountId)
        {
            return _transactionRepository
                .GetTransactionsByAccount(accountId)
                .ToArray();
        }

        [HttpPost]
        [Route("transactions")]
        public void CreateTransaction(Transaction transaction)
        {
            _transactionRepository
                .SaveTransaction(transaction);
        }
    }
}
