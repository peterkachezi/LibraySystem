using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AuthorBLL
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.Guid Createdby_Id { get; set; }
    }
}
