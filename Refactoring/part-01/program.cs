using RefactoringLab;

var shipping = new ShippingCostCalculator(new IShippingCarrier[]
{
    new AramexCarrier(), new FedExCarrier(), new DhlCarrier(), new UpsCarrier()
});
Console.WriteLine($"Aramex 2kg → {shipping.Calculate("Aramex", 2)}");
Console.WriteLine($"FedEx 2kg  → {shipping.Calculate("FedEx", 2)}");
Console.WriteLine($"UPS 2kg    → {shipping.Calculate("UPS", 2)}");
Console.WriteLine();

var processor = new OrderProcessor();
processor.Process(1001, "customer@example.com");
Console.WriteLine();

new NotificationSender(new EmailChannel(), new NotificationOptions { IsUrgent = true, SendAt = DateTime.Today.AddHours(18) })
    .Send("customer@example.com", "Your order ships tomorrow");
new NotificationSender(new SmsChannel(), new NotificationOptions { IsUrgent = true })
    .Send("+201000000000", "OTP 4821");
new NotificationSender(new PushChannel(), new NotificationOptions { SendAt = DateTime.Today.AddHours(19) })
    .Send("customer-device", "New offer");
