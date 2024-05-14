using Microsoft.EntityFrameworkCore;
using VehicleWatch.Data;

namespace VehicleWatch.Services
{
    public class VehicleRepository: IVehicle
    {
        private VehicleDbContext _context;
        public VehicleRepository(VehicleDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetVehicleId(string RegistrationNumber)
        {
            var vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(v => v.RegistrationNumber == RegistrationNumber);
            if (vehicle != null)
            {
                return vehicle.VehicleId;
            }
            return 0;
        }
        public async Task<bool> VehicleExists(string RegistrationNumber)
        {
            return await _context.Vehicles.AnyAsync(v => v.RegistrationNumber == RegistrationNumber);
        }
    }
}
