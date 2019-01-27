using System;
using System.Linq;
using System.Threading.Tasks;
using Facilities;
using MediatR;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using Http = System.Net.Http;

namespace Blazor.BrowserApp.Pages.Facilities
{
    public class EditBuildingModel : BlazorComponent
    {
        [Inject]
        protected IUriHelper UriHelper { get; set; }

        [Inject]
        public Http.HttpClient HttpClient { get; set; }

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

        protected async Task UpdateBuilding()
        {
            var req = new BuildingUpdateRequest() { Building = Building };

            await Mediator.Send(req);

            UriHelper.NavigateTo(FacilitiesPages.FetchBuilding);
        }

        protected void Cancel()
        {
            UriHelper.NavigateTo(FacilitiesPages.FetchBuilding);
        }
    }
}
