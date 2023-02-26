using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni;

public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniContext context = new SoftUniContext();
        Console.WriteLine(RemoveTown(context));
    }
    //Problem 03
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .OrderBy(e => e.EmployeeId)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            })
            .ToArray(); //ToList() -> Detach from the change tracker, any changes on the data inside will not be saved into db
        foreach (var e in employees)
        {
            sb
                .AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 04
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .Where(x => x.Salary > 50000)
            .OrderBy(x => x.FirstName)
            .Select(x => new
            {
                x.FirstName,
                x.Salary
            })
            .ToList();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 05
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employeesRnD = context.Employees
            .Where(e => e.Department.Name == "Research and Development")
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                DepartmentName = e.Department.Name,
                e.Salary
            })
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .ToArray();

        foreach (var e in employeesRnD)
        {
            sb
                .AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 06
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        Address newAddress = new Address()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };
        //context.Addresses.Add(newAddress); // This is the way for adding into the db

        Employee? employee = context.Employees
            .FirstOrDefault(e => e.LastName == "Nakov");
        employee.Address = newAddress;

        context.SaveChanges();

        string[] employeeAddresses = context.Employees
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .Select(e => e.Address!.AddressText)
            .ToArray();
        return String.Join(Environment.NewLine, employeeAddresses);
    }

    // Problem 07
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();
        var employeesWithProjects = context.Employees
            //.Where(e => e.EmployeesProjects
            //    .Any(ep => ep.Project.StartDate.Year >= 2001 &&
            //               ep.Project.StartDate.Year <= 2003))
            .Take(10)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManagerFirstName = e.Manager!.FirstName,
                ManagerLastName = e.Manager!.LastName,
                Projects = e.EmployeesProjects
                    .Where(ep => ep.Project.StartDate.Year >= 2001 &&
                                 ep.Project.StartDate.Year <= 2003)
                    .Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = ep.Project.EndDate.HasValue
                            ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                            : "not finished"
                    })
                    .ToArray()
            })
            .ToArray();

        foreach (var e in employeesWithProjects)
        {
            sb
                .AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

            foreach (var p in e.Projects)
            {
                sb
                    .AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
            }
        }

        return sb.ToString().TrimEnd();
    }


    // Problem 08
    public static string GetAddressesByTown(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();
        var addresses = context.Addresses
            .Select(x => new
            {
                x.AddressText,
                TownName = x.Town!.Name,
                EmployeesCount = x.Employees.Count
            })
            .OrderByDescending(x => x.EmployeesCount)
            .ThenBy(x => x.TownName)
            .ThenBy(x => x.AddressText)
            .Take(10)
            .ToList();

        foreach (var address in addresses)
        {
            sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 09
    public static string GetEmployee147(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();
        var employee = context.Employees.FirstOrDefault(x => x.EmployeeId == 147); //.Find(147);
        var employeeProjects = employee.EmployeesProjects.OrderBy(x => x.Project.Name).ToArray();

        sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

        foreach (var employeeProject in employeeProjects)
        {
            sb.AppendLine($"{employeeProject.Project.Name}");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 10
    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        var sb = new StringBuilder();

        var departments = context.Departments
            .Select(x => new
            {
                EmployeesCount = x.Employees.Count,
                x.Name,
                ManagerName = $"{x.Manager.FirstName} {x.Manager.LastName}",
                x.Employees

            })
            .Where(x => x.Employees.Count > 5)
            .OrderBy(x => x.Employees.Count)
            .ThenBy(x => x.Name);

        foreach (var department in departments)
        {
            sb.AppendLine($"{department.Name} - {department.ManagerName}");

            foreach (var employee in department.Employees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 11
    public static string GetLatestProjects(SoftUniContext context)
    {
        var sb = new StringBuilder();

        var projects = context.Projects
            .OrderByDescending(x => x.StartDate)
            .Select(x => new
            {
                x.Name,
                x.Description,
                x.StartDate
            })
            .Take(10)
            .OrderBy(x => x.Name);

        foreach (var project in projects)
        {
            sb.AppendLine(project.Name);
            sb.AppendLine(project.Description);
            sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
        }

        return sb.ToString().TrimEnd();
    }


    // Problem 12
    public static string IncreaseSalaries(SoftUniContext context)
    {
        var sb = new StringBuilder();
        var departments = new string[]
        {
            "Engineering", "Tool Design", "Marketing", "Information Services"
        };
        var employees = context.Employees
            .Where(x => departments.Contains(x.Department.Name));
        //.Select(x=> new
        //{
        //    x.FirstName,
        //    x.LastName,
        //    x.Salary
        //});

        foreach (var employee in employees.OrderBy(x => x.FirstName))
        {
            employee.Salary *= 1.12m;
            sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 13
    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        var sb = new StringBuilder();
        var employees = context.Employees
            .Where(x => x.FirstName.StartsWith("Sa"))
            .Select(x => new
            {
                x.FirstName,
                x.LastName,
                x.JobTitle,
                x.Salary
            })
            .OrderBy(x => x.FirstName)
            .ThenBy(x => x.LastName);

        foreach (var emp in employees)
        {
            sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:f2})");
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 14
    public static string DeleteProjectById(SoftUniContext context)
    {
        var epToDelete = context.EmployeesProjects
            .Where(ep => ep.ProjectId == 2);
        context.EmployeesProjects.RemoveRange(epToDelete);

        Project projectToDelete = context.Projects.Find(2)!;
        context.Projects.Remove(projectToDelete);
        context.SaveChanges();

        string[] projectNames = context.Projects
            .Take(10)
            .Select(p => p.Name)
            .ToArray();

        return string.Join(Environment.NewLine, projectNames);
    }

    // Problem 15
    public static string RemoveTown(SoftUniContext context)
    {
        var townToDelete = context.Towns.FirstOrDefault(x => x.Name == "Seattle");

        var addressesToDelete = context.Addresses.Where(x => x.TownId == townToDelete!.TownId);

        var employees = context.Employees
            .Where(x => addressesToDelete.Any(y => y.AddressId == x.AddressId));

        foreach (var e in employees)
            e.AddressId = null;

        int numberOfAddreses = addressesToDelete.Count();
        context.Addresses.RemoveRange(addressesToDelete);
        context.Towns.Remove(townToDelete!);

        context.SaveChanges();

        return $"{numberOfAddreses} addresses in {townToDelete!.Name} were deleted";
    }
    //public static string RemoveTown(SoftUniContext context)
    //{
    //    Town townToDelete = context
    //        .Towns
    //        .FirstOrDefault(t => t.Name == "Seattle");

    //    Address[] referencedAddresses = context
    //        .Addresses
    //        .Where(a => a.TownId == townToDelete.TownId)
    //        .ToArray();

    //    foreach (var e in context.Employees)
    //    {
    //        if (referencedAddresses.Any(a => a.AddressId == e.AddressId))
    //        {
    //            e.AddressId = null;
    //        }
    //    }

    //    int numberOfDeletedAddresses = referencedAddresses.Length;

    //    context.Addresses.RemoveRange(referencedAddresses);
    //    context.Towns.Remove(townToDelete);

    //    context.SaveChanges();

    //    return $"{numberOfDeletedAddresses} addresses in Seattle were deleted";
    //}
}