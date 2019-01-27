using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Facilities
{
    public class BuildingCreateHandler : IRequestHandler<BuildingCreateRequest>
    {
        #region " Dependency Injection "

        public BuildingCreateHandler(
            FacilitiesContext facilitiesContext
            )
        {
            FacilitiesContext = facilitiesContext;
        }

        #endregion

        private FacilitiesContext FacilitiesContext { get; }

        /// <inheritdoc />
        public async Task<Unit> Handle(BuildingCreateRequest request, CancellationToken cancellationToken)
        {
            FacilitiesContext.Buildings.Add(request.Building);

            await FacilitiesContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
