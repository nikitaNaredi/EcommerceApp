using Ecommerce.API.DataAccess;
using Ecommerce.API.Models;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<Item>> GetItemByIdAsync(long Id)
        {
            var item = await _context.Items.FindAsync(Id);

            if (item == null)
            {
                return null;
            }
            return item;
            
        }

        public async Task<ActionResult<IEnumerable<Item>>> GetItemsAsync()
        {
            return await _context.Items.ToListAsync();
        }
    }
}
