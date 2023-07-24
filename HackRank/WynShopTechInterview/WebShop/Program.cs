using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;


interface ICategory
{
    int Id { get; set; }
    string Name { get; set; }
    List<IProduct> Products { get; set; }
    void AddProduct(IProduct product);
}
interface IProduct
{
    int Id { get; set; }
    string Name { get; set; }
    decimal Price { get; set; }
}

interface ICompany
{
    //The top category name by product count
    string GetTopCategoryNameByProductCount();
    //The products are added to more than one category
    List<IProduct> GetProductsBelongsToMultipleCategory();
    //Top category according to the total price of its products
    (string categoryName, decimal totalValue) GetTopCategoryBySumOfProductPrices();
    //The list of categories with the sum of the prices of the products
    List<(ICategory category, decimal totalValue)> GetCategoriesWithSumOfTheProductPrices();
}

/*
 * Create Category,Product and Company classes by implementing
 * ICategory,
 * IProcduct,
 * ICompany interfaces.
 */


class Category : ICategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<IProduct> Products { get; set; }

    public Category(int id, string name)
    {
        Id = id;
        Name = name;
        Products = new List<IProduct>();
    }

    public void AddProduct(IProduct product)
    {
        Products.Add(product);
    }
}

class Product : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
}

class Company : ICompany
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ICategory> Categories { get; set; }

    public Company(int id, string name)
    {
        Id = id;
        Name = name;
        Categories = new List<ICategory>();
    }

    public void AddCategory(ICategory category)
    {
        Categories.Add(category);
    }

    public string GetTopCategoryNameByProductCount()
    {
        return Categories.OrderByDescending(c => c.Products.Count).FirstOrDefault()?.Name;
    }

    public List<IProduct> GetProductsBelongsToMultipleCategory()
    {
        return Categories
            .SelectMany(c => c.Products)
            .GroupBy(p => p)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToList();
    }

    public (string categoryName, decimal totalValue) GetTopCategoryBySumOfProductPrices()
    {
        var topCategory = Categories.Select(c => new { categoryName = c.Name, totalValue = c.Products.Sum(p => p.Price) })
            .OrderByDescending(c => c.totalValue).FirstOrDefault();

        return (topCategory?.categoryName ?? "N/A", Math.Round(topCategory?.totalValue ?? 0, 1));
    }

    public List<(ICategory category, decimal totalValue)> GetCategoriesWithSumOfTheProductPrices()
    {
        return Categories.Select(c => (category: c, totalValue: c.Products.Sum(p => p.Price))).ToList();
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        var company = new Company(1, "Company 1");
        List<IProduct> products = new List<IProduct>();
        List<ICategory> categories = new List<ICategory>();

        int n = Convert.ToInt32(Console.ReadLine().Trim());
        for (int i = 1; i <= n; i++)
        {
            var a = Console.ReadLine().Trim().Split(" ");
            products.Add(new Product(Convert.ToInt32(a[0]), a[1], Convert.ToInt32(a[2])));
        }

        int m = Convert.ToInt32(Console.ReadLine().Trim());
        for (int i = 1; i <= m; i++)
        {
            var a = Console.ReadLine().Trim().Split(" ");
            categories.Add(new Category(Convert.ToInt32(a[0]), a[1]));
        }

        int p = Convert.ToInt32(Console.ReadLine().Trim());
        for (int i = 1; i <= p; i++)
        {
            var a = Console.ReadLine().Trim().Split(" ");
            var c = categories.FirstOrDefault(x => x.Id == Convert.ToInt32(a[0]));
            var pp = products.FirstOrDefault(x => x.Id == Convert.ToInt32(a[1]));
            if (c != null && pp != null)
            {
                c.AddProduct(pp);
            }

        }

        foreach (var item in categories)
        {
            company.AddCategory(item);
        }
        var topCategory = company.GetTopCategoryNameByProductCount();
        var commonProducts = company.GetProductsBelongsToMultipleCategory();
        var mostValuableCategory = company.GetTopCategoryBySumOfProductPrices();
        var categoriesWithTotalPrices = company.GetCategoriesWithSumOfTheProductPrices();

        textWriter.WriteLine("Top category:" + topCategory);
        textWriter.WriteLine("Common products:");
        foreach (var item in commonProducts)
        {
            textWriter.WriteLine(item.Name);
        }
        textWriter.WriteLine("Most valuable category:" + mostValuableCategory.categoryName
            + " " + mostValuableCategory.totalValue.ToString("0.0", new NumberFormatInfo() { NumberDecimalSeparator = "." }));
        foreach (var item in categoriesWithTotalPrices)
        {
            textWriter.WriteLine(item.category.Name + " " + item.totalValue.ToString("0.0", new NumberFormatInfo() { NumberDecimalSeparator = "." }));
        }


        textWriter.Flush();
        textWriter.Close();
    }
}
