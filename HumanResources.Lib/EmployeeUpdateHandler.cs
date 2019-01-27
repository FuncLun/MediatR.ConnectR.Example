using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HumanResources
{
    public class EmployeeUpdateHandler : IRequestHandler<EmployeeUpdateRequest>
    {
        #region " Dependency Injection "

        public EmployeeUpdateHandler(
            HumanResourcesContext humanResourcesContext
        )
        {
            HumanResourcesContext = humanResourcesContext;
        }

        #endregion

        private HumanResourcesContext HumanResourcesContext { get; }


        public async Task<Unit> Handle(EmployeeUpdateRequest request, CancellationToken cancellationToken)
        {
            HumanResourcesContext.Entry(request.Employee).State = EntityState.Modified;

            await HumanResourcesContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
