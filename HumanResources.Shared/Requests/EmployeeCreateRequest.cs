using MediatR;

namespace HumanResources
{
    public class EmployeeCreateRequest : IRequest
    {
        public Employee Employee { get; set; }
    }
}