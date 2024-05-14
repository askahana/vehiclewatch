using Microsoft.EntityFrameworkCore;
using VehicleWatch.Data;
using VehicleWatch.Models;

namespace VehicleWatch.Services
{
    public class ReportRepository : IReport
    {
        private VehicleDbContext _context;
        public ReportRepository(VehicleDbContext context)
        {
            _context = context;
        }

        public async Task<Report> Add(Report newReport)
        {
            newReport.ReportedDate = DateTime.Now;
            var result = await _context.Reports.AddAsync(newReport);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Report> Delete(int reportid)
        {
            var result = await _context.Reports.FirstOrDefaultAsync(r => r.ReportId == reportid);
            if (result != null)
            {
                _context.Reports.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Report>> GetAll()
        {
            return await _context.Reports.Include(e => e.Employee).Include(v => v.Vehicle).ToListAsync();
        }
        public async Task<Report> GetSingel(int reportId)
        {
            return await _context.Reports.FirstOrDefaultAsync(r => r.ReportId == reportId);
        }

        public async Task<IEnumerable<Report>> GetAllHistoryById(int vehicleId)
        {
            return await _context.Reports.Where(r => r.VehicleId == vehicleId).ToListAsync();
        }

        public Task<IEnumerable<Report>> GetAllHistoryByRegNum(string registeredNum)
        {
            throw new NotImplementedException();
        }

        public bool VehicleExists(int vehicleId)
        {
            return _context.Vehicles.Any(r => r.VehicleId == vehicleId);
        }
    }
}
