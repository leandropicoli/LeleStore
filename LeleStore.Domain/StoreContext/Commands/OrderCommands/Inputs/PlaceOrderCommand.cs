using System;
using System.Collections.Generic;
using FluentValidator;
using FluentValidator.Validation;
using LeleStore.Shared.Commands;

namespace LeleStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }
        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .HasLen(Customer.ToString(), 36, "Customer", "Invalid customer identifier")
                .IsGreaterThan(OrderItems.Count, 0, "OrderItems", "No order item founded")
            );

            return IsValid;
        }
    }

    public class OrderItemCommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}