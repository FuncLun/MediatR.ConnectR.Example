using System;
using System.Linq;
using System.Threading.Tasks;
using HumanResources;
using MediatR;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using Http = System.Net.Http;

namespace Blazor.BrowserApp.Pages.HumanResources
{
    public class EditEmployeeModel : BlazorComponent
    {
        [Inject]
        protected IUriHelper UriHelper { get; set; }

        [Inject]
        public Http.HttpClient HttpClient { get; set; }

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

        protected async Task UpdateEmployee()
        {
            var req = new EmployeeUpdateRequest() { Employee = Employee };

            await Mediator.Send(req);

            UriHelper.NavigateTo(HumanResourcesPages.FetchEmployee);
        }

        protected void Cancel()
        {
            UriHelper.NavigateTo(HumanResourcesPages.FetchEmployee);
        }
    }
}
