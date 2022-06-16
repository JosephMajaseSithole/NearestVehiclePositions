using NearestVehiclePositions.Core.Interfaces;
using NearestVehiclePositions.Core.Models;
using System.Collections.Generic;

namespace NearestVehiclePositions.Services
{
    public class PositionService : IPositionService
    {
        public List<Position> GetPositions()
        {
            //This can also be read from another source depending on requirements (hard-coded data in this case.)
            return new List<Position>()
            {
                new Position()
                {
                    PositionId = 1,
                    Latitude = 34.544909,
                    Longitude = -102.100843
                },
                new Position()
                {
                    PositionId = 2,
                    Latitude = 32.345544,
                    Longitude = -99.123124
                },
                new Position()
                {
                    PositionId = 3,
                    Latitude = 33.234235,
                    Longitude = -100.214124
                },
                new Position()
                {
                    PositionId = 4,
                    Latitude = 35.195739,
                    Longitude = -95.348899
                },
                new Position()
                {
                    PositionId = 5,
                    Latitude = 31.895839,
                    Longitude = -97.789573
                },
                new Position()
                {
                    PositionId = 6,
                    Latitude = 32.895839,
                    Longitude = -101.789573
                },
                new Position()
                {
                    PositionId = 7,
                    Latitude = 34.115839,
                    Longitude = -100.225732
                },
                new Position()
                {
                    PositionId = 8,
                    Latitude = 32.335839,
                    Longitude = -99.992232
                },
                new Position()
                {
                    PositionId = 9,
                    Latitude = 33.535339,
                    Longitude = -94.792232
                },
                new Position()
                {
                    PositionId = 10,
                    Latitude = 32.234235,
                    Longitude = -100.222222
                }
            };
        }
    }
}
