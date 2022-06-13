using NearestVehiclePositions.Core.Interfaces;
using System;

namespace NearestVehiclePositions.Core.Models
{
    public struct Vehicle : IVehicle
    {
        public string VehicleRegistration { get; set; }
        public UInt64 RecordedTimeUTC { get; set; }
        public Int32 PositionId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
