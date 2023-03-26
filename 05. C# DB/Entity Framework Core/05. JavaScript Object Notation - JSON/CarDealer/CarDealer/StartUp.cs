using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace CarDealer
{
    public class StartUp
    {
        static readonly IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));

        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            Console.WriteLine(GetCarsFromMakeToyota(context));
        }

        // 09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson)!;

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        // 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)!;

            ICollection<Part> partsToAdd = new List<Part>();
            foreach (var part in parts)
            {
                if (context.Suppliers.Any(s => s.Id == part.SupplierId))
                {
                    partsToAdd.Add(part);
                }
            }

            context.AddRange(partsToAdd);
            context.SaveChanges();

            return $"Successfully imported {partsToAdd.Count}.";
        }

        // 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carDtos = JsonConvert.DeserializeObject<P11_CarDto[]>(inputJson)!;

            context.AddRange(mapper.Map<Car[]>(carDtos));
            context.AddRange(GetCarParts(inputJson));
            context.SaveChanges();

            return $"Successfully imported {carDtos.Length}.";
        }
        public static PartCar[] GetCarParts(string inputJson)
        {
            JArray carsJson = JArray.Parse(inputJson);
            ICollection<P11_PartCarDto> partCars = new List<P11_PartCarDto>();
            int carId = 1;
            foreach (var car in carsJson)
            {
                foreach (var partId in car["partsId"]!)
                {
                    if (partCars.FirstOrDefault(pc => pc.PartId == partId.Value<int>() && pc.CarId == carId) == null)
                    {
                        partCars.Add(new P11_PartCarDto
                        {
                            CarId = carId,
                            PartId = partId.Value<int>()
                        });
                    }
                }
                carId++;
            }

            return mapper.Map<PartCar[]>(partCars);
        }

        // 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson)!;

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        // 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson)!;

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }

        // 14. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    c.IsYoungDriver
                })
                .ToArray();

            string result = JsonConvert.SerializeObject(customers, Formatting.Indented);

            //File.WriteAllText("../../../Results/ordered-customers.json", result);
            return result;
        }

        //15. Export Cars From Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
                var cars = context.Cars
                    .AsNoTracking()
                    .Where(c => c.Make == "Toyota")
                    .OrderBy(c => c.Model)
                    .ThenByDescending(c => c.TravelledDistance)
                    .Select(c => new
                    {
                        c.Id,
                        c.Make,
                        c.Model,
                        TraveledDistance = c.TravelledDistance
                    })
                    .ToArray();

                string result = JsonConvert.SerializeObject(cars, Formatting.Indented);

                //File.WriteAllText("../../../Results/cars-from-toyota.json", result);
                return result;
            }
        }
    }
}