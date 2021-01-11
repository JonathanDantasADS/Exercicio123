using System;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using Exercicio123.Entities.Enum;


namespace Exercicio123.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Cliente { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client cliente) 
        {
            Moment = moment;
            Status = status;
            Cliente = cliente;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total() 
        {
            double total = 0.00;
                
            foreach (OrderItem item in Items) 
            {
                total = total + item.SubTotal();
            }
            return total;
        }

        public override string ToString()
        {
            StringBuilder screem = new StringBuilder();
            screem.AppendLine("ORDER SUMMARY:");
            screem.AppendLine("Order momento: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            screem.AppendLine("Order status: " + Status);
            screem.AppendLine("Cliente: " + Cliente);
            screem.AppendLine("Order items:");

            foreach (OrderItem item in Items) 
            {
                screem.AppendLine(item.ToString());
            }
            screem.AppendLine("Total Price:" + Total().ToString("F2", CultureInfo.InvariantCulture));
            return screem.ToString();
        }

    }
}
