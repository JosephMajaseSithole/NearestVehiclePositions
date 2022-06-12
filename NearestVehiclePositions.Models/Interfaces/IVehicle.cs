namespace NearestVehiclePositions.Core.Interfaces
{
    public interface IVehicle : IPosition
    {
        public string VehicleRegistration { get; set; }
        public ulong RecordedTimeUTC { get; set; }
    }
}
