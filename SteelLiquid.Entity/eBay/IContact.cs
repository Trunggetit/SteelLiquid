using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SteelLiquid.Entity.MTG
{
    public interface IContact
    {
        Task<IEnumerable<Contacts>> SelectAllAsync(Contacts c = null);
        Task<IEnumerable<Contacts>> ReadAsync(int id);
        Task<int> UpdateAsync(Contacts c = null);
        Task<int> InsertAsync(Contacts c = null);
        Task<int> DeleteAsync(int id);
    }
}
