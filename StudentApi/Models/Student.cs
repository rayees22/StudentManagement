public class Student
{
    public int Id { get; set; }   // PRIMARY KEY (required for TiDB)
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Department { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public string EntryTime { get; set; } = string.Empty;
    public string ExitTime { get; set; } = string.Empty;
}
