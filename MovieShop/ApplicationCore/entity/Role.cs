using System.Collections.Generic;

namespace ApplicationCore.entity
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Property
        public ICollection<UserRole> UserRoles { get; set; }
    }
}