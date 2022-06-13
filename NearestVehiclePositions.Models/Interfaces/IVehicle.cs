using System;

namespace NearestVehiclePositions.Core.Interfaces
{
    public interface IVehicle : IPosition
    {
        public string VehicleRegistration { get; set; }
        public UInt64 RecordedTimeUTC { get; set; }
    }
}
