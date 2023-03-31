namespace Trucks.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using Trucks.DataProcessor.ExportDto;
    using Trucks.DataProcessor.ImportDto;
    using Trucks.Utilities.XmlConvert;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            ExportDespatcherDto[] data = context.Despatchers
                .Where(x => x.Trucks.Any())
                .Select(x => new ExportDespatcherDto()
                {
                    DespatcherName = x.Name,
                    TrucksCount = x.Trucks.Count,
                    Trucks = x.Trucks.Select(x => new ExportTruckDto()
                    {
                        RegistrationNumber = x.RegistrationNumber,
                        Make = x.MakeType.ToString(),

                    })
                    .OrderBy(x => x.RegistrationNumber).ToArray()
                })
                .OrderByDescending(x => x.TrucksCount).ThenBy(x => x.DespatcherName).ToArray();
            return XmlConvert.Serialize(data, "Despatchers");
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var data = context.Clients.Where(x => x.ClientsTrucks.Any(x => x.Truck.TankCapacity >= capacity)).ToArray()
            .Select(x => new
            {
                Name = x.Name,
                Trucks = x.ClientsTrucks.Where(ct => ct.Truck.TankCapacity >= capacity)
                        .ToArray()
                        .OrderBy(ct => ct.Truck.MakeType.ToString())
                        .ThenByDescending(ct => ct.Truck.CargoCapacity)
                        .Select(x => new
                        {
                            TruckRegistrationNumber = x.Truck.RegistrationNumber,
                            VinNumber = x.Truck.VinNumber,
                            TankCapacity = x.Truck.TankCapacity,
                            CargoCapacity = x.Truck.CargoCapacity,
                            CategoryType = x.Truck.CategoryType.ToString(),
                            MakeType = x.Truck.MakeType.ToString(),
                        })
               .ToArray()
            }).OrderByDescending(x => x.Trucks.Count())
             .ThenBy(x => x.Name)
             .Take(10)
             .ToArray();

            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }
    }
}
