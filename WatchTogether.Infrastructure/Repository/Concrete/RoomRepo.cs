using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchTogether.Data;
using WatchTogether.Domain.Entities;
using WatchTogether.Infrastructure.Repository.Abstract;

namespace WatchTogether.Infrastructure.Repository.Concrete
{
    public class RoomRepo : IRoomRepo
    {
        private readonly ApplicationDbContext _context;
        public RoomRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateRoom(Room newRoom) 
        {
            _context.Add(newRoom);
            _context.SaveChanges();
        }

        public async Task<List<Room>> GetAllRooms()
        {
            return await _context.Rooms.ToListAsync();
        }
    }
}
