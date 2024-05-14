using VehicleWatch.Models;

namespace VehicleWatch.Services
{
    public interface IReport
    {
        Task<IEnumerable<Report>> GetAll();
        Task<Report> GetSingel(int reportId);
        Task<IEnumerable<Report>> GetAllHistoryByRegNum(string registeredNum);
        Task<IEnumerable<Report>> GetAllHistoryById(int vehicleId);
        Task<Report> Delete(int reportid);
        bool VehicleExists(int vehicleId);
        Task<Report> Add(Report newReport);
    }
}
