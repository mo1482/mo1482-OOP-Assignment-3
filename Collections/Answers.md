# Collections — Answers

## Task 2.1 — IReadOnlyDictionary and SortedDictionary

- `IReadOnlyDictionary<TKey,TValue>` is a read-only view contract for key/value pairs. It exposes lookup and enumeration but no operations for adding or removing entries. It does not guarantee that the underlying dictionary cannot change through another reference.
- `Dictionary<TKey,TValue>` is a mutable hash-based dictionary. It supports adding, removing and updating values; lookup is typically O(1) on average and it does not sort entries by key.
- A public API may return `IReadOnlyDictionary` to communicate that callers should only inspect the mapping and to avoid exposing mutation operations. If it wraps a mutable object, the owner must still avoid mutating it unexpectedly or return a defensive/read-only copy when needed.
- `SortedDictionary<TKey,TValue>` keeps keys sorted according to its comparer. Its lookup, insertion and removal are O(log n), while `Dictionary` typically offers average O(1) lookup. Choose it when sorted iteration is a requirement and entries change over time; choose `Dictionary` for fast key lookup when ordering is not required.

Research references to consult and cite in your own submission: Microsoft Learn pages for `IReadOnlyDictionary<TKey,TValue>`, `Dictionary<TKey,TValue>`, and `SortedDictionary<TKey,TValue>`; plus a second reputable .NET reference such as the API documentation or a data-structures reference. Verify current wording before submission.

## Task 2.2 — Pick the Collection

| Scenario | Collection | Why |
|---|---|---|
| S1 Find a student by national ID thousands of times | `Dictionary` | Keyed lookup is typically O(1) average. |
| S2 Course tags must be unique | `HashSet` | It prevents duplicate elements and supports efficient membership checks. |
| S3 Grades preserve entry order and duplicates | `List` | It preserves insertion order and allows repeated values. |
| S4 Public price list is readable but not mutable by callers | `IReadOnlyDictionary` | It exposes lookup/enumeration without mutation methods. |
| S5 Timetable always prints in session-time order | `SortedDictionary` | Keys are kept sorted as entries are inserted. |
| S6 Caller enumerates results once and may stop early | `IEnumerable` | It supports deferred/streamed iteration without requiring a materialized collection. |
