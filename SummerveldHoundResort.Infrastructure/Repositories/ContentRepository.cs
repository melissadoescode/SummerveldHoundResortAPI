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
    public class ContentRepository : DbConnectionDevRepository, IContentRepository
    {
        public ContentRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {

        }

        public async Task<int> Create(Content content)
        {
            return await DbConnection.ExecuteAsync("CreateContent",
                new
                {
                    AlbumId = content.AlbumId,
                    ContentUpload = content.ContentUpload,
                    ContentDescription = content.ContentDescription,
                    ContentDateCreated = DateTime.Now
                }, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Content>> GetAll()
        {
            var get = await DbConnection.QueryAsync<Content>("GetAllContents", commandType: CommandType.StoredProcedure);
            return get.ToList();
        }

        public async Task<Content> GetById(int contentId)
        {
            var getById = await DbConnection.QueryAsync<Content>("GetContentById",
                new
                {
                    ContentId = contentId
                }, commandType: CommandType.StoredProcedure);
            return getById.FirstOrDefault();
        }

        public async Task<int> Update(Content content)
        {
            return await DbConnection.ExecuteAsync("UpdateContent",
                 new
                 {
                     ContentId = content.ContentId,
                     AlbumId = content.AlbumId,
                     ContentUpload = content.ContentUpload,
                     ContentDescription = content.ContentDescription,
                     ContentDateCreated = DateTime.Now
                 }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Delete(int contentId)
        {
            return await DbConnection.ExecuteAsync("DeleteContent",
                new
                {
                    ContentId = contentId
                }, commandType: CommandType.StoredProcedure);
        }
    }
}
