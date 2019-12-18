using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Api.Domain.Models
{
    public class TokenEntity
    {
        [Key]
        public int TokenId { get; set; }

        public int UserId { get; set; }
        public string AuthToken { get; set; }
        public DateTime IssuedOn { get; set; }

        public DateTime ExpiresOn { get; set; }
    }
}
