# Part 03 — answers

## BlockedUsers
- **Time complexity before:** O(B × R), where B is the number of blocked IDs and R is the number of requests, because `List.Contains` scans the list for each request.
- **Time (ms) before:** Run the original version before replacing it and record the measured value here. It depends on the machine/runtime and must not be invented.
- **What changed:** Convert the blocked IDs to a `HashSet<int>` once, then use average O(1) membership lookup for each request.
- **Time complexity after:** O(B + R) average, including building the set.
- **Time (ms) after:** Run the refactored project and record the measured value here. It depends on the machine/runtime.

## Students
- **Problem:** `GetAllStudents()` eagerly allocated one million student objects even though the caller stopped after three.
- **Change:** It is now an iterator using `yield return`; student objects are created on demand and enumeration stops when the caller breaks.
