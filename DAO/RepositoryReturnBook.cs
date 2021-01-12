using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class RepositoryReturnBook
    {

        public static bool ReturnBook(ReturnBookBLL returnBookBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    var t_ReturnedBooks = new t_ReturnedBooks
                    {
                        Id = Guid.NewGuid(),

                        BookId = returnBookBLL.BookId,

                        BookNo = returnBookBLL.BookNo,

                        ReturnedCopies = returnBookBLL.ReturnedCopies,

                        BorrowerId = returnBookBLL.BorrowerId,

                        ReturnedStatus = returnBookBLL.ReturnedStatus,

                        ReturnedDate = DateTime.Now,
                    };

                    context.t_ReturnedBooks.Add(t_ReturnedBooks);

                    return context.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }

            }
        }










    }


}
