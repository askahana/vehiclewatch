namespace VehicleWatch.Services
{
    public interface IVehicle
    {
        Task<int> GetVehicleId(string RegistrationNumber);
        Task<bool> VehicleExists(string RegistrationNumber);
    }
}
