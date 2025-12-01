using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsDo.DAL.DataContext.Entities
{
    public class Event : BaseEntity
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required DateTime EventDate { get; set; }
        public int MaxParticipants { get; set; }

        // Foreign Keys
        public Guid OrganizerId { get; set; }
        public Guid CategoryId { get; set; }

        // Navigation 
        public AppUser Organizer { get; set; } = null!;
        public Category Category { get; set; } = null!;
    }
}
