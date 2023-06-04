using AutoMapper;
using WatchTogether.Application.Contracts;
using WatchTogether.Presentation.Models;

namespace WatchTogether.Presentation.Mappings
{
    public class ViewModelProfiler : Profile
    {
        public ViewModelProfiler()
        {
            CreateMap<RoomDto, RoomViewModel>().ReverseMap();
        }
    }
}
