using Dapper;
using Microsoft.Extensions.Logging;
using SteelLiquid.DA.Interfaces;
using SteelLiquid.Entity;
using SteelLiquid.Entity.MTG;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelLiquid.DA
{
    public class CardInventoryDA : BaseRepository, ICardInventory
    {
        public CardInventoryDA(IConnectionSettings connectionSettings) : base(connectionSettings)
        {

        }

        public async Task<int> DeleteAsync(int id)
        {
            var results = 0;
            using (var con = base.SqlConnection)
            {
                try
                {
                    con.Open();
                    string query = "UPDATE dbo.CardInventory SET IsDeleted = 1 WHERE ID = @ID";
                    results = await con.ExecuteAsync(query, new { ID = id, IsDeleted = 1 }).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return results;
            }
        }

        public async Task<int> UpdateAsync(CardInventory cards = null)
        {
            var results = 0;

            using (var con = base.SqlConnection)
            {
                try
                {
                    con.Open();
                    results = await con.UpdateAsync(cards).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return results;
            }
        }

        public async Task<int> InsertAsync(CardInventory cards = null)
        {
            var results = 0;

            using (var con = base.SqlConnection)
            {
                try
                {
                    con.Open();
                    results = await con.InsertAsync(cards).ConfigureAwait(false) ?? 0;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return results;
            }
        }

        public async Task<IEnumerable<CardInventory>> ReadAsync(int id)
        {
            IEnumerable<CardInventory> results = Enumerable.Empty<CardInventory>();

            using (var con = base.SqlConnection)
            {
                try
                {
                    con.Open();
                    var resultData = await con.GetListAsync<CardInventory>(new { ID = id }).ConfigureAwait(false);
                    results = resultData.ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return results;
            }
        }

        public async Task<IEnumerable<CardInventory>> SelectAllAsync(CardInventory cards = null)
        {
            IEnumerable<CardInventory> results = Enumerable.Empty<CardInventory>();

            using (var con = base.SqlConnection)
            {
                try
                {
                    con.Open();
                    var resultData = await con.GetListAsync<CardInventory>().ConfigureAwait(false);
                    results = resultData.ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return results;
            }
        }
    }
}
