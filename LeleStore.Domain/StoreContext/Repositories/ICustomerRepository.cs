using LeleStore.Domain.StoreContext.Entities;

namespace LeleStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
    }
}