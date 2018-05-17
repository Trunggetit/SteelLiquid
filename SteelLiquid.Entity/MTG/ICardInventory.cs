using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SteelLiquid.Entity.MTG
{
    public interface ICardInventory
    {
        Task<IEnumerable<CardInventory>> SelectAllAsync(CardInventory cards = null);
        Task<int> DelUpdateAsync(CardInventory cards = null);
        Task<int> InsertAsync(CardInventory cards = null);
    }
}
