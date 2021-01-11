using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VendorBLL
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Website { get; set; }
        public string PostalAddress { get; set; }
        public string PostalCode { get; set; }
        public DateTime  CreateDate { get; set; }
        public System.Guid Createdby_Id { get; set; }
    }
}
