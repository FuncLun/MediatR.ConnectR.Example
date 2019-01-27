using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Facilities
{
    public class BuildingDeleteHandler : IRequestHandler<BuildingDeleteRequest>
    {
        #region " Dependency Injection "

        public BuildingDeleteHandler(
            FacilitiesContext facilitiesContext
        )
        {
            FacilitiesContext = facilitiesContext;
        }

        #endregion

        private FacilitiesContext FacilitiesContext { get; }


        public async Task<Unit> Handle(BuildingDeleteRequest request, CancellationToken cancellationToken)
        {
            var emp = new Building()
            {
                BuildingId = request.BuildingId,
            };

            FacilitiesContext.Entry(emp).State = EntityState.Deleted;

            await FacilitiesContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
