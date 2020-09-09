using System;
using System.Collections.Generic;
using LeleStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using LeleStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using LeleStore.Domain.StoreContext.Entities;
using LeleStore.Domain.StoreContext.Handlers;
using LeleStore.Domain.StoreContext.Queries;
using LeleStore.Domain.StoreContext.Repositories;
using LeleStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace LeleStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;
        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/customers")]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _repository.Get(id);
        }

        [HttpGet]
        [Route("v1/customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("v1/customers")]
        public ActionResult<CreateCustomerCommandResult> Post([FromBody] CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)_handler.Handle(command);
            if (_handler.Invalid)
                return BadRequest(_handler.Notifications);

            return result;
        }

        [HttpPut]
        [Route("v1/customers/{id}")]
        public Customer Put([FromBody] CreateCustomerCommand command)
        {
            //TODO: Create put customer

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            return customer;
        }

        [HttpDelete]
        [Route("v1/customers/{id}")]
        public object Delete()
        {
            //TODO: Create delete customer

            return new { message = "Not implemented yet." };
        }
    }
}