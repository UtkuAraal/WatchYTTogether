using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchTogether.Application.Hubs
{
    public class RoomHub : Hub
    {
        // Play olayını tetikleyen metod
        public async Task Play(string groupName)
        {
            //await Clients.Others.SendAsync("Play");
            await Clients.OthersInGroup(groupName).SendAsync("Play");
        }

        // Pause olayını tetikleyen metod
        public async Task Pause(string groupName)
        {
            //await Clients.Others.SendAsync("Pause");
            await Clients.OthersInGroup(groupName).SendAsync("Pause");
        }

        // Seek olayını tetikleyen metod
        public async Task SeekVideo(int time, string groupName)
        {
            //await Clients.Others.SendAsync("Seek", time);
            await Clients.OthersInGroup(groupName).SendAsync("Seek", time);

        }
        // Gruba katılmasını sağlayan method
        public async Task JoinGroup(string groupName) 
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }


        // Chat mesajını tetikleyen metod
        public async Task ChatMessage(string message, string groupName)
        {
            await Clients.Group(groupName).SendAsync("ChatMessage", message);
        }

        public async Task SyncVideoTime(double currentTime, string groupName)
        {
            // Video süresini güncelleme işlemleri burada gerçekleştirilir
            // ...
            // Diğer istemcilere video süresini bildir
            //await Clients.Others.SendAsync("ReceiveVideoTime", currentTime);
            await Clients.OthersInGroup(groupName).SendAsync("ReceiveVideoTime", currentTime);
        }
    }
}
