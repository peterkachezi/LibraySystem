using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StudentBLL
    {
        public System.Guid Id { get; set; }
        public string AdmNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public System.Guid StreamId { get; set; }

        public string StreamName { get; set; }
        public string EntryTerm { get; set; }
        public System.DateTime EntryDate { get; set; }
    }
}
