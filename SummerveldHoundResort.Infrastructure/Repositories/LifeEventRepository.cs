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
    public class LifeEventRepository : DbConnectionDevRepository, ILifeEventRepository
    {
        public LifeEventRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {

        }

        public async Task<int> Create(LifeEvent lifeEvent)
        {
            return await DbConnection.ExecuteAsync("CreateLifeEvent",
                new
                {
                    DoggoId = lifeEvent.DoggoId, 
                    IconId = lifeEvent.IconId, 
                    LifeEventName = lifeEvent.LifeEventName, 
                    LifeEventDate = lifeEvent.LifeEventDate, 
                    LifeEventDateCreated = DateTime.Now
                }, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<LifeEvent>> GetAll()
        {
            var get = await DbConnection.QueryAsync<LifeEvent>("GetAllLifeEvents", commandType: CommandType.StoredProcedure);
            return get.ToList();
        }

        public async Task<LifeEvent> GetById(int lifeEventId)
        {
            var getById = await DbConnection.QueryAsync<LifeEvent>("GetLifeEventById",
                new
                {
                    LifeEventId = lifeEventId
                }, commandType: CommandType.StoredProcedure);
            return getById.FirstOrDefault();
        }

        public async Task<List<LifeEventViewModel>> GetLifeEventById(int doggoId)
        {
            var getById = await DbConnection.QueryAsync<LifeEventViewModel>("GetLifeEventByDoggoId",
                 new
                 {
                     DoggoId = doggoId
                 }, commandType: CommandType.StoredProcedure);
            return getById.ToList();
        }

        public async Task<int> Update(LifeEvent lifeEvent)
        {
            return await DbConnection.ExecuteAsync("UpdateLifeEvent",
                 new
                 {
                     LifeEventId = lifeEvent.LifeEventId,
                     DoggoId = lifeEvent.DoggoId,
                     IconId = lifeEvent.IconId,
                     LifeEventName = lifeEvent.LifeEventName,
                     LifeEventDate = lifeEvent.LifeEventDate,
                     LifeEventDateCreated = DateTime.Now
                 }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Delete(int lifeEventId)
        {
            return await DbConnection.ExecuteAsync("DeleteLifeEvent",
                new
                {
                    LifeEventId = lifeEventId
                }, commandType: CommandType.StoredProcedure);
        }
    }
}
