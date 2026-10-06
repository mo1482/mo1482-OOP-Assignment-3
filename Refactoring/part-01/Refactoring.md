# Part 01 — answers

## ShippingCostCalculator
- **Problem:** A switch statement hard-coded carrier rules in the calculator. Adding a carrier required editing existing logic, violating Open/Closed Principle.
- **Change:** Introduced `IShippingCarrier`; each carrier owns its calculation, and the calculator uses a dictionary of implementations. `UpsCarrier` demonstrates extension without modifying existing carrier classes.

## OrderProcessor
- **Problem:** It constructed SQL and SMTP implementations internally, making testing and replacement difficult and creating hard-wired dependencies.
- **Change:** Added `IOrderRepository` and `IEmailSender`, and injects them through the constructor (with defaults for the console demo). The processor depends on abstractions.

## Notifications
- **Problem:** Inheritance combinations multiplied for channel × urgency × scheduling.
- **Change:** `NotificationSender` composes an `INotificationChannel` with independent `NotificationOptions`. Email, SMS and Push can be urgent and/or scheduled without combination subclasses.

## Proof
- New carrier file/class: `UpsCarrier` in `ShippingCostCalculator.cs`.
- New notification channel: `PushChannel` in `Notifications.cs`.
- Existing classes left unchanged: yes for the existing carrier/channel implementations; `Program.cs` is updated to wire new objects. Shared source files were refactored as required.
