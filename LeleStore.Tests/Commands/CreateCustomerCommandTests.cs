using LeleStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeleStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidate_WhenCommandIsValid()
        {
            var command = new CreateCustomerCommand()
            {
                FirstName = "Leandro",
                LastName = "Picoli",
                Email = "test@test.com",
                Document = "80118751085",
                Phone = "5548999991234"
            };

            Assert.IsTrue(command.Valid());
        }
    }
}