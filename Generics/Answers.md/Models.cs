public interface IHasId { int Id { get; } }

public sealed class Student : IHasId
{
    public int Id { get; init; }
    public string Name { get; init; } = "";
    public override string ToString() => $"{Id}: {Name}";
}

public sealed class Course : IHasId
{
    public int Id { get; init; }
    public string Title { get; init; } = "";
    public decimal Price { get; init; }
    public override string ToString() => $"{Id}: {Title} (${Price})";
}
