using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    enum GenderType
    {
        Male,
        Female
    }
    struct Person
    {
        public string FirstName;
        public string LastName;
        public int Age;
        public string City;
        public GenderType gender;
    }
}
