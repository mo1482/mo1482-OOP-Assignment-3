# Part 02 — answers

## Reports
- **Problem:** Each exporter duplicated the same load → validate → format → save workflow, risking inconsistent step order and repeated fixes.
- **Change:** Added abstract `ReportExporter` with a non-overridable `Export` template method. Concrete exporters implement only `Format`; the shared load, validation, and save logic lives once in the base class.
- **Why abstract class rather than interface?** The algorithm shares implemented behavior and protected helper methods. An interface primarily defines a contract and would not be the natural place for this shared state/implementation. An abstract base class centralizes the invariant sequence while leaving the format variation to subclasses.

## Enrollment
- **Problem:** `Program.cs` knew all four services and their required order, so callers were coupled to workflow details.
- **Change:** Added `EnrollmentFacade.Enroll`, which performs payment, seat reservation, invoice creation, and email in order. `Services.cs` remains unchanged.
- **Why Facade?** It offers one simple operation over a subsystem. The caller no longer needs to construct/call `PaymentGateway`, `SeatInventory`, `InvoiceGenerator`, or `EmailService`, nor remember the order.
