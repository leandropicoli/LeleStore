using System;
using System.Collections.Generic;
using LeleStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using LeleStore.Domain.StoreContext.Entities;
using LeleStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace LeleStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("customers")]
        public List<Customer> Get()
        {
            var name = new Name("Leandro", "Picoli");
            var document = new Document("95846428045");
            var email = new Email("test@test.com");
            var customer = new Customer(name, document, email, "5548999991234");
            var customers = new List<Customer>();
            customers.Add(customer);

            return customers;
        }

        [HttpGet]
        [Route("customers/{id}")]
        public Customer GetById(Guid id)
        {
            var name = new Name("Leandro", "Picoli");
            var document = new Document("95846428045");
            var email = new Email("test@test.com");
            var customer = new Customer(name, document, email, "5548999991234");

            return customer;
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public List<Order> GetOrders(Guid id)
        {
            var name = new Name("Leandro", "Picoli");
            var document = new Document("95846428045");
            var email = new Email("test@test.com");
            var customer = new Customer(name, document, email, "5548999991234");
            var order = new Order(customer);
            var mouse = new Product("Mouse Gamer", "Mouse Gamer", "mouse.jpg", 100M, 10);
            var keyboard = new Product("Keyboard", "Keyboard", "keyboard.jpg", 100M, 10);
            var chair = new Product("Gamming Chair", "Gamming Chair", "chair.jpg", 100M, 10);
            var monitor = new Product("Monitor", "Monitor", "monitor.jpg", 100M, 10);

            order.AddItem(mouse, 6);
            order.AddItem(keyboard, 5);

            var orders = new List<Order>();
            orders.Add(order);

            return orders;
        }

        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody] CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            return customer;
        }

        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody] CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            return customer;
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public object Delete()
        {
            return new { message = "Success." };
        }
    }
}