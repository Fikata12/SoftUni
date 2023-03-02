using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main()
        {

        }
        // 03. Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.MiddleName,
                    e.LastName,
                    e.JobTitle,
                    Salary = e.Salary.ToString("f2")
                })
                .ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary}");
            }
            return sb.ToString();
        }
        // 04. Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .OrderBy(e => e.FirstName)
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    Salary = e.Salary.ToString("f2")
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary}");
            }
            return sb.ToString();
        }
        // 05. Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    Salary = e.Salary.ToString("f2")
                })
                .ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary}");
            }
            return sb.ToString();
        }

        // 06. Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address();
            address.AddressText = "Vitoshka 15";
            address.TownId = 4;

            Employee? employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            employee.Address = address;
            context.SaveChanges();

            var addresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => new
                {
                    e.Address!.AddressText
                })
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var item in addresses)
            {
                sb.AppendLine(item.AddressText);
            }
            return sb.ToString();
        }
        // 07. Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager!.FirstName,
                    ManagerLastName = e.Manager!.LastName,
                    projects = e.EmployeesProjects.Where(ep => ep.Project.StartDate.Year >= 2001
                                                            && ep.Project.StartDate.Year <= 2003)
                    .Select(ep => new
                    {
                        ep.Project.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = ep.Project.EndDate.HasValue ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                    }).ToArray()
                })
                .Take(10)
                .ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");
                foreach (var project in employee.projects)
                {
                    sb.AppendLine($"--{project.Name} - {project.StartDate} - {project.EndDate}");
                }
            }
            return sb.ToString();
        }
        // 08. Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count
                })
                .ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }
            return sb.ToString();
        }
        // 09. Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                                .OrderBy(ep => ep.Project.Name)
                                .Select(ep => ep.Project)
                                .ToArray()
                });
            StringBuilder sb = new StringBuilder();
            foreach (var emp in employee)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                foreach (var project in emp.Projects)
                {
                    sb.AppendLine(project.Name);
                }
            }
            return sb.ToString();
        }
        // 10. Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    })
                })
                .ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var d in departments)
            {
                sb.AppendLine($"{d.Name} - {d.ManagerFirstName} {d.ManagerLastName}");
                foreach (var e in d.Employees)
                {
                    sb.AppendLine($"{e.FirstName}{e.LastName} - {e.JobTitle}");
                }
            }
            return sb.ToString();
        }
        // 11. Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(x => $"{x.Name}" + Environment.NewLine +
                             $"{x.Description}" + Environment.NewLine +
                             $"{x.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}")
                .ToArray();
            return string.Join(Environment.NewLine, projects);
        }

        // 12. Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var e in employees)
            {
                e.Salary *= (decimal)1.12;
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }
            context.SaveChanges();
            return sb.ToString();
        }
        // 13. Find Employees by First Name Starting With Sa
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();
            StringBuilder sb = new StringBuilder();
            foreach(var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }
            return sb.ToString();
        }
        // 14. Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            var employeeProjects = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2).ToArray();
            context.EmployeesProjects.RemoveRange(employeeProjects);

            var project = context.Projects.Find(2);
            context.Projects.Remove(project);

            context.SaveChanges();

            return string.Join(Environment.NewLine, context.Projects.Take(10).Select(p => p.Name));
        }
        // 15. Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Address.Town.Name == "Seattle")
                .ToArray();
            foreach(var e in employees)
            {
                e.AddressId = null;
            }

            var addresses = context.Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToArray();
            context.Addresses.RemoveRange(addresses);

            var town = context.Towns.FirstOrDefault(t => t.Name == "Seattle");
            context.Towns.Remove(town);

            context.SaveChanges();

            return $"{addresses.Length} addresses in Seattle were deleted";
        }
    }
}