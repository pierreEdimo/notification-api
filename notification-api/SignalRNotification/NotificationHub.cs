using Microsoft.AspNetCore.SignalR;

namespace notification_api.SignalRNotification;

public class NotificationHub : Hub
{
    private new static readonly Dictionary<int, List<string>> Clients = new();

    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        lock (Clients)
        {
            foreach (var localId in Clients.Keys)
            {
                Clients[localId].Remove(Context.ConnectionId);
                if (Clients[localId].Count == 0) Clients.Remove(localId);
            }
        }

        await base.OnDisconnectedAsync(exception);
    }

    public Task SaveConnectedClients(int localId)
    {
        lock (Clients)
        {
            if (!Clients.ContainsKey(localId)) Clients[localId] = [];
            Clients[localId] = [Context.ConnectionId];
        }

        return Task.CompletedTask;
    }

    public List<ConnectedClient> GetConnectedClients()
    {
        lock (Clients)
        {
            var connectedClients = Clients.Select(client => new ConnectedClient
            {
                LocalId = client.Key,
                ConnectionIds = client.Value
            }).ToList();
            return connectedClients;
        }
    }
}