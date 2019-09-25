using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Patient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
