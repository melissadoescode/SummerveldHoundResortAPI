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
    public class DoggoPhotoRepository : DbConnectionDevRepository, IDoggoPhotoRepository
    {
        public DoggoPhotoRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {

        }

        public async Task<int> Create(DoggoPhoto doggoPhoto)
        {
            return await DbConnection.ExecuteAsync("CreateDoggoPhoto",
                new
                {
                    DoggoContentId = doggoPhoto.DoggoContentId,
                    DoggoPhotoUrl = doggoPhoto.DoggoPhotoUrl,
                    DoggoPhotoDescription = doggoPhoto.DoggoPhotoDescription
                }, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<DoggoPhoto>> GetAll()
        {
            var get = await DbConnection.QueryAsync<DoggoPhoto>("GetAllDoggoPhotos", commandType: CommandType.StoredProcedure);
            return get.ToList();
        }

        public async Task<DoggoPhoto> GetById(int doggoPhotoId)
        {
            var getById = await DbConnection.QueryAsync<DoggoPhoto>("GetDoggoPhotoById",
                new
                {
                    DoggoPhotoId = doggoPhotoId
                }, commandType: CommandType.StoredProcedure);
            return getById.FirstOrDefault();
        }

        public async Task<int> Update(DoggoPhoto doggoPhoto)
        {
            return await DbConnection.ExecuteAsync("UpdateDoggoPhoto",
                 new
                 {
                     DoggoPhotoId = doggoPhoto.DoggoPhotoId,
                     DoggoContentId = doggoPhoto.DoggoContentId,
                     DoggoPhotoUrl = doggoPhoto.DoggoPhotoUrl,
                     DoggoPhotoDescription = doggoPhoto.DoggoPhotoDescription
                 }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Delete(int doggoPhotoId)
        {
            return await DbConnection.ExecuteAsync("DeleteDoggoPhoto",
                new
                {
                    DoggoPhotoId = doggoPhotoId
                }, commandType: CommandType.StoredProcedure);
        }
    }
}

