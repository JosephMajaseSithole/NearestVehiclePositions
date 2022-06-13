using NearestVehiclePositions.Core.Interfaces;
using System.Text;

namespace NearestVehiclePositions.Core.Models
{
    public struct Vehicle : IVehicle
    {
        public StringBuilder VehicleRegistration { get; set; }
        public ulong RecordedTimeUTC { get; set; }
        public int PositionId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
