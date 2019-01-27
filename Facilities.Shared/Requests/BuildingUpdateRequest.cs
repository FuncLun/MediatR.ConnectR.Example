using MediatR;

namespace Facilities
{
    public class BuildingUpdateRequest : IRequest
    {
        public Building Building { get; set; }
    }
}