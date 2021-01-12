using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryBLL
    {
        public System.Guid Id { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }

    }
}
