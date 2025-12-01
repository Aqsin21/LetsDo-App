using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsDo.DAL.DataContext.Entities
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }
        public string? Icon { get; set; }
    }
}
