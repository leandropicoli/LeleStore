using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeleStore.Domain.StoreContext.Entities;
using LeleStore.Domain.StoreContext.ValueObjects;
using System.Linq;

namespace LeleStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Leandro", "Picoli");
            var document = new Document("123456748911");
            var email = new Email("leandro@leandro.com.br");
            var c = new Customer(name, document, email, "4899999999");
            var mouse = new Product("Mouse", "Rato", "image.pnc", 159.99M, 1.0M);
            var teclado = new Product("Teclado", "teclado", "image.pnc", 299.99M, 1.0M);
            var impressora = new Product("impressora", "impressora", "image.pnc", 359.99M, 1.0M);
            var cadeira = new Product("cadeira", "cadeira", "image.pnc", 599.99M, 1.0M);

            var order = new Order(c);
            // order.AddItem(new OrderItem(mouse, 1));
            // order.AddItem(new OrderItem(teclado, 1));
            // order.AddItem(new OrderItem(impressora, 1));
            // order.AddItem(new OrderItem(cadeira, 1));

            order.Place();

            var valid = order.IsValid;
            if (!valid)
            {
                Assert.Fail(order.Notifications.First().Message);
            }

            order.Pay();
            order.Ship();

            order.Cancel();
        }
    }
}
