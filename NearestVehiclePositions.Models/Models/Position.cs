using NearestVehiclePositions.Core.Interfaces;

namespace NearestVehiclePositions.Core.Models
{
    public struct Position : IPosition
    {
        public int PositionId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
