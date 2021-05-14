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
            Console.SetWindowSize(120, 40);

            /*
            // Product
            TestProductConstructors();
            TestProductToString();
            TestProductPropertyGetters();
            TestProductPropertySetters();
            //*/

            /*
            // Customer
            TestCustomerConstructors();
            TestCustomerToString();
            TestCustomerPropertyGetters();
            TestCustomerPropertySetters();
            //*/

            // ProductList
            //TestProductListConstructor();
            //TestProductListAdd();
            //TestProductListSaveAndFill();
            //TestProductListRemove();
            //TestProductEquals();
            //TestProductGetHashCode();
            //TestProductListIndexer();

            // CustomerList
            //TestCustomerListConstructor();
            //TestCustomerListAdd();
            //TestCustomerListSaveAndFill();
            //TestCustomerListRemove();
            //TestCustomerEquals();
            //TestCustomerGetHashCode();
            TestCustomerListIndexer();

            // Inheritence Tests
            //TestClothingConstructor();
            //TestGearConstructor();
            //TestProductEqualsWithInheritance();
            //TestProductGetHashCodeWithInheritance();
            //TestProductListSaveWithInheritance();

            Console.ReadLine();
        }

        #region ---Inheritance Tests---

        static void TestClothingConstructor()
        {
            Clothing c1 = new Clothing(3, "C100", "Running tights", 69.99M, 3, "pants", "womens", "large", "blue", "Lucy");

            Console.WriteLine("Testing clothing constructors");
            Console.WriteLine("Overloaded constructor.  Expecting 3, c100 etc \n" + c1.ToString());
            Console.WriteLine();
        }

        static void TestGearConstructor()
        {
            Gear g1 = new Gear(5, "G100", "Sky 10 Kayak", 1049M, 2, "paddle", "Eddyline", "plastic laminate", 32);

            Console.WriteLine("Testing clothing constructors");
            Console.WriteLine("Overloaded constructor.  Expecting 5, G100 etc \n" + g1.ToString());
            Console.WriteLine();
        }

        static void TestProductEqualsWithInheritance()
        {
            // these 2 objects should be equal.  They reference the same object.
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);
            Product p2 = new Product(1, "T100", "This is a test product", 100M, 10);
            Clothing c1 = new Clothing(3, "C100", "Running tights", 69.99M, 3, "pants", "womens", "large", "blue", "Lucy");
            Clothing c2 = new Clothing(3, "C100", "Running tights", 69.99M, 3, "pants", "womens", "large", "blue", "Lucy");
            Clothing c3 = new Clothing(3, "C100", "Running tights", 69.99M, 3, "not pants", "womens", "large", "blue", "Lucy");
            Gear g1 = new Gear(5, "G100", "Sky 10 Kayak", 1049M, 2, "paddle", "Eddyline", "plastic laminate", 32);
            Gear g2 = new Gear(5, "G100", "Sky 10 Kayak", 1049M, 2, "paddle", "Eddyline", "plastic laminate", 32);
            Gear g3 = new Gear(1, "T100", "This is a test product", 100M, 10, "paddle", "Eddyline", "plastic laminate", 32);

            Console.WriteLine("Testing product equals.");
            Console.WriteLine("2 products that have the same properties should be equal.  Expecting true. " + p1.Equals(p2));
            Console.WriteLine("2 clothing that have the same properties should be equal.  Expecting true. " + c1.Equals(c2));
            Console.WriteLine("2 gear that have the same properties should be equal.  Expecting true. " + g1.Equals(g2));
            Console.WriteLine("Product and Gear should not be equal.  Expecting false. " + p1.Equals(g3));

            Console.WriteLine("Testing product ==.");
            Console.WriteLine("2 products that have the same properties should be equal.  Expecting true. " + (p1 == p2));
            Console.WriteLine("2 clothing that have the same properties should be equal.  Expecting true. " + (c1 == c2));
            Console.WriteLine("2 gear that have the same properties should be equal.  Expecting true. " + (g1 == g2));
            Console.WriteLine("Product and Gear should not be equal.  Expecting false. " + (p1 == g3));
            Console.WriteLine("2 clothing that have the same product attributes should not be equal.  Expecting false. " + (c1 == c3));
            Console.WriteLine();

        }

        static void TestProductGetHashCodeWithInheritance()
        {
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);
            // these 2 objects should have the same hashcode.  The attribute values are all equal.
            Product p2 = new Product(1, "T100", "This is a test product", 100M, 10);
            // this one should have a unique hashcode
            Product p3 = new Product(3, "T300", "This is a test product 3", 300M, 30);
            Clothing c1 = new Clothing(3, "C100", "Running tights", 69.99M, 3, "pants", "womens", "large", "blue", "Lucy");
            Clothing c2 = new Clothing(3, "C100", "Running tights", 69.99M, 3, "pants", "womens", "large", "blue", "Lucy");
            Clothing c3 = new Clothing(3, "C100", "Running tights", 69.99M, 3, "not pants", "womens", "large", "blue", "Lucy");
            Gear g1 = new Gear(5, "G100", "Sky 10 Kayak", 1049M, 2, "paddle", "Eddyline", "plastic laminate", 32);
            Gear g2 = new Gear(5, "G100", "Sky 10 Kayak", 1049M, 2, "paddle", "Eddyline", "plastic laminate", 32);
            Gear g3 = new Gear(1, "T100", "This is a test product", 100M, 10, "paddle", "Eddyline", "plastic laminate", 32);

            Console.WriteLine("Testing product GetHashCode");
            Console.WriteLine("2 products that have the same properties should have the same hashcode.  Expecting true. " + (p1.GetHashCode() == p2.GetHashCode()));
            Console.WriteLine("2 products that have different properties should have different hashcodes.  Expecting false. " + (p1.GetHashCode() == p3.GetHashCode()));
            Console.WriteLine("2 clothing that have the same properties should have the same hashcode.  Expecting true. " + (c1.GetHashCode() == c2.GetHashCode()));
            Console.WriteLine("2 clothing that have different properties should have different hashcodes.  Expecting false. " + (c1.GetHashCode() == c3.GetHashCode()));
            Console.WriteLine("2 gear that have the same properties should have the same hashcode.  Expecting true. " + (g1.GetHashCode() == g2.GetHashCode()));
            Console.WriteLine("2 gear that have different properties should have different hashcodes.  Expecting false. " + (g1.GetHashCode() == g3.GetHashCode()));
            Console.WriteLine("product and gear that have same properties should have different hashcodes.  Expecting false. " + (p1.GetHashCode() == g3.GetHashCode()));
            Console.WriteLine();

            // this will fail before overriding GetHashCode
            HashSet<Product> set = new HashSet<Product>();
            set.Add(p1);
            set.Add(p3);
            set.Add(c1);
            set.Add(c3);
            set.Add(g1);
            set.Add(g3);
            Console.WriteLine("Testing product GetHashCode by using a hash set");
            Console.WriteLine("The hash set should be able to find a product with the same attributes.  Expecting true. " + set.Contains(p2));
            Console.WriteLine("The hash set should be able to find a clothing with the same attributes.  Expecting true. " + set.Contains(c2));
            Console.WriteLine("The hash set should be able to find a gear with the same attributes.  Expecting true. " + set.Contains(g2));

            Console.WriteLine();
        }

        static void TestProductListSaveWithInheritance()
        {
            ProductList list = new ProductList();
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);
            Product p2 = new Product(2, "T200", "This is a test product 2", 200M, 20);
            Clothing c1 = new Clothing(3, "C100", "Running tights", 69.99M, 3, "pants", "womens", "large", "blue", "Lucy");
            Clothing c2 = new Clothing(4, "C200", "Running tights", 69.99M, 4, "pants", "womens", "medium", "black", "Nike");
            Gear g1 = new Gear(5, "G100", "Sky 10 Kayak", 1049M, 2, "paddle", "Eddyline", "plastic laminate", 32);
            Gear g2 = new Gear(6, "G200", "Sting Ray Posi-Lok kayak paddle", 149.95m, 5, "paddle", "Aqua-Bound", "carbon shaft", 1.75);

            list.Add(p1);
            list += p2;
            list += c1;
            list += c2;
            list += g1;
            list += g2;
            list.Save();

            list = new ProductList();
            list.Fill();
            Console.WriteLine("Testing product list save and fill.");
            Console.WriteLine("After Fill Count.  Expecting 6. " + list.Count);
            Console.WriteLine("ToString.  Expect six products total, 2 clothing and 2 gear \n" + list.ToString());

            Console.WriteLine();
        }

        #endregion

        #region ---CustomerListTests---
        static void TestCustomerListConstructor()
        {
            CustomerList list = new CustomerList();

            Console.WriteLine("Testing customer list default constructor");
            Console.WriteLine("Count.  Expecting 0. " + list.Count);
            Console.WriteLine("ToString.  Expect an empty string. " + list.ToString());
            Console.WriteLine();
        }
                
        static void TestCustomerListAdd()
        {
            CustomerList list = new CustomerList();
            Customer c1 = new Customer(1, "Joe", "Abernathy", "jabernathy@email.com", "555-555-5555");
            Customer c2 = new Customer(2, "Jane", "Betelguese", "jbetelguese@email.com", "555-555-5555");

            Console.WriteLine("Testing customer list add.");
            Console.WriteLine("BEFORE Count.  Expecting 0. " + list.Count);
            list.Add(c1);
            Console.WriteLine("AFTER Add Count.  Expecting 1. " + list.Count);
            Console.WriteLine("ToString.  Expect one customer " + list.ToString());
            list += c2;
            Console.WriteLine("AFTER Second Add Count.  Expecting 2. " + list.Count);
            Console.WriteLine("ToString.  Expect two customers " + list.ToString());
            Console.WriteLine();

            // list = list + p2;
            // list = p2 + list;
        }

        static void TestCustomerListSaveAndFill()
        {
            CustomerList list = new CustomerList();
            Customer c1 = new Customer(1, "Joe", "Abernathy", "jabernathy@email.com", "555-555-5555");
            Customer c2 = new Customer(2, "Jane", "Betelguese", "jbetelguese@email.com", "555-555-5555");
            list.Add(c1);
            list += c2;
            list.Save();

            list = new CustomerList();
            list.Fill();
            Console.WriteLine("Testing customer list save and fill.");
            Console.WriteLine("After Fill Count.  Expecting 2. " + list.Count);
            Console.WriteLine("ToString.  Expect two customers: \n" + list.ToString());
            Console.WriteLine();
        }

        static void TestCustomerListRemove()
        {
            // test fails before I add equals to customer
            CustomerList list = new CustomerList();
            Customer c1 = new Customer(1, "Joe", "Abernathy", "jabernathy@email.com", "555-555-5555");
            Customer c2 = new Customer(2, "Jane", "Betelguese", "jbetelguese@email.com", "555-555-5555");

            list.Fill();
            Console.WriteLine("Testing customer list remove.");
            Console.WriteLine("Before remove Count.  Expecting 2. " + list.Count);
            Console.WriteLine("ToString.  Expect two customers: \n" + list.ToString());
            list.Remove(c1);
            Console.WriteLine("After remove Count.  Expecting 1. " + list.Count);
            Console.WriteLine("ToString.  Expect just customer 2: \n" + list.ToString());
            Console.WriteLine();

            // list = list - p1;
            // list -= p1;
        }
        
        static void TestCustomerEquals()
        {
            // these 2 objects should be equal.  They reference the same object.
            Customer c1 = new Customer(1, "Joe", "Abernathy", "jabernathy@email.com", "555-555-5555");
            Customer c1Reference = c1;
            // these 2 objects should be equal after overridding Equals.  The attribute values are all equal.
            Customer c2 = new Customer(1, "Joe", "Abernathy", "jabernathy@email.com", "555-555-5555");

            Console.WriteLine("Testing customer equals.");
            Console.WriteLine("2 references to the same object.  Expecting true. " + c1.Equals(c1Reference));
            Console.WriteLine("2 object that have the same properties should be equal.  Expecting true. " + c1.Equals(c2));
            Console.WriteLine();

            Console.WriteLine("Testing product ==");
            Console.WriteLine("2 references to the same object.  Expecting true. " + (c1 == c1Reference));
            Console.WriteLine("2 object that have the same properties should be equal.  Expecting true. " + (c1 == c2));
            Console.WriteLine();
        }

        static void TestCustomerGetHashCode()
        {
            Customer c1 = new Customer(1, "Joe", "Abernathy", "jabernathy@email.com", "555-555-5555");
            // these 2 objects should have the same hashcode.  The attribute values are all equal.
            Customer c2 = new Customer(1, "Joe", "Abernathy", "jabernathy@email.com", "555-555-5555");
            // this one should have a unique hashcode
            Customer c3 = new Customer(2, "Jane", "Betelguese", "jbetelguese@email.com", "555-555-5555");

            Console.WriteLine("Testing customer GetHashCode");
            Console.WriteLine("2 object that have the same properties should have the same hashcode.  Expecting true. " 
                + (c1.GetHashCode() == c2.GetHashCode()));
            Console.WriteLine("2 object that have different properties should have different hashcodes.  Expecting false. " 
                + (c1.GetHashCode() == c3.GetHashCode()));

            // this will fail before overriding GetHashCode
            HashSet<Customer> set = new HashSet<Customer>();
            set.Add(c1);
            set.Add(c3);
            Console.WriteLine("Testing product GetHashCode by using a hash set");
            Console.WriteLine("The hash set should be able to find an object with the same attributes.  Expecting true. " 
                + set.Contains(c2));

            Console.WriteLine();
        }

        static void TestCustomerListIndexer()
        {
            // test fails before I add equals to product
            CustomerList list = new CustomerList();
            list.Fill();

            Console.WriteLine("Testing customer list indexer");
            Console.WriteLine("Index 0.  Expecting first customer in list to be jabernathy@email.com \n" 
                + list[0]);
            Console.WriteLine("Index 'jbetelguese@email.com'.  Expecting customer with email of jbetelguese@email.com \n"
                + list["jbetelguese@email.com"]);
            Console.WriteLine();
        }

        #endregion

        #region ---ProductListTests---
        static void TestProductListConstructor()
        {
            ProductList list = new ProductList();

            Console.WriteLine("Testing product list default constructor");
            Console.WriteLine("Count.  Expecting 0. " + list.Count);
            Console.WriteLine("ToString.  Expect an empty string. " + list.ToString());
            Console.WriteLine();
        }

        static void TestProductListAdd()
        {
            ProductList list = new ProductList();
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);
            Product p2 = new Product(2, "T200", "This is a test product 2", 200M, 20);

            Console.WriteLine("Testing product list add.");
            Console.WriteLine("BEFORE Count.  Expecting 0. " + list.Count);
            list.Add(p1);
            Console.WriteLine("AFTER Add Count.  Expecting 1. " + list.Count);
            Console.WriteLine("ToString.  Expect one product " + list.ToString());
            list += p2;
            Console.WriteLine("AFTER Second Add Count.  Expecting 2. " + list.Count);
            Console.WriteLine("ToString.  Expect two products " + list.ToString());
            Console.WriteLine();

            // list = list + p2;
            // list = p2 + list;
        }

        static void TestProductListSaveAndFill()
        {
            ProductList list = new ProductList();
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);
            Product p2 = new Product(2, "T200", "This is a test product 2", 200M, 20);
            list.Add(p1);
            list += p2;
            list.Save();

            list = new ProductList();
            list.Fill();
            Console.WriteLine("Testing product list save and fill.");
            Console.WriteLine("After Fill Count.  Expecting 2. " + list.Count);
            Console.WriteLine("ToString.  Expect two products " + list.ToString());
            Console.WriteLine();
        }

        static void TestProductListRemove()
        {
            // test fails before I add equals to product
            ProductList list = new ProductList();
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);

            list.Fill();
            Console.WriteLine("Testing product list remove.");
            Console.WriteLine("Before remove Count.  Expecting 2. " + list.Count);
            Console.WriteLine("ToString.  Expect two products " + list.ToString());
            list.Remove(p1);
            Console.WriteLine("After remove Count.  Expecting 1. " + list.Count);
            Console.WriteLine("ToString.  Expect just product 2 " + list.ToString());
            Console.WriteLine();

            // list = list - p1;
            // list -= p1;
        }

        static void TestProductEquals()
        {
            // these 2 objects should be equal.  They reference the same object.
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);
            Product p1Reference = p1;
            // these 2 objects should be equal after overridding Equals.  The attribute values are all equal.
            Product p2 = new Product(1, "T100", "This is a test product", 100M, 10);

            Console.WriteLine("Testing product equals.");
            Console.WriteLine("2 references to the same object.  Expecting true. " + p1.Equals(p1Reference));
            Console.WriteLine("2 object that have the same properties should be equal.  Expecting true. " + p1.Equals(p2));
            Console.WriteLine();

            Console.WriteLine("Testing product ==");
            Console.WriteLine("2 references to the same object.  Expecting true. " + (p1 == p1Reference));
            Console.WriteLine("2 object that have the same properties should be equal.  Expecting true. " + (p1 == p2));
            Console.WriteLine();
        }

        static void TestProductGetHashCode()
        {
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);
            // these 2 objects should have the same hashcode.  The attribute values are all equal.
            Product p2 = new Product(1, "T100", "This is a test product", 100M, 10);
            // this one should have a unique hashcode
            Product p3 = new Product(3, "T300", "This is a test product 3", 300M, 30);

            Console.WriteLine("Testing product GetHashCode");
            Console.WriteLine("2 object that have the same properties should have the same hashcode.  Expecting true. " + (p1.GetHashCode() == p2.GetHashCode()));
            Console.WriteLine("2 object that have different properties should have different hashcodes.  Expecting false. " + (p1.GetHashCode() == p3.GetHashCode()));

            // this will fail before overriding GetHashCode
            HashSet<Product> set = new HashSet<Product>();
            set.Add(p1);
            set.Add(p3);
            Console.WriteLine("Testing product GetHashCode by using a hash set");
            Console.WriteLine("The hash set should be able to find an object with the same attributes.  Expecting true. " + set.Contains(p2));

            Console.WriteLine();
        }

        static void TestProductListIndexer()
        {
            // test fails before I add equals to product
            ProductList list = new ProductList();
            list.Fill();

            Console.WriteLine("Testing product list indexer");
            Console.WriteLine("Index 0.  Expecting first product in list to be T100 \n" + list[0]);
            Console.WriteLine("Index 'T200'.  Expecting product with code of T200 \n" + list["T200"]);
            Console.WriteLine();
        }

        #endregion

        #region ---Product Tests---
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
        #endregion

        #region ---Customer Tests---
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
        #endregion
    }
}
