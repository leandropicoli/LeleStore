using System;
using LeleStore.Domain.StoreContext.Enums;

namespace LeleStore.Domain.StoreContext.Entities
{
    public class Delivery
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            //if estimated delivery date is in the past, dont delivery
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            //TODO: validate if already shipped
            Status = EDeliveryStatus.Canceled;
        }
    }
}