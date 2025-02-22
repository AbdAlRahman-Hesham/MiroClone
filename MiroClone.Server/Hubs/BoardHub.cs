using Microsoft.AspNetCore.SignalR;

namespace MiroClone.Server.Hubs
{
    public class BoardHub : Hub
    {
        // Method to broadcast user mouse movement to all clients
        public async Task UserMouseMove(string name, double x, double y)
        {
            await Clients.Others.SendAsync("onUserMouseMove", name, x, y);
        }
        public async Task BroadcastObjectChange(string objectData)
        {
            await Clients.Others.SendAsync("ReceiveObjectChange", objectData);
        } 
        public async Task BroadcastTextChange(string objectData)
        {
            await Clients.Others.SendAsync("ReceiveTextChange", objectData);
        }
        public async Task BroadcastObjectRemoved(string objectData)
        {
            await Clients.Others.SendAsync("ReceiveObjectRemoved", objectData);
        }
        public async Task BroadcastObjectAdd(string objectData)
        {
            try
            {
                await Clients.Others.SendAsync("ReceiveObjectAdd", objectData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error broadcasting object add: {ex.Message}");
                throw; // Optional: Re-throw the exception if needed
            }
        }
        public async Task BroadcastBringToFront(string objectData, bool BringToFront)
        {
            await Clients.Others.SendAsync("ReceiveBringToFront", objectData, BringToFront);

        }
        public async Task BroadcastZoomToPoint(string PointData, double ZoomFactor)
        {
            await Clients.Others.SendAsync("ReceiveZoomToPoint", PointData, ZoomFactor);
        }        
        public async Task BroadcastMoveToPoint(double eClientX, double eClientY,double lastPosX,double lastPosY)
        {
            await Clients.Others.SendAsync("ReceiveMoveToPoint", eClientX, eClientY);
        }

    }
}
