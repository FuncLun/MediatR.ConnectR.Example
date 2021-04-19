using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Facilities
{
    public class BuildingGetHandler : IRequestHandler<BuildingGetRequest, BuildingGetResponse>
    {
        #region " Dependency Injection "

        public BuildingGetHandler(
            FacilitiesContext facilitiesContext
        )
        {
            FacilitiesContext = facilitiesContext;
        }

        #endregion

        private FacilitiesContext FacilitiesContext { get; }

        public async Task<BuildingGetResponse> Handle(BuildingGetRequest request, CancellationToken cancellationToken)
        {
            var qry = FacilitiesContext.Buildings
                .AsQueryable();

            if (request.BuildingId.HasValue)
                qry = qry.Where(e => e.BuildingId == request.BuildingId.Value);

            return new BuildingGetResponse()
            {
                Buildings = await qry
                    .AsNoTracking()
                    .ToListAsync(cancellationToken),
            };
        }
    }
}
