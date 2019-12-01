using PartyAppCore.Models;
using System.Collections.Generic;

namespace PartyAppCore.ViewModels
{
    public class NearestPartyViewModel
    {
        public List<Party> NearestParties { get; set; }

        public NearestPartyViewModel(List<Party> parties)
        {
            parties.Sort((x, y) => x.Date.CompareTo(y.Date));
            NearestParties = parties;
            if (NearestParties.Count > 10)
                NearestParties.RemoveRange(10, NearestParties.Count - 10);
        }
    }
}
