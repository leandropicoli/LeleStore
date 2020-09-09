using System;
using System.Collections.Generic;
using LeleStore.Domain.StoreContext.Entities;
using LeleStore.Domain.StoreContext.Queries;
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

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return new List<ListCustomerQueryResult>();
        }

        public GetCustomerQueryResult Get(Guid id)
        {
            return new GetCustomerQueryResult();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            return null;
        }

        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return new List<ListCustomerOrdersQueryResult>();
        }

        public void Save(Customer customer)
        {

        }
    }
}