using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CustomerProductClasses;

namespace CustomerProductTests
{
    class Program
    {
        static void Main(string[] args)
        {
            // Product
            TestProductConstructors();
            TestProductToString();
            TestProductPropertyGetters();
            TestProductPropertySetters();

            // Customer
            TestCustomerConstructors();
            TestCustomerToString();
            TestCustomerPropertyGetters();
            TestCustomerPropertySetters();

            Console.ReadLine();
        }

        static void TestProductConstructors()
        {
            Product p1 = new Product();
            Product p2 = new Product(1, "T100", "This is a test product", 100M, 10);

            Console.WriteLine("Testing both constructors");
            Console.WriteLine("Default constructor.  Expecting default values. " + p1.ToString());
            Console.WriteLine("Overloaded constructor.  Expecting 1, T100, 100, This is a test product, 10 " + p2.ToString());
            Console.WriteLine();
        }

        static void TestProductToString()
        {
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);

            Console.WriteLine("Testing ToString");
            Console.WriteLine("Expecting 1, T100, 100, This is a test product, 10 " + p1.ToString());
            Console.WriteLine("Expecting 1, T100, 100, This is a test product, 10 " + p1);
            Console.WriteLine();
        }

        static void TestProductPropertyGetters()
        {
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);

            Console.WriteLine("Testing getters");
            Console.WriteLine("Id.  Expecting 1. " + p1.Id);
            Console.WriteLine("Code.  Expecting T100. " + p1.Code);
            Console.WriteLine("Description.  Expecting This is a test product. " + p1.Description);
            Console.WriteLine("Price.  Expecting 100. " + p1.UnitPrice);
            Console.WriteLine("Quantity.  Expecting 10. " + p1.QuantityOnHand);
            Console.WriteLine();
        }

        static void TestProductPropertySetters()
        {
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);

            Console.WriteLine("Testing setters");
            p1.Id = 2;
            p1.Code = "T000";
            p1.Description = "First product";
            p1.UnitPrice = 200;
            p1.QuantityOnHand = 20;
            Console.WriteLine("Expecting 2, T000, 200, First product, 20 " + p1);
            Console.WriteLine();
        }

        static void TestCustomerConstructors()
        {
            Customer p1 = new Customer();
            Customer p2 = new Customer(1, "Abby", "Armstrong", "aarmstrong@strong.com", "555-555-5555");

            Console.WriteLine("Testing both constructors");
            Console.WriteLine("Default constructor.  Expecting default values. " + p1.ToString());
            Console.WriteLine("Overloaded constructor.  Expecting 1 Abby Armstrong aarmstrong@strong.com 555-555-5555 : " + p2.ToString());
            Console.WriteLine();
        }

        static void TestCustomerToString()
        {
            Customer p1 = new Customer(1, "Abby", "Armstrong", "aarmstrong@strong.com", "555-555-5555");

            Console.WriteLine("Testing ToString");
            Console.WriteLine("Expecting 1 Abby Armstrong aarmstrong@strong.com 555-555-5555 : " + p1.ToString());
            Console.WriteLine("Expecting 1 Abby Armstrong aarmstrong@strong.com 555-555-5555 : " + p1);
            Console.WriteLine();
        }

        static void TestCustomerPropertyGetters()
        {
            Customer p1 = new Customer(1, "Abby", "Armstrong", "aarmstrong@strong.com", "555-555-5555");

            Console.WriteLine("Testing getters");
            Console.WriteLine("Id.  Expecting 1. " + p1.Id);
            Console.WriteLine("FirstName.  Expecting Abby. " + p1.FirstName);
            Console.WriteLine("LastName.  Expecting Armstrong. " + p1.LastName);
            Console.WriteLine("Email.  Expecting aarmstrong@strong.com. " + p1.Email);
            Console.WriteLine("Phone.  Expecting 555-555-5555. " + p1.Phone);
            Console.WriteLine();
        }

        static void TestCustomerPropertySetters()
        {
            Customer p1 = new Customer(1, "Abby", "Armstrong", "aarmstrong@strong.com", "555-555-5555");

            Console.WriteLine("Testing setters");
            p1.Id = 2;
            p1.FirstName = "Bart";
            p1.LastName = "Barnstorm";
            p1.Email = "bbarnstorm@storm.com";
            p1.Phone = "777-777-7777";
            Console.WriteLine("Expecting 2, Bart, Barnstorm, bbarnstorm@storm.com, 777-777-7777 : " + p1);
            Console.WriteLine();
        }
    }
}
