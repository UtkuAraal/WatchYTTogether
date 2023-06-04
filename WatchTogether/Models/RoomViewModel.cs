using WatchTogether.Domain.Entities;

namespace WatchTogether.Presentation.Models
{
    public class RoomViewModel
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
