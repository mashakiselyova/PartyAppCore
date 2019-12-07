using System.Collections.Generic;
using PartyAppCore.Models;

namespace PartyAppCore.DAL
{
    public interface IPartyRepository
    {
        List<Party> Parties { get; set; }
    }
}