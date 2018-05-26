using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SteelLiquid.Entity.MTG
{
    public interface ICardInventory
    {
        Task<IEnumerable<CardInventory>> SelectAllAsync(CardInventory cards = null);
        Task<IEnumerable<CardInventory>> ReadAsync(int id);
        Task<int> UpdateAsync(CardInventory cards = null);
        Task<int> InsertAsync(CardInventory cards = null);
        Task<int> DeleteAsync(int id);
    }
}
