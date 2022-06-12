using NearestVehiclePositions.Core.Models;
using System.Collections.Generic;

namespace NearestVehiclePositions.Core.Interfaces
{
    public interface IVehicleService
    {
        public List<Vehicle> GetVehicles();
        public void GetVehicleNearestToPosition(List<Position> positions, List<Vehicle> vehicles);
    }
}
