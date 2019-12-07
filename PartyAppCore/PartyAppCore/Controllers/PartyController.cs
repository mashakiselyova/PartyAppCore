using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyAppCore.BL;
using PartyAppCore.Models;
using PartyAppCore.ViewModels;
using System;
using System.IO;
using PartyAppCore.Infrastructure;

namespace PartyAppCore.Controllers
{
    public class PartyController : Controller
    {
        IPartyService service;

        public PartyController(IPartyService s)
        {
            service = s;
        }

        public IActionResult Participants()
        {
            PartyViewModel partyViewModel = new PartyViewModel(service.ListParties(), service.ListParticipants());
            return View("Participants", partyViewModel);
        }

        [HttpGet]
        public IActionResult Vote()
        {
            return View("Vote", service.ListParties());
        }

        [HttpPost]
        public IActionResult Vote(string name, string attend, string partyId, IFormFile avatar)
        {
            bool IsAttending = false;
            if (attend != null)
                IsAttending = true;
            Participant participant = new Participant(name, IsAttending, Convert.ToInt32(partyId));

            if (avatar != null)
            {
                using (var fileStream = new FileStream(Directory.GetCurrentDirectory() + @"\wwwroot\Avatars\" + avatar.FileName, FileMode.Create))
                {
                    avatar.CopyTo(fileStream);
                }

                participant.Avatar = new byte[avatar.Length];
                avatar.OpenReadStream().Read(participant.Avatar, 0, (int)avatar.Length);
            }

            service.Vote(participant);
            return RedirectToAction("Participants");
        }

        public IActionResult ShowParty(int id)
        {
            HttpContext.Session.SetParty(id);

            Party party = service.GetPartyById(id);

            return View("ShowParty", party);
        }
    }
}
