using System.Linq;
using bounty.Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [ApiController]
    public class AccountController
    {
        readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        [Route("accounts")]
        public Account[] GetAccounts()
        {
            return _accountRepository
                .GetAccounts()
                .ToArray();
        }

        [HttpPost]
        [Route("accounts")]
        public void CreateAccount(Account account)
        {
            _accountRepository.CreateAccount(account);
        }
    }
}
