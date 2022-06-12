using NearestVehiclePositions.Core.Models;
using System.Collections.Generic;

namespace NearestVehiclePositions.Core.Interfaces
{
    public interface IPositionService
    {
        public List<Position> GetPositions();
    }
}
