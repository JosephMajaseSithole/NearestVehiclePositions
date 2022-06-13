using Geolocation;
using NearestVehiclePositions.Core.Interfaces;
using NearestVehiclePositions.Core.Models;
using NearestVehiclePositions.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NearestVehiclePositions.Services
{
    public class VehicleService : IVehicleService
    {
        public IEnumerable<Vehicle> GetVehicles()
        {
            using (var binaryReader = new BinaryReader(File.Open(AppConfig.GetDataFilePath(), FileMode.Open)))
            {
                var length = binaryReader.BaseStream.Length;
                Vehicle vehicle = default;
                while (binaryReader.BaseStream.Position < length)
                {
                    vehicle.PositionId = binaryReader.ReadInt32();
                    vehicle.VehicleRegistration = binaryReader.ReadNullTerminatedASCIIstring();
                    vehicle.Latitude = binaryReader.ReadSingle();
                    vehicle.Longitude = binaryReader.ReadSingle();
                    vehicle.RecordedTimeUTC = binaryReader.ReadUInt64();
                    yield return vehicle;
                }
            }
        }

        public void GetVehicleNearestToPosition(List<Position> positions, List<Vehicle> vehicles)
        {
            try
            {
                if (positions.Any() && vehicles.Any())
                {
                    Parallel.ForEach(positions, position =>
                    {
                        var nearestVehicle = vehicles
                               .OrderBy(vehicle => GeoCalculator.GetDistance(position.Latitude, position.Longitude, vehicle.Latitude, vehicle.Longitude))
                               .Select(v => v)
                               .First();

                        Console.WriteLine($"Vehicle Registration: {nearestVehicle.VehicleRegistration} is closest to Position: {position.PositionId}");
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
