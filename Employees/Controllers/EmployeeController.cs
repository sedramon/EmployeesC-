using System.Reflection.Emit;
using Employees.Models;
using Employees.Services;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers;

public class EmployeeController : Controller
{
    private readonly EmployeeService _employeeService;

    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            // Step 1: Retrieve Data
            var employees = await _employeeService.GetEmployees();

            // Step 2: Group Tasks by Employee
            var groupedEmployees = employees.GroupBy(t => t.EmployeeName);

            // Step 3: Calculate Total Work Time for Each Employee
            var employeeSummaries = groupedEmployees.Select(group =>
            {
                var totalWorkTime = group.Aggregate(TimeSpan.Zero, (acc, task) => acc.Add(task.TotalTimeWorked));
                return new EmployeeSummaryViewModel
                {
                    EmployeeName = group.Key,
                    TotalWorkTime = totalWorkTime.TotalHours
                };
            }).ToList();

            employeeSummaries = employeeSummaries.OrderByDescending(e => e.TotalWorkTime).ToList();
            

            return View(employeeSummaries);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., log or display an error view)
            return View("Error");
        }
    }
    
}