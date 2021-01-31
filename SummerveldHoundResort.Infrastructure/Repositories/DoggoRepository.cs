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
    public class DoggoRepository : DbConnectionDevRepository, IDoggo
    {
        public DoggoRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {

        }

        public void CreateDoggo(Doggo doggo)
        {
            DbConnection.Execute("createDoggo",
                new
                {
                    DoggoId = doggo.DoggoId,
                    DoggoName = doggo.DoggoName,
                    DoggoProfilePic = doggo.DoggoProfilePic,
                    DoggoDescription  = doggo.DoggoDescription,
                    DoggoNickname = doggo.DoggoNickname,
                    DoggoDateCreated = doggo.DoggoDateCreated
                }, commandType: CommandType.StoredProcedure);
        }

        public void GetAllDoggos()
        {
            DbConnection.Query("getAllDoggos", commandType: CommandType.StoredProcedure);
        }

        public void GetDoggoById(int doggoId)
        {
            DbConnection.Query("getDoggoById", 
                new 
                { 
                    DoggoId = doggoId
                }, commandType: CommandType.StoredProcedure);
        }

        public void UpdateDoggo(Doggo doggo)
        {
            DbConnection.Execute("updateDoggo",
                new
                {
                    DoggoId = doggo.DoggoId,
                    DoggoName = doggo.DoggoName,
                    DoggoProfilePic = doggo.DoggoProfilePic,
                    DoggoDescription = doggo.DoggoDescription,
                    DoggoNickname = doggo.DoggoNickname,
                    DoggoDateCreated = doggo.DoggoDateCreated
                }, commandType: CommandType.StoredProcedure);
        }

        public void DeleteDoggo(int doggoId)
        {
            DbConnection.Execute("deleteDoggo",
                new
                {
                    DoggoId = doggoId
                }, commandType: CommandType.StoredProcedure);
        }
    }
}
