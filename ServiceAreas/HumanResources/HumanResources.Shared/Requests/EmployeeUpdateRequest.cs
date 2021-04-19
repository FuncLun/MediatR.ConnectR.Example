using MediatR;

namespace HumanResources
{
    public class EmployeeUpdateRequest : IRequest
    {
        public Employee Employee { get; set; }
    }
}