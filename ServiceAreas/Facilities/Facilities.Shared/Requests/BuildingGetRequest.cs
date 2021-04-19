using System.Collections.Generic;
using MediatR;

namespace Facilities
{
    public class BuildingGetRequest : IRequest<BuildingGetResponse>
    {
        public int? BuildingId { get; set; }
    }

    public class BuildingGetResponse
    {
        public List<Building> Buildings { get; set; }
    }
}