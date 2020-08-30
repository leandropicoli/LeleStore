using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeleStore.Domain.StoreContext.ValueObjects;

namespace LeleStore.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        private Document invalidDocument;
        private Document validDocument;
        public DocumentTests()
        {
            invalidDocument = new Document("12345678910");
            validDocument = new Document("95846428045");
        }

        [TestMethod]
        public void ShouldReturnNotification_WhenDocumentIsNotValid()
        {
            Assert.IsFalse(invalidDocument.IsValid);
            Assert.AreEqual(1, invalidDocument.Notifications.Count);
        }

        [TestMethod]
        public void ShouldNotReturnNotification_WhenDocumentIsValid()
        {
            Assert.IsTrue(validDocument.IsValid);
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }
    }
}
