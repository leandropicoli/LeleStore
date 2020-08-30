using LeleStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeleStore.Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {

        [TestMethod]
        public void ShouldReturnNotification_WhenFirstNameIsEmpty()
        {
            var name = new Name("", "Picoli");
            Assert.IsFalse(name.IsValid);
            Assert.AreEqual(1, name.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnNotification_WhenLastNameIsEmpty()
        {
            var name = new Name("Leandro", "");
            Assert.IsFalse(name.IsValid);
            Assert.AreEqual(1, name.Notifications.Count);
        }
    }
}