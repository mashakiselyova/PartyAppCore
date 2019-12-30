
namespace PartyAppCore.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAttending { get; set; }
        public byte[] Avatar { get; set; }
        public int PartyId { get; set; }
        public Party Party { get; set; }

        public Participant(string name, bool isAttending, int partyId)
        {
            Name = name;
            IsAttending = isAttending;
            PartyId = partyId;
        }
    }
}
