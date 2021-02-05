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

        public async Task Create(Doggo doggo)
        {
            await DbConnection.ExecuteAsync("createDoggo",
                new
                {
                    DoggoId = doggo.DoggoId,
                    DoggoName = doggo.DoggoName,
                    DoggoProfilePic = doggo.DoggoProfilePic,
                    DoggoDescription  = doggo.DoggoDescription,
                    DoggoNickname = doggo.DoggoNickname,
                    DoggoDateCreated = DateTime.Now
                }, commandType: CommandType.StoredProcedure);
        }

        public async Task GetAll()
        {
            await DbConnection.QueryAsync("getAllDoggos", commandType: CommandType.StoredProcedure);
        }

        public async Task GetById(int doggoId)
        {
            await DbConnection.QueryAsync("getDoggoById", 
                new 
                { 
                    DoggoId = doggoId
                }, commandType: CommandType.StoredProcedure);
        }

        public async Task Update(Doggo doggo)
        {
            await DbConnection.ExecuteAsync("updateDoggo",
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

        public async Task Delete(int doggoId)
        {
            await DbConnection.ExecuteAsync("deleteDoggo",
                new
                {
                    DoggoId = doggoId
                }, commandType: CommandType.StoredProcedure);
        }
    }
}
