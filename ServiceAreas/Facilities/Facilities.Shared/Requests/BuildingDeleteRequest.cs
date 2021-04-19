using MediatR;

namespace Facilities
{
    public class BuildingDeleteRequest : IRequest
    {
        public int BuildingId { get; set; }
    }
}