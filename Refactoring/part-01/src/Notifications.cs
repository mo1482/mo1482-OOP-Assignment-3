namespace RefactoringLab;

public interface INotificationChannel { string Name { get; } void Send(string to, string message); }
public sealed class EmailChannel : INotificationChannel
{
    public string Name => "email";
    public void Send(string to, string message) => Console.WriteLine($"[email] {to}: {message}");
}
public sealed class SmsChannel : INotificationChannel
{
    public string Name => "sms";
    public void Send(string to, string message) => Console.WriteLine($"[sms] {to}: {message}");
}
// New channel; can be combined with urgency/scheduling without subclass combinations.
public sealed class PushChannel : INotificationChannel
{
    public string Name => "push";
    public void Send(string to, string message) => Console.WriteLine($"[push] {to}: {message}");
}

public sealed class NotificationOptions
{
    public bool IsUrgent { get; init; }
    public DateTime? SendAt { get; init; }
}

public sealed class NotificationSender
{
    private readonly INotificationChannel _channel;
    private readonly NotificationOptions _options;
    public NotificationSender(INotificationChannel channel, NotificationOptions? options = null)
    { _channel = channel; _options = options ?? new NotificationOptions(); }

    public void Send(string to, string message)
    {
        var decorated = _options.IsUrgent ? $"[URGENT] {message}" : message;
        if (_options.SendAt is DateTime sendAt)
            Console.WriteLine($"[{_channel.Name} scheduled {sendAt:g}] {to}: {decorated}");
        else
            _channel.Send(to, decorated);
    }
}
