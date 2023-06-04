using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchTogether.Domain.Entities;

namespace WatchTogether.Infrastructure.Repository.Abstract
{
    public interface IRoomRepo
    {
        public void CreateRoom(Room newRoom);
        public Task<List<Room>> GetAllRooms();
    }
}
