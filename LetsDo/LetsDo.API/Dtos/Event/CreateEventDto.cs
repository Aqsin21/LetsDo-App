namespace LetsDo.API.Dtos.Event
{
    public class CreateEventDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public int MaxParticipants { get; set; }
        public Guid OrganizerId { get; set; }


    }
}
