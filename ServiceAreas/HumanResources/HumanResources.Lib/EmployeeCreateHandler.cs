using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace HumanResources
{
    public class EmployeeCreateHandler : IRequestHandler<EmployeeCreateRequest>
    {
        #region " Dependency Injection "

        public EmployeeCreateHandler(
            HumanResourcesContext humanResourcesContext
            )
        {
            HumanResourcesContext = humanResourcesContext;
        }

        #endregion

        private HumanResourcesContext HumanResourcesContext { get; }

        /// <inheritdoc />
        public async Task<Unit> Handle(EmployeeCreateRequest request, CancellationToken cancellationToken)
        {
            HumanResourcesContext.Employees.Add(request.Employee);

            await HumanResourcesContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
