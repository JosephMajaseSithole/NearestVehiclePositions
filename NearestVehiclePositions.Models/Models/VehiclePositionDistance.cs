using System.Text;

namespace NearestVehiclePositions.Core.Models
{
    public struct VehiclePositionDistance
    {
        public StringBuilder VehicleRegistration { get; set; }
        public double DistanceFromPosition { get; set; }
    }
}
