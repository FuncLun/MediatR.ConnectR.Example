using System;
using System.Linq;
using System.Threading.Tasks;
using HumanResources;
using MediatR;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;

namespace Blazor.BrowserApp.Pages.HumanResources
{
    public class DeleteEmployeeModel : BlazorComponent
    {
        [Inject]
        protected IUriHelper UriHelper { get; set; }

        [Inject]
        protected IMediator Mediator { get; set; }

        [Parameter]
        protected string EmployeeId { get; set; }

        protected Employee Employee = new Employee();

        protected override async Task OnInitAsync()
        {
            var req = new EmployeeGetRequest()
            {
                EmployeeId = Convert.ToInt32(EmployeeId),
            };

            var resp = await Mediator.Send(req);

            Employee = resp.Employees.FirstOrDefault();
        }

        public async Task Delete()
        {
            var req = new EmployeeDeleteRequest()
            {
                EmployeeId = Convert.ToInt32(EmployeeId),
            };

            await Mediator.Send(req);

            UriHelper.NavigateTo(HumanResourcesPages.FetchEmployee);
        }

        public void Cancel()
        {
            UriHelper.NavigateTo(HumanResourcesPages.FetchEmployee);
        }
    }
}