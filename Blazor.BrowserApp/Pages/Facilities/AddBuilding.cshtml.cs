using System.Threading.Tasks;
using Facilities;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Services;

//using Microsoft.AspNetCore.Components.Services;

namespace Blazor.BrowserApp.Pages.Facilities
{
    public class AddBuildingModel : ComponentBase
    {
        [Inject]
        protected IUriHelper UriHelper { get; set; }

        [Inject]
        protected IMediator Mediator { get; set; }

        protected Building Building = new Building();

        protected async Task CreateBuilding()
        {
            var req = new BuildingCreateRequest() { Building = Building };

            await Mediator.Send(req);

            UriHelper.NavigateTo(FacilitiesPages.FetchBuilding);
        }

        protected void Cancel()
        {
            UriHelper.NavigateTo(FacilitiesPages.FetchBuilding);
        }
    }
}
