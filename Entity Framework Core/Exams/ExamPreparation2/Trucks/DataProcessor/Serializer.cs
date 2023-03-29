using Trucks.Utilities;

namespace Trucks.DataProcessor
{
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    using ExportDto;
    using Data;

    public class Serializer
    {
        private static XmlHelper xmlHelper;

        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            xmlHelper = new XmlHelper();
            ExportDespatcherDto[] despeDtos = context.Despatchers
                .Where(d => d.Trucks.Count >= 1)
                .Select(d => new ExportDespatcherDto()
                {
                    Name = d.Name,
                    TrucksCount = d.Trucks.Count,
                    Trucks = d.Trucks
                        .Select(t => new ExportTruckDto()
                        {
                            Make = t.MakeType.ToString(),
                            RegistrationNumber = t.RegistrationNumber
                        })
                        .OrderBy(t => t.RegistrationNumber)
                        .ToArray()
                })
                .OrderByDescending(d => d.TrucksCount)
                .ThenBy(d => d.Name)
                .ToArray();

            return xmlHelper.Serialize(despeDtos, "Despatchers");
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context.Clients
                .Include(c => c.ClientsTrucks)
                .ThenInclude(ct => ct.Truck)
                .AsNoTracking()
                .ToArray()
                .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
                .Select(c => new
                {
                    Name = c.Name,
                    Trucks = c.ClientsTrucks
                        .Where(ct => ct.Truck.TankCapacity >= capacity)
                        .Select(ct => new
                        {
                            TruckRegistrationNumber = ct.Truck.RegistrationNumber,
                            VinNumber = ct.Truck.VinNumber,
                            TankCapacity = ct.Truck.TankCapacity,
                            CargoCapacity = ct.Truck.CargoCapacity,
                            CategoryType = ct.Truck.CategoryType.ToString(),
                            MakeType = ct.Truck.MakeType.ToString()
                        })
                        .OrderBy(t => t.MakeType)
                        .ThenByDescending(t => t.CargoCapacity)
                        .ToArray()
                })
                .OrderByDescending(c => c.Trucks.Length)
                .ThenBy(c => c.Name)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(clients, Formatting.Indented);
        }
    }
}
