using System.ComponentModel.DataAnnotations;

namespace VehicleWatch.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
