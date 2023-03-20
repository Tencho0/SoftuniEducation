using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();
            //var inputJson = File.ReadAllText(@"../../../Datasets/sales.json");
            var result = GetSalesWithAppliedDiscount(context);
            Console.WriteLine(result);
        }

        // Problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            ImportSuppliersDto[] suppliersToAdd = JsonConvert.DeserializeObject<ImportSuppliersDto[]>(inputJson);
            Supplier[] suppliers = mapper.Map<Supplier[]>(suppliersToAdd);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        // Problem 10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            ImportPartDto[] partsDtos = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson);
            //Part[] parts = mapper.Map<Part[]>(partsDtos
            //    .Where(p=> context.Suppliers.Any(s=> s.Id == p.SupplierId)));

            ICollection<Part> parts = new HashSet<Part>();
            foreach (var partDto in partsDtos)
            {
                if (context.Suppliers.Any(s => s.Id == partDto.SupplierId))
                {
                    Part part = mapper.Map<Part>(partDto);
                    parts.Add(part);
                }
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            //return $"Successfully imported {parts.Length}.";
            return $"Successfully imported {parts.Count}.";
        }

        // Problem 11
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsAndPartsDTO = JsonConvert.DeserializeObject<List<ImportCarDto>>(inputJson);

            List<PartCar> parts = new List<PartCar>();
            List<Car> cars = new List<Car>();

            foreach (var dto in carsAndPartsDTO)
            {
                Car car = new Car()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TraveledDistance = dto.TravelledDistance
                };
                cars.Add(car);

                foreach (var part in dto.PartsId.Distinct())
                {
                    PartCar partCar = new PartCar()
                    {
                        Car = car,
                        PartId = part,
                    };
                    parts.Add(partCar);
                }
            }

            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {cars.Count}.";
        }

        // Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            var customerDtos = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);
            var customers = mapper.Map<Customer[]>(customerDtos);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        // Problem 13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            var salesDtos = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson);
            var sales = mapper.Map<Sale[]>(salesDtos);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }

        // Problem 14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .AsNoTracking()
                .ProjectTo<ExportCustomerDto>(mapper.ConfigurationProvider).ToArray();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        // Problem 15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var carsFromMakeToyota = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToArray();

            return JsonConvert.SerializeObject(carsFromMakeToyota, Formatting.Indented);
        }


        // Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        // Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TraveledDistance
                    },
                    parts = c.PartsCars
                        .Select(pc => new
                        {
                            pc.Part.Name,
                            Price = pc.Part.Price.ToString("f2")
                        })
                        .ToArray()
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }


        // Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            //var customers = context.Customers
            //    .Include(c => c.Sales)
            //    .ThenInclude(c => c.Car)
            //    .ThenInclude(c => c.PartsCars)
            //    .ThenInclude(c => c.Part)
            //    .Where(c => c.Sales.Count >= 1)
            //    .ToArray()
            //    .Select(c => new
            //    {
            //        fullName = c.Name,
            //        boughtCars = c.Sales.Count,
            //        spentMoney = c.Sales.Sum(s => s.Car.PartsCars.Sum(pc => pc.Part.Price))
            //    })
            //    .OrderByDescending(c => c.spentMoney)
            //    .ThenByDescending(c => c.boughtCars)
            //    .ToArray();

            //return JsonConvert.SerializeObject(customers, Formatting.Indented);

            //var salesByCustomers = context.Customers
            //    .Include(c => c.Sales)
            //    .ThenInclude(c => c.Car)
            //    .ThenInclude(c => c.PartsCars)
            //    .ThenInclude(c => c.Part)
            //    .Where(c => c.Sales.Count >= 1)
            //    .ToArray()
            //    .Select(c => new
            //    {
            //        fullName = c.Name,
            //        boughtCars = c.Sales.Count,
            //        spentMoney = c.Sales.Sum(s => s.Car.PartsCars.Sum(pc => pc.Part.Price))
            //    })
            //    .OrderByDescending(c => c.spentMoney)
            //    .ThenByDescending(c => c.boughtCars)
            //    .ToArray();

            //return JsonConvert.SerializeObject(salesByCustomers, Formatting.Indented);

            var customerSales = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count(),
                    salePrices = c.Sales.SelectMany(x => x.Car.PartsCars.Select(x => x.Part.Price))
                })
                .ToArray();

            var totalSalesByCustomer = customerSales.Select(t => new
            {
                t.fullName,
                t.boughtCars,
                spentMoney = t.salePrices.Sum()
            })
                .OrderByDescending(t => t.spentMoney)
                .ThenByDescending(t => t.boughtCars)
                .ToArray();

            return JsonConvert.SerializeObject(totalSalesByCustomer, Formatting.Indented);
        }

        // Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var result = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TraveledDistance
                    },
                    customerName = s.Customer.Name,
                    discount = s.Discount.ToString("f2"),
                    price = s.Car.PartsCars.Sum(pc => pc.Part.Price).ToString("f2"),
                    priceWithDiscount = (s.Car.PartsCars.Sum(pc => pc.Part.Price) * (1 - s.Discount / 100)).ToString("f2")
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }
    }
}