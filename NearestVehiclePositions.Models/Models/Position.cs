using NearestVehiclePositions.Core.Interfaces;

namespace NearestVehiclePositions.Core.Models
{
    public struct Position : IPosition
    {
        public int PositionId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
