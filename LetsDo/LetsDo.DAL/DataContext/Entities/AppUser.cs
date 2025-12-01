using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsDo.DAL.DataContext.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? ProfilPictureUrl { get; set; }
        public required DateTime BirthDate { get; set; }

    }
}
