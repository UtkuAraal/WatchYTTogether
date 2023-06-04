using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchTogether.Domain.Entities;

namespace WatchTogether.Application.Contracts
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public string RoomCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
        public ApplicationUser Owner { get; set; }

        public string RoomPassword { get; set; }
    }
}
