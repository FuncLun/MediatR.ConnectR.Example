using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HumanResources
{
    public class EmployeeDeleteHandler : IRequestHandler<EmployeeDeleteRequest>
    {
        #region " Dependency Injection "

        public EmployeeDeleteHandler(
            HumanResourcesContext humanResourcesContext
        )
        {
            HumanResourcesContext = humanResourcesContext;
        }

        #endregion

        private HumanResourcesContext HumanResourcesContext { get; }


        public async Task<Unit> Handle(EmployeeDeleteRequest request, CancellationToken cancellationToken)
        {
            var emp = new Employee()
            {
                EmployeeId = request.EmployeeId,
            };

            HumanResourcesContext.Entry(emp).State = EntityState.Deleted;

            await HumanResourcesContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
