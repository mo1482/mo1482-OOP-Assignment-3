namespace RefactoringLab;

public interface IOrderRepository { void Save(int orderId, DateTime processedAt); }
public interface IEmailSender { void Send(string to, string body); }

public sealed class SqlOrderRepository : IOrderRepository
{
    public void Save(int orderId, DateTime processedAt) =>
        Console.WriteLine($"[SQL] save order {orderId} @ {processedAt:O}");
}

public sealed class SmtpEmailSender : IEmailSender
{
    public void Send(string to, string body) => Console.WriteLine($"[SMTP] to={to} body={body}");
}

public sealed class OrderProcessor
{
    private readonly IOrderRepository _repository;
    private readonly IEmailSender _emailSender;

    public OrderProcessor(IOrderRepository? repository = null, IEmailSender? emailSender = null)
    {
        _repository = repository ?? new SqlOrderRepository();
        _emailSender = emailSender ?? new SmtpEmailSender();
    }

    public void Process(int orderId, string customerEmail)
    {
        var processedAt = DateTime.Now;
        _repository.Save(orderId, processedAt);
        _emailSender.Send(customerEmail, $"Order {orderId} confirmed at {processedAt}");
    }
}
