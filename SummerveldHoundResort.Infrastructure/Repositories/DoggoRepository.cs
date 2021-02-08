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
    public class DoggoRepository : DbConnectionDevRepository, IDoggoRepository
    {
        public DoggoRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {

        }

        public async Task<int> Create(Doggo doggo)
        {
            return await DbConnection.ExecuteAsync("CreateDoggo",
                new
                {
                    DoggoName = doggo.DoggoName,
                    DoggoProfilePic = doggo.DoggoProfilePic,
                    DoggoDescription  = doggo.DoggoDescription,
                    DoggoNickname = doggo.DoggoNickname,
                    DoggoDateCreated = DateTime.Now
                }, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Doggo>> GetAll()
        {
            var get = await DbConnection.QueryAsync<Doggo>("getAllDoggos", commandType: CommandType.StoredProcedure);
            return get.ToList();
        }

        public async Task<Doggo> GetById(int doggoId)
        {
            var getById = await DbConnection.QueryAsync<Doggo>("getDoggoById", 
                new 
                { 
                    DoggoId = doggoId
                }, commandType: CommandType.StoredProcedure);
            return getById.FirstOrDefault();
        }

        public async Task<int> Update(Doggo doggo)
        {
           return await DbConnection.ExecuteAsync("updateDoggo",
                new
                {
                    DoggoId = doggo.DoggoId,
                    DoggoName = doggo.DoggoName,
                    DoggoProfilePic = doggo.DoggoProfilePic,
                    DoggoDescription = doggo.DoggoDescription,
                    DoggoNickname = doggo.DoggoNickname,
                    DoggoDateCreated = DateTime.Now
                }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Delete(int doggoId)
        {
            return await DbConnection.ExecuteAsync("deleteDoggo",
                new
                {
                    DoggoId = doggoId
                }, commandType: CommandType.StoredProcedure);
        }
    }
}
