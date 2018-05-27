using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SteelLiquid.Entity.eBay
{
    public interface ITask
    {
        Task<IEnumerable<Task>> SelectAllAsync(Task c = null);
        Task<IEnumerable<Task>> ReadAsync(int id);
        Task<int> UpdateAsync(Task c = null);
        Task<int> InsertAsync(Task c = null);
        Task<int> DeleteAsync(int id);
    }
}
