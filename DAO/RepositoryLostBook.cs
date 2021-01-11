using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class RepositoryLostBook
    {

        public static bool LostBook(LostBookBLL lostBookBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    var t_LostBooks = new t_LostBooks
                    {
                        Id = Guid.NewGuid(),

                        BookId = lostBookBLL.BookId,

                        BookNo = lostBookBLL.BookNo,

                        BorrowerId = lostBookBLL.BorrowerId,

                        ReportedBy_Id = lostBookBLL.ReportedBy_Id,

                        DateReported = DateTime.Now,
                    };

                    context.t_LostBooks.Add(t_LostBooks);

                    return context.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }

            }
        }


        public static List<LostBookBLL> GetAllLostBooks()
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_LostBooks = context.t_LostBooks.OrderByDescending(x => x.DateReported).ToList();

                var lostBooks = new List<LostBookBLL>();

                foreach (var t_LostBook in t_LostBooks)

                {
                    var lostbook = new LostBookBLL();

                    lostbook.Id = t_LostBook.Id;

                    lostbook.BookNo = t_LostBook.BookNo;

                    lostbook.Title = t_LostBook.t_RegisterBooks.Title;

                    lostbook.ISBN_No = t_LostBook.t_RegisterBooks.ISBN_No;

                    lostbook.BookId = t_LostBook.BookId;

                    lostbook.Name = t_LostBook.t_Students.FirstName +" "+ t_LostBook.t_Students.LastName;
                              
                    lostbook.DateReported = t_LostBook.DateReported;

                    lostBooks.Add(lostbook);
                }

                return lostBooks;
            }
        }









    }


}
