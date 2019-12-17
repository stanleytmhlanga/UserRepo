using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Api.Domain.Models
{
    public class Entity
    {
        public int EntityID { get; set; }
        public int ParentID {get;set;}
        public int MunicipalityID { get; set; }
        public int EntityTypeID { get; set; }
        public string EntityName { get; set; }
        public int DomainID { get; set; }
        public string Registration { get; set; }
        public string VAT { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string PostalAddress { get; set; }
        public string PhysicalAddress { get; set; }
        public int HostingEntityCode { get; set; }
        public DateTime DateCreated { get; set; }
        public string Logo { get; set; }
        public bool  Active { get; set; }
    }
}
