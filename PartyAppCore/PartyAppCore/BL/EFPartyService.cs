using PartyAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyAppCore.BL
{
    public class EFPartyService : IPartyService
    {
        private PartyContext _context;

        public EFPartyService(PartyContext context)
        {
            _context = context;
        }

        public Party GetPartyById(int id)
        {
            Party temp = _context.Parties.Find(id);
            temp.Participants = _context.Participants.Where(p => p.PartyId == id).ToList();
            return temp;
        }

        public List<Participant> ListAttendent()
        {
            return _context.Participants.Where(user => user.IsAttending == true).ToList();
        }

        public List<Participant> ListMissed()
        {
            return _context.Participants.Where(user => user.IsAttending == false).ToList();
        }

        public List<Participant> ListParticipants()
        {
            return _context.Participants.ToList();
        }

        public List<Party> ListParties()
        {
            return _context.Parties.ToList();
        }

        public void Vote(Participant participant)
        {
            if (participant.Name != string.Empty)
            {
                Participant temp = _context.Participants.FirstOrDefault(p => p.Name == participant.Name);
                if (temp != null)
                {
                    temp.IsAttending = participant.IsAttending;
                    temp.PartyId = participant.PartyId;
                    if (participant.Avatar != null)
                        temp.Avatar = participant.Avatar;
                    _context.SaveChanges();
                }
                else
                {
                    _context.Participants.Add(participant);
                    _context.SaveChanges();
                }
            }
        }
    }
}
