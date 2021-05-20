using System;

namespace ServerApp.Core.Entities
{
    public class Person : Entity
    {
        public string FullName { get; set; }
        public string Ssn { get; set; }
        public DateTime Dob { get; set; }
    }
}
