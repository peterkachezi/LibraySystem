using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LostBookBLL
    {
        public System.Guid Id { get; set; }
        public System.Guid BookId { get; set; }
        public System.Guid BorrowerId { get; set; }
        public System.DateTime DateReported { get; set; }
        public Nullable<System.Guid> ReportedBy_Id { get; set; }
        public string BookNo { get; set; }
        public string Title { get; set; }

        public string ISBN_No { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Name { get; set; }

    }
}
