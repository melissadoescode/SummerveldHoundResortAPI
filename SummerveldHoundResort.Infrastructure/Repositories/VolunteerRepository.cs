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
    public class VolunteerRepository : DbConnectionDevRepository, IVolunteerRepository
    {
        public VolunteerRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {

        }

        public async Task<int> Create(Volunteer volunteer)
        {
            return await DbConnection.ExecuteAsync("CreateVolunteer",
                new
                {
                    VolunteerPreferencesId = volunteer.VolunteerPreferencesId,
                    Name = volunteer.Name,
                    DateOfBirth = volunteer.DateOfBirth,
                    StreetAddress = volunteer.StreetAddress,
                    StreetAddress2 = volunteer.StreetAddress2,
                    City = volunteer.City,
                    Province = volunteer.Province,
                    PhoneNumber = volunteer.PhoneNumber,
                    Email = volunteer.Email,
                    JobTitle = volunteer.JobTitle,
                    Allergies = volunteer.Allergies,
                    Reason = volunteer.Reason,
                    OtherOrganizations = volunteer.OtherOrganizations,
                    ReferenceName = volunteer.ReferenceName,
                    ReferencePhone = volunteer.ReferencePhone,
                    ReferenceRelationship = volunteer.ReferenceRelationship,
                    EmergencyContactName = volunteer.EmergencyContactName,
                    EmergencyContactPhone = volunteer.EmergencyContactPhone,
                    Liability = volunteer.Liability
                }, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Volunteer>> GetAll()
        {
            var get = await DbConnection.QueryAsync<Volunteer>("GetAllAlbums", commandType: CommandType.StoredProcedure);
            return get.ToList();
        }

        public async Task<Volunteer> GetById(int volunteerId)
        {
            var getById = await DbConnection.QueryAsync<Volunteer>("GetVolunteerById",
                new
                {
                    VolunteerId = volunteerId
                }, commandType: CommandType.StoredProcedure);
            return getById.FirstOrDefault();
        }

        //public async Task<AlbumViewModel> GetByDoggoId(int doggoId)
        //{
        //    var getByDoggoId = await DbConnection.QueryAsync<AlbumViewModel>("GetAlbumByDoggoId",
        //        new
        //        {
        //            DoggoId = doggoId
        //        }, commandType: CommandType.StoredProcedure);
        //    return getByDoggoId.FirstOrDefault();
        //}

        public async Task<int> Update(Volunteer volunteer)
        {
            return await DbConnection.ExecuteAsync("UpdateVolunteer",
                 new
                 {
                     VolunteerId = volunteer.VolunteerId,
                     VolunteerPreferencesId = volunteer.VolunteerPreferencesId,
                     Name = volunteer.Name,
                     DateOfBirth = volunteer.DateOfBirth, 
                     StreetAddress = volunteer.StreetAddress, 
                     StreetAddress2 = volunteer.StreetAddress2, 
                     City = volunteer.City, 
                     Province = volunteer.Province, 
                     PhoneNumber = volunteer.PhoneNumber, 
                     Email = volunteer.Email,
                     JobTitle = volunteer.JobTitle, 
                     Allergies = volunteer.Allergies, 
                     Reason = volunteer.Reason, 
                     OtherOrganizations = volunteer.OtherOrganizations, 
                     ReferenceName = volunteer.ReferenceName, 
                     ReferencePhone = volunteer.ReferencePhone, 
                     ReferenceRelationship = volunteer.ReferenceRelationship, 
                     EmergencyContactName = volunteer.EmergencyContactName, 
                     EmergencyContactPhone = volunteer.EmergencyContactPhone, 
                     Liability = volunteer.Liability
                 }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Delete(int volunteerId)
        {
            return await DbConnection.ExecuteAsync("DeleteVolunteer",
                new
                {
                    VolunteerId = volunteerId
                }, commandType: CommandType.StoredProcedure);
        }
    }
}
