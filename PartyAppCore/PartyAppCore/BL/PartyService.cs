using PartyAppCore.DAL;
using PartyAppCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace PartyAppCore.BL
{
    public class PartyService : IPartyService
    {
        IParticipantsRepository _participantsRepository;
        IPartyRepository _partiesRepository;

        public PartyService(IParticipantsRepository participants, IPartyRepository parties)
        {
            _participantsRepository = participants;
            _partiesRepository = parties;
        }

        public void Vote(Participant participant)
        {
            if (participant.Name != string.Empty)
            {

                Participant temp = _participantsRepository.Participants.Find((p) => p.Name == participant.Name);
                if (temp != null)
                {
                    temp.IsAttending = participant.IsAttending;
                    temp.PartyId = participant.PartyId;
                    if (participant.Avatar != null)
                        temp.Avatar = participant.Avatar;
                    _participantsRepository.Save();
                }
                else
                    _participantsRepository.AddUser(participant);
            }
        }

        public List<Participant> ListParticipants()
        {
            return _participantsRepository.Participants;
        }

        public List<Participant> ListAttendent()
        {
            return _participantsRepository.Participants.Where(user => user.IsAttending == true).ToList();
        }

        public List<Participant> ListMissed()
        {
            return _participantsRepository.Participants.Where(user => user.IsAttending == false).ToList();
        }

        public List<Party> ListParties()
        {
            return _partiesRepository.Parties;
        }

        public Party GetPartyById(int id)
        {
            Party temp = _partiesRepository.Parties.Find(p => p.Id == id);
            temp.Participants = _participantsRepository.Participants.Where(p => p.PartyId == id).ToList();
            return temp;
        }
    }
}
