var phoneTests = new (string? Input, bool Expected)[]
{
    ("01012345678", true), ("+201512345678", true), ("01312345678", false),
    ("0101234567", false), ("0101234567a", false), (null, false), ("   ", false)
};
foreach (var test in phoneTests)
    Console.WriteLine($"Phone '{test.Input ?? "<null>"}': {test.Input.IsValidEgyptianPhone()} (expected {test.Expected})");

var idTests = new (string? Input, bool Expected)[]
{
    ("29901011234567", true), ("19901011234567", false), ("2990101123456", false),
    (null, false), ("", false)
};
foreach (var test in idTests)
    Console.WriteLine($"National ID '{test.Input ?? "<null>"}': {test.Input.IsValidEgyptianNationalId()} (expected {test.Expected})");
