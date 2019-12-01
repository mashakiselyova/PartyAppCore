using Microsoft.AspNetCore.Mvc;
using PartyAppCore.BL;
using PartyAppCore.ViewModels;

namespace PartyAppCore.Components
{
    public class NearestParties : ViewComponent
    {
        IPartyService service;
        public NearestParties(IPartyService s)
        {
            service = s;
        }

        public IViewComponentResult Invoke()
        {
            NearestPartyViewModel nearestParties = new NearestPartyViewModel(service.ListParties());
            return View(nearestParties);
        }

    }
}
