using System;
using System.Globalization;
using Exercicio123.Entities;
using Exercicio123.Entities.Enum;

namespace Exercicio123
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data: ");
            Console.Write("Name: ");
            string nomeS = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime dN = DateTime.Parse(Console.ReadLine());

            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client cliente = new Client(nomeS, email, dN);
            Order pedido = new Order(DateTime.Now, status, cliente);

            Console.Write("How many items to this order? ");
            int qtn = int.Parse(Console.ReadLine());


            for (int i = 1; i <= qtn; i++)
            {
                Console.WriteLine("Enter #" + i + " item data:");
                Console.Write("Product name: ");
                string name = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product produto = new Product(name, price);

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                OrderItem lista = new OrderItem(quantity, price, produto);

                pedido.AddItem(lista);
            }

            Console.WriteLine(pedido);
        }
    }
}
