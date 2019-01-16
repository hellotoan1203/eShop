using eShop.Model.Models;
using System;
using System.Collections.Generic;

namespace eShop.Data.Repositories
{
    public interface IAdHocRepository
    {
        AdHocResult AdHocQuery(string query);
    }

    public class AdHocRepository : IAdHocRepository
    {
        public AdHocResult AdHocQuery(string query)
        {
            try
            {
                using (var ctx = new eShopDbContext())
                {
                    var items = new List<List<string>>();
                    var proName = new List<string>();

                    ctx.Database.Connection.Open();
                    var cmd = ctx.Database.Connection.CreateCommand();
                    cmd.CommandText = query;

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var item = new List<string>();

                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            item.Add(reader[i].ToString());
                        }

                        items.Add(item);
                    }

                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        proName.Add(reader.GetName(i));
                    }

                    return new AdHocResult()
                    {
                        Data = items,
                        Header = proName
                    };
                }
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
