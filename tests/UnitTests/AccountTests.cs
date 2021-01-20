using bounty.Domain;
using bounty.Infrastructure;
using bounty.WebService.Controllers;
using Xunit;

namespace UnitTests
{
    public class AccountTests
    {
        [Fact]
        public void CanGetAccounts()
        {
            Assert.Empty(new AccountController(new CompositeRepository())
                .GetAccounts());
        }

        [Fact]
        public void CanCreateAccount()
        {
            var controller = new AccountController(new CompositeRepository());
            controller.CreateAccount(new Account());
        }
    }
}
