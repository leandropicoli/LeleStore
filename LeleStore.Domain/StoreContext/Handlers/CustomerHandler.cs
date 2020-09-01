using System;
using FluentValidator;
using LeleStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using LeleStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using LeleStore.Domain.StoreContext.Entities;
using LeleStore.Domain.StoreContext.Repositories;
using LeleStore.Domain.StoreContext.Services;
using LeleStore.Domain.StoreContext.ValueObjects;
using LeleStore.Shared.Commands;

namespace LeleStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>, ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Document it's already registred");

            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Email it's already registred");

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            var customer = new Customer(name, document, email, command.Phone);

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return null;

            _repository.Save(customer);

            _emailService.Send(email.Address, "hello@lelestore.com", "Welcome", "Welcome to Lele Store!");

            return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}