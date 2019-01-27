using System.Threading.Tasks;
using HumanResources;
using MediatR;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;

namespace Blazor.BrowserApp.Pages.HumanResources
{
    public class AddEmployeeModel : BlazorComponent
    {
        [Inject]
        protected IUriHelper UriHelper { get; set; }

        [Inject]
        protected IMediator Mediator { get; set; }

        protected Employee Employee = new Employee();

        protected async Task CreateEmployee()
        {
            var req = new EmployeeCreateRequest() { Employee = Employee };

            await Mediator.Send(req);

            UriHelper.NavigateTo(HumanResourcesPages.FetchEmployee);
        }

        protected void Cancel()
        {
            UriHelper.NavigateTo(HumanResourcesPages.FetchEmployee);
        }
    }
}
