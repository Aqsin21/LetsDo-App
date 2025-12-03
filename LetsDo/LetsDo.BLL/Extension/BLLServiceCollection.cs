using LetsDo.BLL.Services.Abstract;
using LetsDo.BLL.Services.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace LetsDo.BLL.Extension
{
    public static class BLLServiceCollection
    {
       public static IServiceCollection AddBll(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<IEventService, EventService>();
            return services;
        }
    }

}
