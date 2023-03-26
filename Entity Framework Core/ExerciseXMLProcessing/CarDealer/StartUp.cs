using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new CarDealerContext();
            //string inputXml = File.ReadAllText("../../../Datasets/sales.xml");

            string result = GetSalesWithAppliedDiscount(context);
            Console.WriteLine(result);
        }

        // Problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();

            XmlHelper xmlHelper = new XmlHelper();
            ImportSupplierDto[] supplierDtos = xmlHelper.Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");

            ICollection<Supplier> validSuppliers = new HashSet<Supplier>();
            foreach (var supplierDto in supplierDtos)
            {
                if (string.IsNullOrEmpty(supplierDto.Name))
                {
                    continue;
                }

                //Supplier supplier = new Supplier()
                //{
                //    Name = supplierDto.Name,
                //    IsImporter = supplierDto.IsImporter
                //};

                Supplier supplier = mapper.Map<Supplier>(supplierDto);
                validSuppliers.Add(supplier);
            }

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}";
        }

        // Problem 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper helper = new XmlHelper();
            ImportPartDto[] partsDtos = helper.Deserialize<ImportPartDto[]>(inputXml, "Parts");

            ICollection<Part> parts = new HashSet<Part>();
            foreach (var partDto in partsDtos)
            {
                if (!string.IsNullOrEmpty(partDto.Name)
                    && partDto.SupplierId.HasValue
                    && context.Suppliers.Any(s => s.Id == partDto.SupplierId))
                {
                    var part = mapper.Map<Part>(partDto);
                    parts.Add(part);
                }
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        // Problem 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper helper = new XmlHelper();
            ImportCarDto[] carDtos = helper.Deserialize<ImportCarDto[]>(inputXml, "Cars");

            ICollection<Car> cars = new HashSet<Car>();
            foreach (var carDto in carDtos)
            {
                if (string.IsNullOrEmpty(carDto.Make) || string.IsNullOrEmpty(carDto.Model))
                {
                    continue;
                }

                Car car = mapper.Map<Car>(carDto);
                ICollection<PartCar> parts = new HashSet<PartCar>();
                foreach (var partDto in carDto.Parts.DistinctBy(p => p.PartId))
                {
                    if (!context.Parts.Any(p => p.Id == partDto.PartId))
                        continue;

                    PartCar carPart = new PartCar()
                    {
                        PartId = partDto.PartId
                    };
                    parts.Add(carPart);
                    car.PartsCars.Add(carPart);
                }
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        // Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper helper = new XmlHelper();
            var customersDtos = helper.Deserialize<ImportCustomerDto[]>(inputXml, "Customers");

            ICollection<Customer> customers = new HashSet<Customer>();
            foreach (var customerDto in customersDtos)
            {
                var customer = mapper.Map<Customer>(customerDto);
                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        // Problem 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();

            XmlHelper helper = new XmlHelper();
            var saleDtos = helper.Deserialize<ImportSaleDto[]>(inputXml, "Sales");
            ICollection<Sale> sales = new HashSet<Sale>();
            foreach (var saleDto in saleDtos)
            {
                if (context.Cars.Any(c => c.Id == saleDto.CarId))
                {
                    var sale = mapper.Map<Sale>(saleDto);
                    sales.Add(sale);
                }
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }


        // Problem 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper helper = new XmlHelper();

            ExportCarDto[] cars = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarDto>(mapper.ConfigurationProvider)
                .ToArray();

            return helper.Serialize<ExportCarDto[]>(cars, "cars");
        }

        // Problem 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper helper = new XmlHelper();

            ExportCarBMWDto[] cars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ProjectTo<ExportCarBMWDto>(mapper.ConfigurationProvider)
                .ToArray();

            return helper.Serialize<ExportCarBMWDto>(cars, "cars");
        }

        // Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            //IMapper mapper = InitializeAutoMapper();
            XmlHelper helper = new XmlHelper();
            var localSuppliersDtos = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new ExportLocalSupplierDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            return helper.Serialize<ExportLocalSupplierDto[]>(localSuppliersDtos, "suppliers");

            //.Select(s => new
            //{
            //    s.Id,
            //    s.Name,
            //    PartsCount = s.Parts.Count
            //})
            //.ToList();

            //var xml = new XElement("suppliers",
            //    localSuppliers.Select(s => new XElement("supplier",
            //        new XAttribute("id", s.Id),
            //        new XAttribute("name", s.Name),
            //        new XAttribute("parts-count", s.PartsCount)
            //    )));

            //return xml.ToString();
        }

        // Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper helper = new XmlHelper();

            var cars = context.Cars
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ProjectTo<ExportCarWithPartsDto>(mapper.ConfigurationProvider)
                .ToArray();

            return helper.Serialize<ExportCarWithPartsDto>(cars, "cars");
        }

        // Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            XmlHelper helper = new XmlHelper();
            var tempDto = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SalesInfo = c.Sales.Select(s => new
                    {
                        Prices = c.IsYoungDriver
                            ? s.Car.PartsCars.Sum(p => Math.Round((double)p.Part.Price * 0.95, 2))
                            : s.Car.PartsCars.Sum(p => (double)p.Part.Price)
                    }).ToArray(),
                })
                .ToArray();

            ExportCustomerDto[] totalSalesDtos = tempDto
                .OrderByDescending(t => t.SalesInfo.Sum(s => s.Prices))
                .Select(t => new ExportCustomerDto()
                {
                    FullName = t.FullName,
                    BoughtCars = t.BoughtCars,
                    SpentMoney = t.SalesInfo.Sum(s => s.Prices).ToString("f2")
                })
                .ToArray();

            return helper.Serialize<ExportCustomerDto[]>(totalSalesDtos, "customers");

            //XmlHelper helper = new XmlHelper();
            //var customerDtos = context.Customers
            //    .ToArray()
            //    .Select(c => new ExportCustomerDto()
            //    {
            //        FullName = c.Name,
            //        BoughtCars = c.Sales.Count,
            //        SpentMoney = c.Sales.Sum(s => s.Car.PartsCars.Sum(pc => pc.Part.Price))
            //    })
            //    .ToArray();

            //return helper.Serialize<ExportCustomerDto[]>(customerDtos, "customers");
        }

        // Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            XmlHelper helper = new XmlHelper();
            ExportSaleDto[] salesDtos = context
                .Sales
                .Select(s => new ExportSaleDto()
                {
                    Car = new ExportCarDetailsDto()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    Discount = (int)s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = Math.Round((double)(s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - (s.Discount / 100))), 4)
                })
                .ToArray();

            return helper.Serialize<ExportSaleDto[]>(salesDtos, "sales");

            //var sales = context.Sales
            //    .Select(s => new ExportSaleDto()
            //    {
            //        Car = new ExportCarDetailsDto()
            //        {
            //            Model = s.Car.Model,
            //            Make = s.Car.Make,
            //            TraveledDistance = s.Car.TraveledDistance
            //        },
            //        Price = s.Car.PartsCars.Sum(pc => pc.Part.Price),
            //        CustomerName = s.Customer.Name,
            //        Discount = (int)s.Discount,
            //        PriceWithDiscount = Math.Round((double)(s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - (s.Discount / 100))), 4).ToString("f2")
            //        //(s.Car.PartsCars.Sum(pc => pc.Part.Price) * (1 - s.Discount / 100)).ToString("F2")
            //    })
            //    .ToArray();

            //return helper.Serialize<ExportSaleDto>(sales, "sales");
        }

        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
    }
}