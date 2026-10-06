# Generics — Answers

## Step 2 — StudentStore vs CourseStore
Both stores maintain a collection and provide Add, GetById, GetAll and Remove. They differ in the model type and fields: Student has Id and Name, while Course has Id, Title and Price. This duplication motivates a generic store.

## Step 3 — Why unconstrained Store<T>.GetById does not compile
Trying to access `item.Id` when `T` has no constraint produces a compiler error like: `T does not contain a definition for 'Id' and no accessible extension method 'Id' accepting a first argument of type 'T' could be found`. The compiler cannot assume every possible T has an Id member.

## Step 7 — Why Store<string> must not compile
`Store<T>` has the constraint `where T : IHasId`. `string` does not implement `IHasId`, so it does not satisfy the generic constraint. `Store<Student>` and `Store<Course>` work because both types implement the interface.

## Last question — common name
This is a **repository-like generic collection / strongly typed in-memory store**; the important type-system concept is a **constrained generic type**. The assignment does not specify one unique naming convention, so describe it as a generic repository/store with an `IHasId` constraint.
