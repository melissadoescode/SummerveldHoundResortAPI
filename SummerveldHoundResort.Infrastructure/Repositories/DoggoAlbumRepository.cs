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
    public class DoggoAlbumRepository : DbConnectionDevRepository, IDoggoAlbumRepository
    {
        public DoggoAlbumRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {

        }

        public async Task<int> Create(DoggoAlbum doggoAlbum)
        {
            return await DbConnection.ExecuteAsync("CreateDoggoAlbum",
                new
                {
                    DoggoId = doggoAlbum.DoggoId,
                    DoggoAlbumName = doggoAlbum.DoggoAlbumName,
                    DoggoAlbumDateCreated = DateTime.Now
                }, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<DoggoAlbum>> GetAll()
        {
            var get = await DbConnection.QueryAsync<DoggoAlbum>("GetAllDoggoAlbums", commandType: CommandType.StoredProcedure);
            return get.ToList();
        }

        public async Task<DoggoAlbum> GetById(int doggoAlbumId)
        {
            var getById = await DbConnection.QueryAsync<DoggoAlbum>("GetDoggoAlbumById",
                new
                {
                    DoggoAlbumId = doggoAlbumId
                }, commandType: CommandType.StoredProcedure);
            return getById.FirstOrDefault();
        }

        public async Task<int> Update(DoggoAlbum doggoAlbum)
        {
            return await DbConnection.ExecuteAsync("UpdateDoggoAlbum",
                 new
                 {
                     DoggoAlbumId = doggoAlbum.DoggoAlbumId,
                     DoggoId = doggoAlbum.DoggoId,
                     DoggoAlbumName = doggoAlbum.DoggoAlbumName,
                     DoggoAlbumDateCreated = DateTime.Now
                 }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Delete(int doggoAlbumId)
        {
            return await DbConnection.ExecuteAsync("DeleteDoggoAlbum",
                new
                {
                    DoggoAlbumId = doggoAlbumId
                }, commandType: CommandType.StoredProcedure);
        }
    }
}
