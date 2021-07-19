using Dapper;
using SummerveldHoundResort.Infrastructure.Interfaces;
using SummerveldHoundResort.Infrastructure.Interfaces.Dapper;
using SummerveldHoundResort.Infrastructure.Models;
using SummerveldHoundResort.Infrastructure.Models.ViewModels;
using SummerveldHoundResort.Infrastructure.Repositories.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerveldHoundResort.Infrastructure.Repositories
{
    public class AlbumRepository : DbConnectionDevRepository, IAlbumRepository
    {
        public AlbumRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {

        }

        public async Task<int> Create(Album album)
        {
            return await DbConnection.ExecuteAsync("CreateAlbum",
                new
                {
                    DoggoId = album.DoggoId,
                    AlbumName = album.AlbumName,
                    AlbumDateCreated = DateTime.Now
                }, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Album>> GetAll()
        {
            var get = await DbConnection.QueryAsync<Album>("GetAllAlbums", commandType: CommandType.StoredProcedure);
            return get.ToList();
        }

        public async Task<Album> GetById(int albumId)
        {
            var getById = await DbConnection.QueryAsync<Album>("GetAlbumById",
                new
                {
                    AlbumId = albumId
                }, commandType: CommandType.StoredProcedure);
            return getById.FirstOrDefault();
        }

        public async Task<AlbumViewModel> GetByDoggoId(int doggoId)
        {
            var getByDoggoId = await DbConnection.QueryAsync<AlbumViewModel>("GetAlbumByDoggoId",
                new
                {
                    DoggoId = doggoId
                }, commandType: CommandType.StoredProcedure);
            return getByDoggoId.FirstOrDefault();
        }

        public async Task<int> Update(Album album)
        {
            return await DbConnection.ExecuteAsync("UpdateAlbum",
                 new
                 {
                     AlbumId = album.AlbumId,
                     DoggoId = album.DoggoId,
                     AlbumName = album.AlbumName,
                     AlbumDateCreated = DateTime.Now
                 }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Delete(int albumId)
        {
            return await DbConnection.ExecuteAsync("DeleteAlbum",
                new
                {
                    AlbumId = albumId
                }, commandType: CommandType.StoredProcedure);
        }
    }
}
