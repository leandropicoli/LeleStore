using System;
using System.Collections.Generic;
using LeleStore.Domain.StoreContext.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LeleStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("customers")]
        public List<Customer> Get()
        {
            return new List<Customer>();
        }

        [HttpGet]
        [Route("customers/{id}")]
        public Customer GetById(Guid id)
        {
            return null;
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public List<Order> GetOrders(Guid id)
        {
            return null;
        }

        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody] Customer customer)
        {
            return customer;
        }

        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody] Customer customer)
        {
            return customer;
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public string Delete()
        {
            return null;
        }
    }
}