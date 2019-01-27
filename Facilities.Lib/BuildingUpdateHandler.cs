using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Facilities
{
    public class BuildingUpdateHandler : IRequestHandler<BuildingUpdateRequest>
    {
        #region " Dependency Injection "

        public BuildingUpdateHandler(
            FacilitiesContext facilitiesContext
        )
        {
            FacilitiesContext = facilitiesContext;
        }

        #endregion

        private FacilitiesContext FacilitiesContext { get; }


        public async Task<Unit> Handle(BuildingUpdateRequest request, CancellationToken cancellationToken)
        {
            FacilitiesContext.Entry(request.Building).State = EntityState.Modified;

            await FacilitiesContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
