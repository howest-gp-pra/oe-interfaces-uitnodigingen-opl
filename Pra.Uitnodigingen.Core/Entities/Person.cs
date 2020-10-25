using System;
using System.Collections.Generic;
using System.Text;
using Pra.Uitnodigingen.Core.Enumerations;

namespace Pra.Uitnodigingen.Core.Entities
{
    public class Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }

        public Person(string firstName, string lastName, string address, string town, Gender gender)
        {
            LastName = lastName;
            FirstName = firstName;
            Address = address;
            Town = town;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }
        public virtual string ShowInfo()
        {
            return "";
        }
    }
}
