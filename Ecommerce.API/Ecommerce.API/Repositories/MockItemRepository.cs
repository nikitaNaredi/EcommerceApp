using Ecommerce.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.Repositories
{
    public class MockItemRepository: IItemRepository
    {
        private List<Item> _item;
        public MockItemRepository()
        {
            _item = new List<Item>()
        {
            new Item() { Id = 1, Name = "Wheat", Category = "HR", Price = 2 },
            new Item() { Id = 2, Name = "Rice", Category = "IT", Price = 4 },
            new Item() { Id = 3, Name = "Daal", Category = "IT", Price = 0},
        };
        }

        public Page<Item> GetItems()
        {
            return new Page<Item> { Count = this._item.ToList().Count().ToString(), Value = this._item.ToList() };
        }

        public Item GetItemById(int Id)
        {
            return this._item.FirstOrDefault(e => e.Id == Id);
        }
    }
}
