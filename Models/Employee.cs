using System.ComponentModel.DataAnnotations;

namespace VehicleWatch.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
    }
}
