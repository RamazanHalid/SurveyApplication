using System;

namespace Survey.ENTITIES.Entity
{
    public class CompanyUser
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CellPhone { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public int CityId { get; set; }
        public bool IsManager { get; set; }
    }
}
