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
    public class VolunteerPreferencesRepository : DbConnectionDevRepository, IVolunteerPreferencesRepository
    {
        public VolunteerPreferencesRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
        }
        public async Task<int> Create(VolunteerPreferences volunteerPreferences)
        {
            return await DbConnection.ExecuteAsync("CreateVolunteerPrefereneces",
                new
                {
                    Preferences = volunteerPreferences.Preferences
                }, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<VolunteerPreferences>> GetAll()
        {
            var get = await DbConnection.QueryAsync<VolunteerPreferences>("GetAllVolunteerPreferences", commandType: CommandType.StoredProcedure);
            return get.ToList();
        }

        public async Task<VolunteerPreferences> GetById(int volunteerPreferencesId)
        {
            var getById = await DbConnection.QueryAsync<VolunteerPreferences>("GetVolunteerPreferencesById",
                new
                {
                    VolunteerPreferencesId = volunteerPreferencesId
                }, commandType: CommandType.StoredProcedure);
            return getById.FirstOrDefault();
        }

        public async Task<int> Update(VolunteerPreferences volunteerPreferences)
        {
            return await DbConnection.ExecuteAsync("UpdateVolunteerPreferences",
                 new
                 {
                     VolunteerPreferencesId = volunteerPreferences.VolunteerPreferencesId,
                     Preferences = volunteerPreferences.Preferences
                 }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Delete(int volunteerPreferencesId)
        {
            return await DbConnection.ExecuteAsync("DeleteVolunteerPreferences",
                new
                {
                    VolunteerPreferencesId = volunteerPreferencesId
                }, commandType: CommandType.StoredProcedure);
        }
    }
}
