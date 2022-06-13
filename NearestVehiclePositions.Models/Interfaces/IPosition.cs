using System;

namespace NearestVehiclePositions.Core.Interfaces
{
    public interface IPosition
    {
        public Int32 PositionId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
