using PartyAppCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace PartyAppCore.ViewModels
{
    public class PartyViewModel
    {
        public List<Party> Parties { get; set; }

        public PartyViewModel(List<Party> parties, List<Participant> participants)
        {
            Parties = parties;
            foreach (var party in parties)
            {
                party.Participants = participants.Where(p => p.PartyId == party.Id).ToList();
            }
        }
    }
}
