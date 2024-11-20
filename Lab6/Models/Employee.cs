namespace Lab6.Models;

public class Employee
{
    public int EmployeeId { get; set; }
    public int EmployeeAddressId { get; set; }
    public string EmployeeName { get; set; }
    public string EmployeePhone { get; set; }
    public string OtherEmployeeDetails { get; set; }

    public ICollection<Delivery> Deliveries { get; set; }
}