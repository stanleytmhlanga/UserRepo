using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Api.Domain.Models
{
    public class TokenEntity
    {
       public int UserID { get; set; } 
        public Guid Token { get; set; }
        public DateTime IssuedOn { get; set; }

        public DateTime ExpiresOn { get; set; }
    }
}
