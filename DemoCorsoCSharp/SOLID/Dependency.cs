namespace DemoCorsoCSharp.SOLID;

public enum Gender { Male, Female}

public enum Position { Manager, Executive, Administrator}

public class Employee
{
    public string? Name { get; set; }
    public Gender Gender { get; set; }
    public Position Position { get; set; }
}

//public class EmployeeManager
//{
//    private readonly List<Employee> _employees;

//    public EmployeeManager()
//    {
//        _employees = new();
//    }

//    public void AddEmployee(Employee employee)
//    {
//        _employees.Add(employee);
//    }

//   // public List<Employee> Employees => _employees;
//}

//public class EmployeeStatistics
//{
//    private readonly EmployeeManager employeeManager;

//    public EmployeeStatistics(EmployeeManager employeeManager)
//    {
//        this.employeeManager = employeeManager;
//    }

//    public int CountFemaleManager()
//    {
//        return employeeManager.Employees.Count(e => e.Gender == Gender.Female && e.Position == Position.Manager);
//    }
//}

public interface IEmployeeSearchable
{
    IEnumerable<Employee> GetEmployeesByGenderAndPosition(Gender gender, Position position);
}

public class EmployeeManager : IEmployeeSearchable
{
    private readonly List<Employee> _employees;

    public EmployeeManager()
    {
        _employees = new List<Employee>();
    }

    public IEnumerable<Employee> GetEmployeesByGenderAndPosition(Gender gender, Position position)
    {
        return _employees.Where(e => e.Gender == gender && e.Position == position);
    }

    public void AddEmployee(Employee employee)
    {
        _employees.Add(employee);
    }
}

public class EmployeeStatistics
{
    private readonly IEmployeeSearchable employeeSearchable;

    public EmployeeStatistics(IEmployeeSearchable employeeSearchable)
    {
        this.employeeSearchable = employeeSearchable;
    }

    public int CountFemaleManager()
    {
        return employeeSearchable.GetEmployeesByGenderAndPosition(Gender.Female, Position.Manager)
            .Count();
    }
}