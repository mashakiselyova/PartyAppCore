using Microsoft.AspNetCore.Mvc;
using PartyAppCore.Infrastructure;
using System.Collections.Generic;
using PartyAppCore.BL;
using PartyAppCore.Models;

namespace PartyAppCore.Components
{
    public class LastViewedParties : ViewComponent
    {
        IPartyService service;

        public LastViewedParties(IPartyService s)
        {
            service = s;
        }

        public IViewComponentResult Invoke()
        {
            List<int> PartyIds = HttpContext.Session.GetParties();
            List<Party> lastViewedParties = new List<Party>();
            foreach(int id in PartyIds)
            {
                lastViewedParties.Add(service.GetPartyById(id));
            }                

            return View(lastViewedParties);
        }
    }
}
