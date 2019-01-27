using System.Collections.Generic;
using System.Threading.Tasks;
using Facilities;
using MediatR;
using Microsoft.AspNetCore.Blazor.Components;

namespace Blazor.BrowserApp.Pages.Facilities
{
    public class FetchBuildingModel : BlazorComponent
    {
        [Inject]
        protected IMediator Mediator { get; set; }

        protected List<Building> Buildings { get; set; }

        protected override async Task OnInitAsync()
        {
            var req = new BuildingGetRequest();

            Buildings = (await Mediator.Send(req))
                .Buildings;
        }
    }
}
