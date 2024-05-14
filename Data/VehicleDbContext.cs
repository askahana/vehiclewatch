using Microsoft.EntityFrameworkCore;
using VehicleWatch.Models;

namespace VehicleWatch.Data
{
    public class VehicleDbContext: DbContext
    {
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) :base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Report> Reports { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                VehicleId = 1,
                RegistrationNumber = "ABC123",
            });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                VehicleId = 2,
                RegistrationNumber = "WEL217",
            });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                VehicleId = 3,
                RegistrationNumber = "UEN357",
            });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                VehicleId = 4,
                RegistrationNumber = "KAZ813",
            });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                VehicleId = 5,
                RegistrationNumber = "WES123",
            });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                VehicleId = 6,
                RegistrationNumber = "NEM345",
            });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                VehicleId = 7,
                RegistrationNumber = "MLB803",
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                Name = "Adam",
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                Name = "Bengt",
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                Name = "Cathy",
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 4,
                Name = "David",
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 5,
                Name = "Erika",
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 6,
                Name = "Felicia",
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 7,
                Name = "Gabriella",
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 8,
                Name = "Henrik",
            });

            modelBuilder.Entity<Report>().HasData(new Report
            {
                ReportId = 1,
                EmployeeId = 1,
                VehicleId = 1,
                ReportedDate = new DateTime(2024, 04, 06),
                ReportDescription = "Fel med motor",
                Emergency = true,
                ReportStatus = ReportStatus.InProgress,

            });
            modelBuilder.Entity<Report>().HasData(new Report
            {
                ReportId = 2,
                EmployeeId = 2,
                VehicleId = 2,
                ReportedDate = new DateTime(2024, 04, 10),
                ReportDescription = "vindrutetorkaren fungerar inte",
                Emergency = false,
                ReportStatus = ReportStatus.InProgress,
            });
            modelBuilder.Entity<Report>().HasData(new Report
            {
                ReportId = 3,
                EmployeeId = 3,
                VehicleId = 3,
                ReportedDate = new DateTime(2024, 04, 11),
                ReportDescription = "sprickan i vindrutan",
                Emergency = false,
                ReportStatus = ReportStatus.Completed,
            });
            modelBuilder.Entity<Report>().HasData(new Report
            {
                ReportId = 4,
                EmployeeId = 4,
                VehicleId = 2,
                ReportedDate = new DateTime(2024, 04, 23),
                ReportDescription = "sprickan i vindrutan",
                Emergency = false,
                ReportStatus = ReportStatus.InProgress,
            });
        }
    }
}
