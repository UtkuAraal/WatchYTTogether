using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchTogether.Application.Contracts;
using WatchTogether.Domain.Entities;

namespace WatchTogether.Application.Mappings
{
    public class W2GProfile : Profile
    {
        public W2GProfile()
        {
            CreateMap<RoomDto, Room>().ReverseMap();
        }
    }
}
