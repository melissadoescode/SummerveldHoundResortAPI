using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerveldHoundResort.Infrastructure.Models
{
    public class Volunteer
    {
        public int VolunteerId { get; set; }
        public int VolunteerPreferencesId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Allergies { get; set; }
        public string Reason { get; set; }
        public bool OtherOrganizations { get; set; }
        public string ReferenceName { get; set; }
        public string ReferencePhone { get; set; }
        public string ReferenceRelationship { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public bool Liability { get; set; }
    }
}
