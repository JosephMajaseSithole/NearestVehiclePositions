using GeoCoordinatePortable;
using NearestVehiclePositions.Core.Interfaces;
using NearestVehiclePositions.Core.Models;
using NearestVehiclePositions.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NearestVehiclePositions.Services
{
    public class VehicleService : IVehicleService
    {
        public List<Vehicle> GetVehicles()
        {
            using (var binaryReader = new BinaryReader(File.Open(AppConfig.GetDataFilePath(), FileMode.Open)))
            {
                const int totalVehicles = 2000000;
                var vehicles = new Vehicle[totalVehicles];
                for (int x = 0; x < 1000000; x += 2)
                {
                    for (int i = 0; i < 2; ++i)
                    {
                        vehicles[x + i].PositionId = binaryReader.ReadInt32();
                        vehicles[x + i].VehicleRegistration = binaryReader.ReadNullTerminatedASCIIstring();
                        vehicles[x + i].Latitude = binaryReader.ReadSingle();
                        vehicles[x + i].Longitude = binaryReader.ReadSingle();
                        vehicles[x + i].RecordedTimeUTC = binaryReader.ReadUInt64();
                    }
                }
                return vehicles.ToList();
            }
        }

        public void GetVehicleNearestToPosition(List<Position> positions, List<Vehicle> vehicles)
        {
            try
            {
                var vehicleIterations = vehicles.Count / 2;
                var totalPositions = positions.Count;
                for (var positionIndex = 0; positionIndex < totalPositions; ++positionIndex)
                {
                    var vehiclePositionDistance = default(VehiclePositionDistance);
                    vehiclePositionDistance.DistanceFromPosition = double.MaxValue;
                    var positionCoordinate = new GeoCoordinate(positions[positionIndex].Latitude, positions[positionIndex].Longitude);
                    for (var vehicleIndex = 0; vehicleIndex < vehicleIterations; vehicleIndex += 2)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            var vehicleAt = vehicleIndex + i;
                            var vehicleCoordinate = new GeoCoordinate(vehicles[vehicleAt].Latitude, vehicles[vehicleAt].Longitude);
                            var vehicleDistanceFromPosition = vehicleCoordinate.GetDistanceTo(positionCoordinate);
                            if (vehiclePositionDistance.DistanceFromPosition > vehicleDistanceFromPosition)
                            {
                                vehiclePositionDistance.DistanceFromPosition = vehicleDistanceFromPosition;
                                vehiclePositionDistance.VehicleRegistration = vehicles[vehicleAt].VehicleRegistration;
                            }
                        }
                    }
                    Console.WriteLine($"Vehicle Registration: {vehiclePositionDistance.VehicleRegistration} is closest to Position: {positions[positionIndex].PositionId}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
