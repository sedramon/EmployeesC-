namespace Employees.Models;

public class EmployeeViewModel
{
    public string Id { get; set; }
    public string EmployeeName { get; set; }
    public DateTime StarTimeUtc { get; set; }
    public DateTime EndTimeUtc { get; set; }
    public string EntryNotes { get; set; }
    public DateTime? DeletedOn { get; set; }

    //DODATNO POLJE ZA UKUPNO VREME RADA
    public TimeSpan TotalTimeWorked => EndTimeUtc - StarTimeUtc;
    
    
}