using System;
using System.Collections.Generic;
using System.Text;

public class Store
{
    public List<Product> Products { get; set; }
    public List<Order> Orders { get; set; }
 
    /// <summary>
    /// Формирует строку со статистикой продаж продуктов
    /// Сортировка - по убыванию кол-ва проданных продуктов
    /// </summary>
    /// <param name="year">Год, за который подсчитывается статистика</param>
    public string GetProductStatistics()
    {      
        var tempSB = new StringBuilder();        
        var reportsDataString = new List<string>();
        var allProductName = new List<string>();
        var unicNameProducts = new List<string>();
        var notSortArrayProd = new List<Product>();
        var sortArrayProd = new List<Product>();
        var tempProd = new Product();

        foreach (var product in Products)
        {
            allProductName.Add(product.Name);
        }

        unicNameProducts = allProductName.Distinct().ToList();
        for (int i = 0; i < unicNameProducts.Count; i++)
        {
            double countItem = 0;            
            foreach (Product product in Products)
            {                
                if (product.Name == unicNameProducts[i].ToString())
                {
                    countItem++;
                }
            }
            tempProd = new Product();
            tempProd.Id = i;
            tempProd.Name = unicNameProducts[i];
            tempProd.Price = countItem;
            notSortArrayProd.Add(tempProd);
        }       

        for (int i = 0; i < notSortArrayProd.Count; i++)
        {   
            for (int j = i + 1; j < notSortArrayProd.Count; j++)
            {
                if (notSortArrayProd[i].Price < notSortArrayProd[j].Price)
                {
                        tempProd = notSortArrayProd[i];
                        notSortArrayProd[i] = notSortArrayProd[j];
                        notSortArrayProd[j] = tempProd;
                }
            }
        }
        for (int i = 0; i < notSortArrayProd.Count; i++)
        {
            tempSB.Append($"{i + 1}) - {notSortArrayProd[i].Name.ToString()} - {notSortArrayProd[i].Price.ToString()} item(s)\r\n");
        }
        return tempSB.ToString();
    }
 
    /// <summary>
    /// Формирует строку со статистикой продаж продуктов по годам
    /// Сортировка - по убыванию годов.
    /// Выводятся все года, в которых были продажи продуктов
    /// </summary>
    public string GetYearsStatistics(int year)
    {


        // Формат результата:
        // {Год} - {На какую сумму продано продуктов руб\r\n
        // Most selling: -{Название самого продаваемого продукта} (кол-во проданных единиц самого популярного продукта шт.)\r\n
        // \r\n
        //
        // Пример:
        //
        // 2021 - 630.000 руб.
        // Most selling: Product 1 (380 item(s))
        //
        // 2020 - 630.000 руб.
        // Most selling: Product 1 (380 item(s))
        //
        // 2019 - 130.000 руб.
        // Most selling: Product 3 (10 item(s))
        //
        // 2018 - 50.000 руб.
        // Most selling: Product 3 (5 item(s))
         
        // TODO Реализовать логику получения и формирования требуемых данных        
 
        return "";
    }
}
 
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}
 
public class Order
{
    public int UserId { get; set; }
    public List<OrderItem> Items { get; set; }
    public DateTime OrderDate { get; set; }
 
    public class OrderItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
 
public class Program
{
    static void Main(string[] args)
    {         
        // ПРИМЕР того, каким образом мы будем заполнять коллекции
        // НЕ является тестовым примером
        var store = new Store
        {
            Products = new List<Product>
            {
                new() { Id = 1, Name = "Product 3", Price = 1000d },
                new() { Id = 2, Name = "Product 1", Price = 3000d },
                new() { Id = 4, Name = "Product 2", Price = 10000d },
                new() { Id = 5, Name = "Product 1", Price = 10000d },
                new() { Id = 6, Name = "Product 1", Price = 10000d },
                new() { Id = 7, Name = "Product 1", Price = 10000d },
                new() { Id = 8, Name = "Product 1", Price = 10000d },
                new() { Id = 9, Name = "Product 1", Price = 10000d },
                new() { Id = 10, Name = "Product 1", Price = 10000d },
                 new() { Id = 11, Name = "Product 4", Price = 10000d },
                  new() { Id = 12, Name = "Product 4", Price = 10000d },
                   new() { Id = 13, Name = "Product 4", Price = 10000d },
                    new() { Id = 14, Name = "Product 4", Price = 10000d },
                     new() { Id = 15, Name = "Product 4", Price = 10000d },
                      new() { Id = 16, Name = "Product 4", Price = 10000d },
                       new() { Id = 17, Name = "Product 4", Price = 10000d },
                        new() { Id = 18, Name = "Product 4", Price = 10000d },

            },
            Orders = new List<Order>
            {
                new()
                {
                    UserId = 1,
                    OrderDate = DateTime.UtcNow,
                    Items = new List<Order.OrderItem>
                    {
                        new() { ProductId = 1, Quantity = 2 }
                    }
                },
                new()
                {
                    UserId = 1,
                    OrderDate = DateTime.UtcNow,
                    Items = new List<Order.OrderItem>
                    {
                        new() { ProductId = 1, Quantity = 1 },
                        new() { ProductId = 2, Quantity = 1 },
                        new() { ProductId = 3, Quantity = 1 }
                    }
                }
            }
        };
 
        Console.WriteLine(store.GetProductStatistics());
        Console.WriteLine(store.GetYearsStatistics(2021));
    }
}