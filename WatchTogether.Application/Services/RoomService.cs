using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchTogether.Application.Contracts;
using WatchTogether.Application.Interfaces;
using WatchTogether.Domain.Entities;
using WatchTogether.Infrastructure.Repository.Abstract;

namespace WatchTogether.Application.Services
{
    public class RoomService: IRoomService
    {
        private readonly IRoomRepo _roomRepo;
        private readonly IMapper _mapper;
        public RoomService(IRoomRepo roomRepo,IMapper mapper)
        {
            _roomRepo = roomRepo;
            _mapper = mapper;
        }

        public void CreateRoom(RoomDto newRoom)
        {
            
        }

        public async Task<List<RoomDto>> GetAllRooms() 
        {
            var rooms = await _roomRepo.GetAllRooms();
            var result = _mapper.Map<List<Room>, List<RoomDto>>(rooms);
            return result;
        }

    }
}
