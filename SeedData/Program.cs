using eShop.CoreBusiness.Models;
using eShop.DataStore.SQL.Dapper;
using System;
using System.Collections.Generic;

namespace SeedData
{
    class Program
    {
        static void Main(string[] args)
        {
            var da = new DataAccess("Data Source=(local);Initial Catalog=eShop;Integrated Security=True");
            var sql = "INSERT INTO Product VALUES(@ProductId, @Brand, @Name, @Price, @ImageLink, @Description)";

            var products = new List<Product>
            {
                new Product { ProductId = 495, Brand = "mercede", Name = "Mercede Steering Wheel", Price = 14.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/991799d3e70b8856686979f8ff6dcfe0_ra,w158,h184_pa,w158,h184.png",         Description = ""},
                new Product { ProductId = 488, Brand = "mercede", Name = "Mercede Keychain", Price = 10.29, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/d4f7d82b4858c622bb3c1cef07b9d850_ra,w158,h184_pa,w158,h184.png",               Description = ""},
                new Product { ProductId = 477, Brand = "mercede", Name = "Mercede Decal", Price = 15.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/4f731de249cbd4cb819ea7f5f4cfb5c3_ra,w158,h184_pa,w158,h184.png",                  Description = ""},
                new Product { ProductId = 468, Brand = "mercede", Name = "Mercede Headlight", Price = 14.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/4621032a92cb428ad640c105b944b39c_ra,w158,h184_pa,w158,h184.png",              Description = ""},
                new Product { ProductId = 439, Brand = "mercede", Name = "Mercede Hubcap", Price = 10.29, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/53d5f825461117c0d96946e1029510b0_ra,w158,h184_pa,w158,h184.png",                 Description = ""},
                new Product { ProductId = 414, Brand = "mercede", Name = "Mercede Software", Price = 11.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/51eacb9efebbaee39399e65ffe3d9416_ra,w158,h184_pa,w158,h184.png",               Description = "" }, 
                new Product { ProductId = 380, Brand = "mercede", Name = "Mercede Washclothe", Price = 10.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/d04e7c2ed65dabe1dca4eed9aa268e95_ra,w158,h184_pa,w158,h184.png",             Description = ""},
                new Product { ProductId = 379, Brand = "mercede", Name = "Mercede Oil Filter", Price = 14.79, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/029889b345c76a70e8bb978b73ed1a87_ra,w158,h184_pa,w158,h184.png",             Description = "﻿"},
                new Product { ProductId = 366, Brand = "mercede", Name = "Mercede Air Flow Sensor", Price = 14.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/c77ad2da76259cfd67a9a9432f635bfb_ra,w158,h184_pa,w158,h184.png",        Description = ""},
                new Product { ProductId = 354, Brand = "mercede", Name = "Mercede KeyFob", Price = 18.49, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/24517c6c81c92eda31cd32b6327c1298_ra,w158,h184_pa,w158,h184.png",                 Description = ""},
                new Product { ProductId = 353, Brand = "mercede", Name = "Mercede Seat Cover", Price = 14.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/c7d967ef502ecd79ab7ab466c4952d82_ra,w158,h184_pa,w158,h184.png",             Description = ""},
                new Product { ProductId = 339, Brand = "mercede", Name = "Mercede Camera System", Price = 14.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/ccb99ad6ac7f31a2a73454bdbda01d99_ra,w158,h184_pa,w158,h184.jpeg",         Description = ""},
                new Product { ProductId = 321, Brand = "mercede", Name = "Mercede Floor Mat", Price = 14.79, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/1ca6a4a442b9aa6b5f3d94da77d8846c_ra,w158,h184_pa,w158,h184.png",              Description = ""},
                new Product { ProductId = 320, Brand = "mercede", Name = "Mercede Dashboard", Price = 10.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/257993e12625cc45a72ec03636ffa5c5_ra,w158,h184_pa,w158,h184.jpg",              Description = ""},
                new Product { ProductId = 317, Brand = "mercede", Name = "Mercede CPU", Price = 10.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/eccb88d484b8c929fd349b0995a5dba2_ra,w158,h184_pa,w158,h184.png",                    Description = ""},
                new Product { ProductId = 309, Brand = "mercede", Name = "Mercede Windsheild Washer Fluid", Price = 8.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/c924006882e8e313d445a3a5394e4729_ra,w158,h184_pa,w158,h184.png", Description = ""},
                new Product { ProductId = 307, Brand = "mercede", Name = "Mercede Hardware Pack", Price = 10.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/3f9f894b56e0616e44c5ee01dea45217_ra,w158,h184_pa,w158,h184.png",          Description = ""},
                new Product { ProductId = 295, Brand = "mercede", Name = "Mercede Seat Heat Coil", Price = 17.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/201350fd3e173307ade44520dc87d8fb_ra,w158,h184_pa,w158,h184.png",         Description = ""},
                new Product { ProductId = 291, Brand = "mercede", Name = "Mercede Gas Cap", Price = 8.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/cf21d194ab14ee3c527d02682c358a7a_ra,w158,h184_pa,w158,h184.png",                 Description = ""},
                new Product { ProductId = 286, Brand = "mercede", Name = "Mercede Poster", Price = 17.99, ImageLink = "https://d3t32hsnjxo7q6.cloudfront.net/i/49d98e112e77d2a9a0c8fad28df89a1e_ra,w158,h184_pa,w158,h184.png",                 Description = ""}
            };
            da.ExecuteCommand(sql, products);
        }
    }
}
