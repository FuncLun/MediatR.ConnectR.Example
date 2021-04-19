using System.Collections.Generic;
using MediatR;

namespace HumanResources
{
    public class EmployeeGetRequest : IRequest<EmployeeGetResponse>
    {
        public int? EmployeeId { get; set; }
    }

    public class EmployeeGetResponse
    {
        public List<Employee> Employees { get; set; }
    }
}