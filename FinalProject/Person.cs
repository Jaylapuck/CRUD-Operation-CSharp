using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        public override string ToString()
        {
            return "ID: " + this.Id + " | First Name: " + this.FirstName + " | Last Name: " + this.LastName + " | Age: " + this.Age + " | Email: " + this.Email + " | Phone Number: " + this.PhoneNumber + " |\n";
        }
    }
}
}
