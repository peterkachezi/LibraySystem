using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{


    public enum BookStatus
    {
        [Description("Active")]
        Active,
        [Description("Returned")]
        Returned,
        [Description("Canceled")]
        Canceled
    }

    public enum BorrowerType
    {
        [Description("Student")]
        Student,
        [Description("Staff")]
        Staff,
        [Description("Member")]
        Member
    }


    public class IssueBookBLL
    {
        public System.Guid Id { get; set; }
        public System.Guid BorrowerId { get; set; }
        public System.Guid BookId { get; set; }
        public string BookNo { get; set; }
        public string IssuedCopies { get; set; }
        public System.DateTime IssuedDate { get; set; }
        public string ReturnStatus { get; set; }
        public byte Status { get; set; }
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

        public string StatusDescription { get; set; }

    }
}
