using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class RepositoryReturnedBook
    {

        public static List<ReturnBookBLL> GetAllReturnedBooks()
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_ReturnedBooks = context.t_ReturnedBooks.OrderByDescending(x => x.ReturnedDate).ToList();

                var returnedbooks = new List<ReturnBookBLL>();

                foreach (var t_ReturnedBook in t_ReturnedBooks)
                {
                    var returnedbook = new ReturnBookBLL();

                    returnedbook.Id = t_ReturnedBook.Id;

                    returnedbook.BookNo = t_ReturnedBook.BookNo;

                    returnedbook.Title = t_ReturnedBook.t_RegisterBooks.Title;

                    returnedbook.ISBN_No = t_ReturnedBook.t_RegisterBooks.ISBN_No;

                    returnedbook.BookId = t_ReturnedBook.BookId;

                    returnedbook.ReturnedStatus = t_ReturnedBook.ReturnedStatus;

                    returnedbook.ReturnedDate = t_ReturnedBook.ReturnedDate;

                    returnedbooks.Add(returnedbook);
                }

                return returnedbooks;
            }
        }

    }
}
