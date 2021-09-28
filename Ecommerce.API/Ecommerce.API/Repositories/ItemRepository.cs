using Ecommerce.API.DataAccess;
using Ecommerce.API.Models;
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
        public Item GetItemByIdAsync(int Id)
        {
            return _context.Items.FirstOrDefault(t => t.Id == Id);
        }

        public List<Item> GetItemsAsync()
        {
            return _context.Items.ToList();
        }
    }
}
