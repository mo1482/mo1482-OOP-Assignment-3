var students = new Store<Student>();
students.Add(new Student { Id = 1, Name = "Ali" });
students.Add(new Student { Id = 2, Name = "Mona" });
students.Add(new Student { Id = 3, Name = "Omar" });
students.Add(new Student { Id = 4, Name = "Nour" });
students.Add(new Student { Id = 5, Name = "Salma" });

var courses = new Store<Course>();
courses.Add(new Course { Id = 101, Title = "C# Basics", Price = 1200m });
courses.Add(new Course { Id = 102, Title = "OOP", Price = 1500m });
courses.Add(new Course { Id = 103, Title = "SQL", Price = 1000m });

Console.WriteLine($"Student by id: {students.GetById(3)}");
Console.WriteLine($"Course by id: {courses.GetById(102)}");
try { students.Add(new Student { Id = 3, Name = "Duplicate" }); }
catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }

Console.WriteLine("Page 2, size 2:");
foreach (var student in students.GetAll().Page(2, 2)) Console.WriteLine(student);

var courseList = new List<Course>
{
    new() { Id = 201, Title = "Algorithms", Price = 1800m },
    new() { Id = 202, Title = "Databases", Price = 1600m }
};
Console.WriteLine($"Find on List<Course>: {courseList.FindById(202)}");
Console.WriteLine($"Read-only dictionary count: {courseList.ToIdDictionary().Count}");

// new Store<string>(); // must NOT compile: string does not implement IHasId.
