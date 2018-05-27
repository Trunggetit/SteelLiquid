using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SteelLiquid.DA.Interfaces;

namespace SteelLiquid.DA.eBay
{
    public class Contacts : BaseRepository
    {
        public Contacts(IConnectionSettings connectionSettings) : base(connectionSettings)
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
                    string query = "UPDATE dbo.Contacts SET IsDeleted = 1 WHERE ID = @ID";
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

        public async Task<int> UpdateAsync(Contacts cards = null)
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

        public async Task<int> InsertAsync(Contacts cards = null)
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

        public async Task<IEnumerable<Contacts>> ReadAsync(int id)
        {
            IEnumerable<Contacts> results = Enumerable.Empty<Contacts>();

            using (var con = base.SqlConnection)
            {
                try
                {
                    con.Open();
                    var resultData = await con.GetListAsync<Contacts>(new { ID = id }).ConfigureAwait(false);
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

        public async Task<IEnumerable<Contacts>> SelectAllAsync(Contacts cards = null)
        {
            IEnumerable<Contacts> results = Enumerable.Empty<Contacts>();

            using (var con = base.SqlConnection)
            {
                try
                {
                    con.Open();
                    var resultData = await con.GetListAsync<Contacts>().ConfigureAwait(false);
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
