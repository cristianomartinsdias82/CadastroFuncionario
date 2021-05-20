using MediatR;
using System;

namespace ServerApp.Application.Employees.Commands.SaveEmployee
{
    public class SaveEmployeeRequest : IRequest<SaveEmployeeResponse>
    {
        public string FullName { get; set; }
        public string Ssn { get; set; }
        public DateTime Dob { get; set; }
        public decimal Salary { get; set; }
    }
}
