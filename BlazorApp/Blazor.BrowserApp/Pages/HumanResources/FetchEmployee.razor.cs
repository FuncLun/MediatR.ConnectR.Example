using System.Collections.Generic;
using System.Threading.Tasks;
using HumanResources;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace Blazor.BrowserApp.Pages.HumanResources
{
    public class FetchEmployeeModel : ComponentBase
    {
        [Inject]
        protected IMediator Mediator { get; set; }

        protected List<Employee> Employees { get; set; }

        protected override async Task OnInitAsync()
        {
            var req = new EmployeeGetRequest();

            Employees = (await Mediator.Send(req))
                .Employees;
        }
    }
}
