using System;
using System.Collections.Generic;

namespace PartyAppCore.Models
{
    public class Party
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public List<Participant> Participants { get; set; }
    }
}
