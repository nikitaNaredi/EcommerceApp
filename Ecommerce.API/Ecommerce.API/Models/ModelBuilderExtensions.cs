using Ecommerce.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.DataAccess
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                    new Item
                    {
                        Id = 1,
                        Name = "Wheat",
                        Category = "Pulses",
                        Price = 10
                    },
                    new Item
                    {
                        Id = 2,
                        Name = "Rice",
                        Category = "Pulses",
                        Price = 25
                    }
                );
        }

    }
}
