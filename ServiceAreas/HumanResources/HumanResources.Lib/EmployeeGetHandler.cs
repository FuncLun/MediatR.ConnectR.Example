using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HumanResources
{
    public class EmployeeGetHandler : IRequestHandler<EmployeeGetRequest, EmployeeGetResponse>
    {
        #region " Dependency Injection "

        public EmployeeGetHandler(
            HumanResourcesContext humanResourcesContext
        )
        {
            HumanResourcesContext = humanResourcesContext;
        }

        #endregion

        private HumanResourcesContext HumanResourcesContext { get; }

        public async Task<EmployeeGetResponse> Handle(EmployeeGetRequest request, CancellationToken cancellationToken)
        {
            var qry = HumanResourcesContext.Employees
                .AsQueryable();

            if (request.EmployeeId.HasValue)
                qry = qry.Where(e => e.EmployeeId == request.EmployeeId.Value);

            return new EmployeeGetResponse()
            {
                Employees = await qry
                    .AsNoTracking()
                    .ToListAsync(cancellationToken),
            };
        }
    }
}
