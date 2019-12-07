using PartyAppCore.Models;
using System;
using System.Collections.Generic;

namespace PartyAppCore.DAL
{
    public class PartyRepository : IPartyRepository
    {
        public List<Party> Parties { get; set; } = new List<Party>()
        {
            new Party() {Id = 1, Name = "New Year party", Date = new DateTime(2019, 12, 31, 22, 0, 0), Location = "Skryganova 14"},
            new Party() {Id = 2, Name = "Winter party", Date = new DateTime(2019, 12, 01, 16, 0, 0), Location = "Skryganova 14"},
            new Party() {Id = 3, Name = "Birthday party", Date = new DateTime(2020, 02, 08, 16, 0, 0), Location = "Skryganova 14"},
            new Party() {Id = 4, Name = "Another party", Date = new DateTime(2020, 01, 04, 16, 0, 0), Location = "Skryganova 14"},
            new Party() {Id = 5, Name = "Some party", Date = new DateTime(2019, 12, 15, 16, 0, 0), Location = "Skryganova 14"},
            new Party() {Id = 6, Name = "One more party", Date = new DateTime(2019, 12, 05, 16, 0, 0), Location = "Skryganova 14"},
            new Party() {Id = 7, Name = "I ran out of names party", Date = new DateTime(2020, 02, 01, 16, 0, 0), Location = "Skryganova 14"},
            new Party() {Id = 8, Name = "Don't know how to name it party", Date = new DateTime(2020, 12, 20, 16, 0, 0), Location = "Skryganova 14"},
        };
    }
}
