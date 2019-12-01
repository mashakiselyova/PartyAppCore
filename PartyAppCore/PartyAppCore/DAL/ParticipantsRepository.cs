using Newtonsoft.Json;
using PartyAppCore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PartyAppCore.DAL
{
    public class ParticipantsRepository : IParticipantsRepository
    {
        string _repositoryPath = Directory.GetCurrentDirectory() + @"\wwwroot\Users.json";

        [JsonProperty("Users")]
        public List<Participant> Participants { get; set; }

        public ParticipantsRepository()
        {
            this.Load();
        }

        public void Load()
        {
            string jsonFile = File.ReadAllText(_repositoryPath);
            this.Participants = JsonConvert.DeserializeObject<List<Participant>>(jsonFile);
        }

        public void Save()
        {
            string jsonFile = JsonConvert.SerializeObject(Participants);
            File.WriteAllText(_repositoryPath, jsonFile);
        }

        public void AddUser(Participant participant)
        {
            Participants.Add(participant);
            Save();
        }

        public List<Participant> List()
        {
            Load();
            return Participants;
        }

        public void Delete(Participant participant)
        {
            Participants.Remove(participant);
        }
    }
}
