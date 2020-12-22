using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RegisterBookBLL
    {
        public System.Guid Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string BookNo { get; set; }
        public System.Guid LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string ISBN_No { get; set; }
        public string Edition { get; set; }
        public string Copies { get; set; }
        public System.Guid PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string PublishedYear { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public System.Guid CategoryId { get; set; }

    }
}
