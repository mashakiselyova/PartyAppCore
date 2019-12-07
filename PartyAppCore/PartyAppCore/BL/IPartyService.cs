using System.Collections.Generic;
using PartyAppCore.Models;

namespace PartyAppCore.BL
{
    public interface IPartyService
    {
        Party GetPartyById(int id);
        List<Participant> ListAttendent();
        List<Participant> ListMissed();
        List<Participant> ListParticipants();
        List<Party> ListParties();
        void Vote(Participant participant);
    }
}