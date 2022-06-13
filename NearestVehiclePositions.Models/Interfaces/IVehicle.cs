using System.Text;

namespace NearestVehiclePositions.Core.Interfaces
{
    public interface IVehicle : IPosition
    {
        public StringBuilder VehicleRegistration { get; set; }
        public ulong RecordedTimeUTC { get; set; }
    }
}
