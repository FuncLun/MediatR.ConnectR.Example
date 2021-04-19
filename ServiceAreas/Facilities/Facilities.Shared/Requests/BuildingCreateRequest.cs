using MediatR;

namespace Facilities
{
    public class BuildingCreateRequest : IRequest
    {
        public Building Building { get; set; }
    }
}