using System;
using System.Linq;
using System.Threading.Tasks;
using Facilities;
using MediatR;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;

namespace Blazor.BrowserApp.Pages.Facilities
{
    public class DeleteBuildingModel : BlazorComponent
    {
        [Inject]
        protected IUriHelper UriHelper { get; set; }

        [Inject]
        protected IMediator Mediator { get; set; }

        [Parameter]
        protected string BuildingId { get; set; }

        protected Building Building = new Building();

        protected override async Task OnInitAsync()
        {
            var req = new BuildingGetRequest()
            {
                BuildingId = Convert.ToInt32(BuildingId),
            };

            var resp = await Mediator.Send(req);

            Building = resp.Buildings.FirstOrDefault();
        }

        public async Task Delete()
        {
            var req = new BuildingDeleteRequest()
            {
                BuildingId = Convert.ToInt32(BuildingId),
            };

            await Mediator.Send(req);

            UriHelper.NavigateTo(FacilitiesPages.FetchBuilding);
        }

        public void Cancel()
        {
            UriHelper.NavigateTo(FacilitiesPages.FetchBuilding);
        }
    }
}