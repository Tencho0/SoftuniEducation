using System.Xml.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;

namespace ProductShop
{
    using ProductShop.Data;
    using System.Diagnostics.CodeAnalysis;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();
            //string inputXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            string result = GetUsersWithProducts(context);
            Console.WriteLine(result);
        }

        // Problem 01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper helper = new XmlHelper();

            var userDtos = helper.Deserialize<ImportUserDto[]>(inputXml, "Users");

            ICollection<User> users = new HashSet<User>();
            foreach (var userDto in userDtos)
            {
                var user = mapper.Map<User>(userDto);
                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        // There is problem with provided skeleton -> In Product Model should have nullable BuyerId, but Judge want this property to be not null

        // Problem 02
        //public static string ImportProducts(ProductShopContext context, string inputXml)
        //{
        //    XDocument productXml = XDocument.Parse(inputXml);
        //    var products = productXml.Root!.Elements();

        //    foreach (var pr in products)
        //    {
        //        Product u = new Product()
        //        {
        //            Name = pr.Element("name")!.Value,
        //            Price = decimal.Parse(pr.Element("price")!.Value),
        //            SellerId = int.Parse(pr.Element("sellerId")!.Value),
        //            BuyerId = pr.Elements().Count() > 3
        //                ? int.Parse(pr.Element("buyerId")!.Value) : 0
        //        };

        //        context.Products.Add(u);
        //    }
        //    context.SaveChanges();

        //    return $"Successfully imported {products.Count()}";
        //}
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlHelper helper = new XmlHelper();
            var productDtos = helper.Deserialize<ImportProductDto[]>(inputXml, "Products");

            Product[] products = productDtos
                .Select(p => new Product()
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerId = p.BuyerId,
                    SellerId = p.SellerId
                })
                .ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";

            //    //            IMapper mapper = InitializeAutoMapper();
            //    //            XmlHelper helper = new XmlHelper();

            //    //            var productDtos = helper.Deserialize<ImportProductDto[]>(inputXml,
            //    //"Products");

            //    //            ICollection<Product> products = new HashSet<Product>();
            //    //            foreach (var productDto in productDtos)
            //    //            {
            //    //                if (productDto.BuyerId == 0)
            //    //                    productDto.BuyerId = null;

            //    //                var product = mapper.Map<Product>(productDto);
            //    //                products.Add(product);
            //    //            }

            //    //            context.Products.AddRange(products);
            //    //            context.SaveChanges();

            //    //            return $"Successfully imported {products.Count}";
        }

        // Problem 03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper helper = new XmlHelper();
            var categoryDtos = helper.Deserialize<ImportCategoryDto[]>(inputXml, "Categories");

            ICollection<Category> categories = new HashSet<Category>();
            foreach (var categoryDto in categoryDtos)
            {
                if (categoryDto.Name != null)
                {
                    Category category = mapper.Map<Category>(categoryDto);
                    categories.Add(category);
                }
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        // Problem 04
        // There is a bug in provided skeleton in Product Model
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper helper = new XmlHelper();

            ImportCategoryProductDto[] categoryProductDtos =
                helper.Deserialize<ImportCategoryProductDto[]>(inputXml, "CategoryProducts");

            ICollection<CategoryProduct> categoryProducts = new HashSet<CategoryProduct>();
            foreach (var categoryProductDto in categoryProductDtos)
            {
                CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(categoryProductDto);
                categoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        // Problem 05
        //public static string GetProductsInRange(ProductShopContext context)
        //{
        //    IMapper mapper = InitializeAutoMapper();
        //    XmlHelper helper = new XmlHelper();
        //    var products = context.Products
        //        .Where(p => p.Price >= 500 && p.Price <= 1000)
        //        .OrderBy(p => p.Price)
        //        .Select(p => new ExportProductDto()
        //        {
        //            Price = p.Price,
        //            Name = p.Name,
        //            BuyerName = p.Buyer.FirstName + " " + p.Buyer.LastName
        //        })
        //        //.ProjectTo<ExportProductDto>(mapper.ConfigurationProvider)
        //        .Take(10)
        //        .ToArray();

        //    return helper.Serialize<ExportProductDto[]>(products, "Products");
        //}
        public static string GetProductsInRange(ProductShopContext context)
        {
            XmlHelper helper = new XmlHelper();
            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ExportProductsInRangeDto()
                {
                    Price = p.Price,
                    Name = p.Name,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .ToArray();

            return helper.Serialize<ExportProductsInRangeDto[]>(productsInRange, "Products");

        }

        // Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            XmlHelper helper = new XmlHelper();

            //var products = context.Users
            //    .Where(u => u.ProductsSold.Any(ps => ps.BuyerId != null))
            //    .OrderBy(u => u.LastName)
            //    .ThenBy(u => u.FirstName)
            //    .Take(5)
            //    .Select(u => new ExportUserWithSoldProductDto()
            //    {
            //        FirstName = u.FirstName,
            //        LastName = u.LastName,
            //        ProductsSold = u.ProductsSold
            //            .Select(ps => new ExportSoldProductDto()
            //            {
            //                Price = ps.Price,
            //                Name = ps.Name
            //            })
            //            .ToArray()
            //    })
            //    .ToArray();

            var products = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new ExportSoldProductsDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Products = u.ProductsSold
                        .Select(p => new ProductDto()
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToArray()
                })
                .ToArray();

            return helper.Serialize<ExportSoldProductsDto[]>(products, "Users");
            //return helper.Serialize<ExportUserWithSoldProductDto[]>(products, "Users");
        }

        // Problem 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            XmlHelper helper = new XmlHelper();

            var categories = context.Categories
                .Select(c => new ExportCategoryDto()
                {
                    Name = c.Name,
                    CountOfProducts = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.CountOfProducts)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            return helper.Serialize<ExportCategoryDto[]>(categories, "Categories");
        }

        // Problem 08
        //[SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records", MessageId = "count: 197")]
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            XmlHelper helper = new XmlHelper();
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new UserDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProducts()
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold
                            .Where(p => p.BuyerId != null)
                            .Select(p => new ProductX()
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .OrderByDescending(p => p.Price)
                            .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .Take(10)
                .ToArray();

            UsersDto info = new UsersDto()
            {
                Count = context.Users.Count(u => u.ProductsSold.Any(p => p.BuyerId != null)),
                UsersInfo = users
            };
            return helper.Serialize<UsersDto>(info, "Users");
        }
        //public static string GetUsersWithProducts(ProductShopContext context)
        //{
        //    XmlHelper helper = new XmlHelper();
        //    var users = context.Users
        //        .Where(u => u.ProductsSold.Any(x => x.BuyerId != null))
        //        .Select(u => new ExportUserDto()
        //        {
        //            Count = context.Users.Count(),
        //            User = new ExportUser()
        //            {
        //                Age = u.Age,
        //                FirstName = u.FirstName,
        //                LastName = u.LastName,
        //                SoldProducts = new ExportSoldProductsForUserDto()
        //                {
        //                    Count = u.ProductsSold.Count,
        //                    Products = u.ProductsSold
        //                        .Select(ps => new ExportSoldProductDto()
        //                        {
        //                            Price = ps.Price,
        //                            Name = ps.Name
        //                        })
        //                        .ToArray()
        //                }
        //            }
        //        })
        //        .OrderBy(u => u.User.SoldProducts.Count)
        //        .Take(10)
        //        .ToArray();

        //    return helper.Serialize<ExportUserDto[]>(users, "Users");
        //}

        private static IMapper InitializeAutoMapper()
        => new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductShopProfile>();
        }));
    }
}