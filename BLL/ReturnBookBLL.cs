using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReturnBookBLL
    {
        public System.Guid Id { get; set; }
        public System.Guid BorrowerId { get; set; }
        public System.Guid BookId { get; set; }
        public string BookNo { get; set; }
        public string ReturnedCopies { get; set; }
        public System.DateTime ReturnedDate { get; set; }
        public string ReturnStatus { get; set; }
                public string Title { get; set; }
        public string SubTitle { get; set; }
                public System.Guid LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string ISBN_No { get; set; }
        public string Edition { get; set; }
        public string Copies { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string BorrowerName { get; set; }
        public string AdmNo { get; set; }
        public string ReturnedStatus { get; set; }
    }
}
