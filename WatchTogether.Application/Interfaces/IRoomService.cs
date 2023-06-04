using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchTogether.Application.Contracts;
using WatchTogether.Infrastructure.Repository.Abstract;

namespace WatchTogether.Application.Interfaces
{
    public interface IRoomService
    {
        public void CreateRoom(RoomDto newRoom);
        public Task<List<RoomDto>> GetAllRooms();

    }
}
