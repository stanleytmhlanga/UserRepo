using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Api.Domain.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string IDNumber { get; set; }
        public bool IsPassport { get; set; }
        public bool IsSuspended { get; set; }
       
        public DateTime? DateCreated { get; set; }
        public DateTime? DatePKIProvisioned { get; set; }
        public int EntityID { get; set; }
        public virtual Entity Entities { get; set; }
        public int UserStatusID { get; set; }
        public virtual UserStatus UserStatuses { get; set; }
    }
}
