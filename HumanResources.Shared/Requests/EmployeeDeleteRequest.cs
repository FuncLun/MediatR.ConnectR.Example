using MediatR;

namespace HumanResources
{
    public class EmployeeDeleteRequest : IRequest
    {
        public int EmployeeId { get; set; }
    }
}