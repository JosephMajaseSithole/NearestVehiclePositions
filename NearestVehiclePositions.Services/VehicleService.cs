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
                for (var x = 0; x < totalVehicles; ++x)
                {
                    vehicles[x].PositionId = binaryReader.ReadInt32();
                    vehicles[x].VehicleRegistration = binaryReader.ReadNullTerminatedASCIIstring();
                    vehicles[x].Latitude = binaryReader.ReadSingle();
                    vehicles[x].Longitude = binaryReader.ReadSingle();
                    vehicles[x].RecordedTimeUTC = binaryReader.ReadUInt64();
                }
                return vehicles.ToList();
            }
        }

        public void GetVehicleNearestToPosition(List<Position> positions, List<Vehicle> vehicles)
        {
            try
            {
                for (var positionIndex = 0; positionIndex < positions.Count; ++positionIndex)
                {
                    var vehiclePositionDistance = default(VehiclePositionDistance);
                    vehiclePositionDistance.Distance = double.MaxValue;
                    var positionCoordinate = new GeoCoordinate(positions[positionIndex].Latitude, positions[positionIndex].Longitude);
                    for (var vehicleIndex = 0; vehicleIndex < vehicles.Count; ++vehicleIndex)
                    {
                        var vehicleCoordinate = new GeoCoordinate(vehicles[vehicleIndex].Latitude, vehicles[vehicleIndex].Longitude);
                        var vehicleDistanceFromPosition = vehicleCoordinate.GetDistanceTo(positionCoordinate);
                        if (vehiclePositionDistance.Distance > vehicleDistanceFromPosition)
                        {
                            vehiclePositionDistance.Distance = vehicleDistanceFromPosition;
                            vehiclePositionDistance.VehicleRegistration = vehicles[vehicleIndex].VehicleRegistration;
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
