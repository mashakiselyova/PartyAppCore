using System.Collections.Generic;
using PartyAppCore.Models;

namespace PartyAppCore.DAL
{
    public interface IParticipantsRepository
    {
        List<Participant> Participants { get; set; }

        void AddUser(Participant participant);
        void Delete(Participant participant);
        List<Participant> List();
        void Load();
        void Save();
    }
}