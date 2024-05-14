using System.ComponentModel.DataAnnotations;

namespace VehicleWatch.Models
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }
        [Required(ErrorMessage = "Ange användarid")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Required(ErrorMessage = "Ange fordonid")]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ReportedDate { get; set; }
        public string ReportDescription { get; set; }
        public bool Emergency { get; set; }
        public ReportStatus ReportStatus { get; set; }
    }
}
