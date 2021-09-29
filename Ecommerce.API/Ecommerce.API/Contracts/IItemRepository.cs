using Ecommerce.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.Repositories
{
    public interface IItemRepository
    {
        Page<Item> GetItems();
        Item GetItemById(int Id);
    }
}
