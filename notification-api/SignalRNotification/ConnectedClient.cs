namespace notification_api.SignalRNotification;

public class ConnectedClient
{
    public int? LocalId { get; init; }
    public List<string>? ConnectionIds { get; init; }
}