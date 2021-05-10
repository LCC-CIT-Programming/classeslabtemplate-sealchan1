using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProductClasses
{
    public class Customer
    {
        #region ---Fields---
        private int id;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        #endregion

        #region ---Properties---
        /// <summary>
        /// Id - Customer identification number
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// FirstName - Customer first name
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        /// <summary>
        /// LastName - Customer last name
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        /// <summary>
        /// Email - Customer email
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// Phone - Customer phone
        /// </summary>
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        #endregion

        #region ---Constructors---
        /// <summary>
        /// Default constructor
        /// </summary>
        public Customer() 
        {
            firstName = "unknown";
            lastName = "unknown";
            email = "unknown";
            phone = "unknown";
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Customer id number</param>
        /// <param name="first">Customer first name</param>
        /// <param name="last">Customer last name</param>
        /// <param name="email">Customer email</param>
        /// <param name="phone">Customer phone number</param>
        public Customer(int id, string first, string last, string email, string phone)
        {
            this.id = id;
            firstName = first;
            lastName = last;
            this.email = email;
            this.phone = phone;
        }
        #endregion

        #region ---Overrides and Overloads---
        /// <summary>
        /// ToString() - Provides an override to the default ToString() method
        /// </summary>
        /// <returns>Customer first and last name combined</returns>
        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4}", id.ToString(), firstName, lastName, email, phone);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            else
            {
                Customer other = (Customer)obj;
                return other.Id == Id &&
                    other.FirstName == FirstName &&
                    other.LastName == LastName &&
                    other.Email == Email &&
                    other.Phone == Phone;
            }
        }

        public override int GetHashCode()
        {
            return 13 + 7 * id.GetHashCode() +
                7 * firstName.GetHashCode() +
                7 * lastName.GetHashCode() +
                7 * email.GetHashCode() +
                7 * phone.GetHashCode();
        }

        public static bool operator ==(Customer c1, Customer c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(Customer c1, Customer c2)
        {
            return !c1.Equals(c2);
        }

        #endregion
    }
}

