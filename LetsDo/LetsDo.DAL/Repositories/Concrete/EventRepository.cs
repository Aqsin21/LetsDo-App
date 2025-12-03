using LetsDo.DAL.DataContext;
using LetsDo.DAL.DataContext.Entities;
using LetsDo.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsDo.DAL.Repositories.Concrete
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(AppDbContext context) : base(context) { }
    }
}
