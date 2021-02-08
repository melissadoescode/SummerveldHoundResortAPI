using Dapper;
using SummerveldHoundResort.Infrastructure.Interfaces;
using SummerveldHoundResort.Infrastructure.Interfaces.Dapper;
using SummerveldHoundResort.Infrastructure.Models;
using SummerveldHoundResort.Infrastructure.Repositories.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerveldHoundResort.Infrastructure.Repositories
{
    public class IconRepository : DbConnectionDevRepository, IIconRepository
    {
        public IconRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {

        }

        public async Task<int> Create(Icon icon)
        {
            return await DbConnection.ExecuteAsync("CreateIcon",
                 new
                 {
                    IconSrcUrl = icon.IconSrcUrl
                 }, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Icon>> GetAll()
        {
            var get = await DbConnection.QueryAsync<Icon>("GetAllIcons", commandType: CommandType.StoredProcedure);
            return get.ToList();
        }

        public async Task<Icon> GetById(int iconId)
        {
            var getById = await DbConnection.QueryAsync<Icon>("GetIconById",
                   new
                   {
                       IconId = iconId
                   }, commandType: CommandType.StoredProcedure);
            return getById.FirstOrDefault();
        }

        public async Task<int> Update(Icon icon)
        {
            return await DbConnection.ExecuteAsync("UpdateIcon",
                  new
                  {
                      IconId = icon.IconId,
                      IconSrcUrl = icon.IconSrcUrl,
                  }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Delete(int iconId)
        {
            return await DbConnection.ExecuteAsync("DeleteIcon",
                  new
                  {
                      IconId = iconId
                  }, commandType: CommandType.StoredProcedure);
        }

    }
}
