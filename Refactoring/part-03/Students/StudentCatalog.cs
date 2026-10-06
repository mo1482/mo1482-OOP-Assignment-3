namespace RefactoringLab.Part03.Students;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
}

public static class StudentCatalog
{
    // Iterator method: objects are created as the caller requests each item.
    public static IEnumerable<Student> GetAllStudents()
    {
        for (var i = 1; i <= 1_000_000; i++)
            yield return new Student { Id = i, Name = $"Student {i}" };
    }
}
