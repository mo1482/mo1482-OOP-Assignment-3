namespace RefactoringLab.Part02.Enrollment;

public sealed class EnrollmentFacade
{
    private readonly PaymentGateway _payment = new();
    private readonly SeatInventory _seats = new();
    private readonly InvoiceGenerator _invoices = new();
    private readonly EmailService _email = new();

    public void Enroll(string studentId, string courseId, decimal amount)
    {
        _payment.Charge(studentId, amount);
        _seats.Reserve(courseId, studentId);
        var invoiceId = _invoices.Create(studentId, amount);
        _email.Send(studentId, "Enrollment confirmed", $"Invoice {invoiceId} for {courseId}");
    }
}
