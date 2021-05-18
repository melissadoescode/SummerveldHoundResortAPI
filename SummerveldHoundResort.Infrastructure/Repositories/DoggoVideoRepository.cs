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
    public class DoggoVideoRepository : DbConnectionDevRepository, IDoggoVideoRepository
    {
        public DoggoVideoRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {

        }

        public async Task<int> Create(DoggoVideo doggoVideo)
        {
            return await DbConnection.ExecuteAsync("CreateDoggoVideo",
                new
                {
                    DoggoContentId = doggoVideo.DoggoContentId,
                    DoggoVideoUrl = doggoVideo.DoggoVideoUrl,
                    DoggoVideoDescription = doggoVideo.DoggoVideoDescription
                }, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<DoggoVideo>> GetAll()
        {
            var get = await DbConnection.QueryAsync<DoggoVideo>("GetAllDoggoVideos", commandType: CommandType.StoredProcedure);
            return get.ToList();
        }

        public async Task<DoggoVideo> GetById(int doggoVideoId)
        {
            var getById = await DbConnection.QueryAsync<DoggoVideo>("GetDoggoVideoById",
                new
                {
                    DoggoVideoId = doggoVideoId
                }, commandType: CommandType.StoredProcedure);
            return getById.FirstOrDefault();
        }

        public async Task<int> Update(DoggoVideo doggoVideo)
        {
            return await DbConnection.ExecuteAsync("UpdateDoggoVideo",
                 new
                 {
                     DoggoVideoId = doggoVideo.DoggoVideoId,
                     DoggoContentId = doggoVideo.DoggoContentId,
                     DoggoVideoUrl = doggoVideo.DoggoVideoUrl,
                     DoggoVideoDescription = doggoVideo.DoggoVideoDescription
                 }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Delete(int doggoVideoId)
        {
            return await DbConnection.ExecuteAsync("DeleteDoggoVideo",
                new
                {
                    DoggoVideoId = doggoVideoId
                }, commandType: CommandType.StoredProcedure);
        }
    }
}
