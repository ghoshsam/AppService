
using AutoMapper;
namespace AppService.Api.Helper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Infrastructure.Entities.App, Core.Models.App>();

        }
    }
}
