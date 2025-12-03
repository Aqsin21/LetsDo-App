using LetsDo.BLL.Services.Abstract;
using LetsDo.DAL.DataContext;
using LetsDo.DAL.DataContext.Entities;
using LetsDo.DAL.Repositories.Abstract;
namespace LetsDo.BLL.Services.Concrete
{
    public class EventService:GenericService<Event> , IEventService
    {
        public EventService(IGenericRepository<Event> repository, AppDbContext context) 
            : base(repository) { }
    }
}
