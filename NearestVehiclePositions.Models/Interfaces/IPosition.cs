
namespace NearestVehiclePositions.Core.Interfaces
{
    public interface IPosition
    {
        public int PositionId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
