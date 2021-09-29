using Ecommerce.API.DataAccess;
using Ecommerce.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private AppDBContext _context { get; set; }
        public ItemRepository(AppDBContext context)
        {
            _context = context;
        }
        public Item GetItemById(int Id)
        {
            return _context.Items.FirstOrDefault(t => t.Id == Id);
        }

        public Page<Item> GetItems()
        {
            var result = new Page<Item> { Count = _context.Items.ToList().Count().ToString(), Value = _context.Items.ToList() };
            return result;
        }
    }
}
