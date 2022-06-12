using Geolocation;
using NearestVehiclePositions.Core.Interfaces;
using NearestVehiclePositions.Core.Models;
using NearestVehiclePositions.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NearestVehiclePositions.Services
{
    public class VehicleService : IVehicleService
    {
        public List<Vehicle> GetVehicles()
        {
            var filePath = AppConfig.GetDataFilePath();
            var vehicles = new List<Vehicle>();

            try
            {
                using (var binaryReader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    var length = binaryReader.BaseStream.Length;
                    var vehicle = new Vehicle();
                    while (binaryReader.BaseStream.Position != length)
                    {
                        vehicle.PositionId = binaryReader.ReadInt32();
                        vehicle.VehicleRegistration = binaryReader.ReadNullTerminatedASCIIstring();
                        vehicle.Latitude = binaryReader.ReadSingle();
                        vehicle.Longitude = binaryReader.ReadSingle();
                        vehicle.RecordedTimeUTC = binaryReader.ReadUInt64();
                        vehicles.Add(vehicle);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }

            return vehicles.ToList();
        }

        public void GetVehicleNearestToPosition(List<Position> positions, List<Vehicle> vehicles)
        {
            try
            {
                if (positions.Any() && vehicles.Any())
                {
                    foreach (var position in positions.AsParallel())
                    {
                        var nearestVehicle = vehicles.AsParallel()
                                      .Select(vehicle => vehicle)
                                      .OrderBy(vehicle => GeoCalculator.GetDistance(position.Latitude, position.Longitude, vehicle.Latitude, vehicle.Longitude))
                                      .First();

                        Console.WriteLine($"Vehicle Registration: {nearestVehicle.VehicleRegistration} is closest to Position: {position.PositionId}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
