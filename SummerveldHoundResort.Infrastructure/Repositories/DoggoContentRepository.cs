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
    public class DoggoContentRepository : DbConnectionDevRepository, IDoggoContentRepository
    {
        public DoggoContentRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {

        }

        public async Task<int> Create(DoggoContent doggoContent)
        {
            return await DbConnection.ExecuteAsync("CreateDoggoContent",
                new
                {
                    DoggoAlbumId = doggoContent.DoggoAlbumId,
                    DoggoContentDateCreated = DateTime.Now
                }, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<DoggoContent>> GetAll()
        {
            var get = await DbConnection.QueryAsync<DoggoContent>("GetAllDoggoContents", commandType: CommandType.StoredProcedure);
            return get.ToList();
        }

        public async Task<DoggoContent> GetById(int doggoContentId)
        {
            var getById = await DbConnection.QueryAsync<DoggoContent>("GetDoggoContentById",
                new
                {
                    DoggoContentId = doggoContentId
                }, commandType: CommandType.StoredProcedure);
            return getById.FirstOrDefault();
        }

        public async Task<int> Update(DoggoContent doggoContent)
        {
            return await DbConnection.ExecuteAsync("UpdateDoggoContent",
                 new
                 {
                     DoggoContentId = doggoContent.DoggoContentId,
                     DoggoAlbumId = doggoContent.DoggoAlbumId,
                     DoggoContentDateCreated = DateTime.Now
                 }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Delete(int doggoContentId)
        {
            return await DbConnection.ExecuteAsync("DeleteDoggoContent",
                new
                {
                    DoggoContentId = doggoContentId
                }, commandType: CommandType.StoredProcedure);
        }
    }
}
