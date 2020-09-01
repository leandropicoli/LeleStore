using LeleStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using LeleStore.Domain.StoreContext.Handlers;
using LeleStore.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeleStore.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomer_WhenCommandIsValid()
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

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.IsTrue(handler.IsValid);
        }
    }
}