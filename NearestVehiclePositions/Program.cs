using Microsoft.Extensions.DependencyInjection;
using NearestVehiclePositions.Core.Interfaces;
using NearestVehiclePositions.Services;
using System;
using System.Diagnostics;

namespace NearestVehiclePositions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine();
                var serviceProvider = new ServiceCollection()
                                      .AddSingleton<IVehicleService, VehicleService>()
                                      .AddSingleton<IPositionService, PositionService>()
                                      .BuildServiceProvider();

                var vehicleService = serviceProvider.GetService<IVehicleService>();
                var positionService = serviceProvider.GetService<IPositionService>();

                var totalExecutionTime = Stopwatch.StartNew();
                var dataFileReadExecutionTime = Stopwatch.StartNew();
                var vehicles = vehicleService.GetVehicles();
                dataFileReadExecutionTime.Stop();

                var closestPositionCalculationExecutionTime = Stopwatch.StartNew();
                var positions = positionService.GetPositions();
                vehicleService.GetVehicleNearestToPosition(positions, vehicles);
                closestPositionCalculationExecutionTime.Stop();
                totalExecutionTime.Stop();

                Console.WriteLine();
                Console.WriteLine($"Data file read execution time : {dataFileReadExecutionTime.ElapsedMilliseconds} ms");
                Console.WriteLine($"Closest position calculation execution time : {closestPositionCalculationExecutionTime.ElapsedMilliseconds} ms");
                Console.WriteLine($"Total execution time : {totalExecutionTime.ElapsedMilliseconds} ms");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
