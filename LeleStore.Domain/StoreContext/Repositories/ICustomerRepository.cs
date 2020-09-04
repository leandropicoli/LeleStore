using LeleStore.Domain.StoreContext.Entities;
using LeleStore.Domain.StoreContext.Queries;

namespace LeleStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        CustomerOrdersCountResult GetCustomerOrdersCount(string document);
    }
}