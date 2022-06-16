using NearestVehiclePositions.Core.Interfaces;
using System.Text;

namespace NearestVehiclePositions.Core.Models
{
    public struct Vehicle : IVehicle
    {
        public StringBuilder VehicleRegistration { get; set; }
        public ulong RecordedTimeUTC { get; set; }
        public int PositionId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
