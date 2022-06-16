
namespace NearestVehiclePositions.Core.Interfaces
{
    public interface IPosition
    {
        public int PositionId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
