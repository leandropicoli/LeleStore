using LeleStore.Domain.StoreContext.Entities;
using LeleStore.Domain.StoreContext.Repositories;

namespace LeleStore.Tests.Fakes
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public void Save(Customer customer)
        {

        }
    }
}