using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PartyAppCore.Infrastructure
{
    public static class SessionExtentions
    {
        public static List<int> GetParties(this ISession session)
        {
            string lastViewedParties = session.GetString("LastViewedParties");
            if (lastViewedParties == null)
                return new List<int>();
            else
                return JsonConvert.DeserializeObject<List<int>>(lastViewedParties);
        }

        public static void SetParty(this ISession session, int partyId)
        {
            List<int> lastViewedParties = session.GetParties();
            if (lastViewedParties.Count >= 5)
                lastViewedParties.RemoveAt(0);
            lastViewedParties.Add(partyId);
            session.SetString("LastViewedParties", JsonConvert.SerializeObject(lastViewedParties));
        }
    }
}
