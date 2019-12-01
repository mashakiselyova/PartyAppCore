
namespace PartyAppCore.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PartyId { get; set; }
        public bool IsAttending { get; set; }
        public byte[] Avatar { get; set; }

        public Participant(string name, bool attend, int partyId)
        {
            Name = name;
            IsAttending = attend;
            PartyId = partyId;
        }
    }
}
