using Ecommerce.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.Repositories
{
    public interface IItemRepository
    {
        List<Item> GetItemsAsync();
        Item GetItemByIdAsync(int Id);
    }
}
