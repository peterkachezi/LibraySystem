using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class RepositoryRegisterBook
    {






        public static bool AddBook(RegisterBookBLL registerBookBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    var t_RegisterBooks = new t_RegisterBooks
                    {
                        Id = Guid.NewGuid(),

                        Title = registerBookBLL.Title,

                        SubTitle = registerBookBLL.SubTitle,

                        BookNo = registerBookBLL.BookNo,

                        LanguageId = registerBookBLL.LanguageId,

                        ISBN_No = registerBookBLL.ISBN_No,

                        Edition = registerBookBLL.Edition,

                        Copies = registerBookBLL.Copies,

                        PublisherId = registerBookBLL.PublisherId,

                        PublishedYear = registerBookBLL.PublishedYear,

                        CreateDate = DateTime.Now,

                        DeliveryDate = registerBookBLL.DeliveryDate,

                        CategoryId = registerBookBLL.CategoryId,
                    };

                    context.t_RegisterBooks.Add(t_RegisterBooks);

                    return context.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }

            }
        }

        public static List<RegisterBookBLL> GetAllBooks()
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_RegisterBooks = context.t_RegisterBooks.OrderByDescending(x => x.CreateDate).ToList();

                var books = new List<RegisterBookBLL>();

                foreach (var t_RegisterBook in t_RegisterBooks)
                {
                    var book = new RegisterBookBLL();

                    book.Id = t_RegisterBook.Id;

                    book.Title = t_RegisterBook.Title;

                    book.SubTitle = t_RegisterBook.SubTitle;

                    book.BookNo = t_RegisterBook.BookNo;

                    book.LanguageId = (Guid)t_RegisterBook.LanguageId;

                    book.LanguageName = t_RegisterBook.t_Languages.LanguageName;

                    book.ISBN_No = t_RegisterBook.ISBN_No;

                    book.CreateDate = t_RegisterBook.CreateDate;

                    book.Edition = t_RegisterBook.Edition;

                    book.Copies = t_RegisterBook.Copies;

                    book.PublisherId = (Guid)t_RegisterBook.PublisherId;

                    book.PublisherName = t_RegisterBook.t_Publishers.Name;

                    book.CategoryId = (Guid)t_RegisterBook.CategoryId;

                    book.PublishedYear = t_RegisterBook.PublishedYear;

                    book.DeliveryDate = t_RegisterBook.DeliveryDate;

                    books.Add(book);
                }

                return books;
            }
        }



        public static RegisterBookBLL GetSingleBook(Guid id)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_RegisterBooks = context.t_RegisterBooks.Find(id);

                return new RegisterBookBLL
                {
                    Id = t_RegisterBooks.Id,

                    Title = t_RegisterBooks.Title,

                    SubTitle = t_RegisterBooks.SubTitle,

                    BookNo = t_RegisterBooks.BookNo,

                    LanguageId = (Guid)t_RegisterBooks.LanguageId,

                    ISBN_No = t_RegisterBooks.ISBN_No,

                    Edition = t_RegisterBooks.Edition,

                    Copies = t_RegisterBooks.Copies,

                    PublisherId = (Guid)t_RegisterBooks.PublisherId,

                    PublishedYear = t_RegisterBooks.PublishedYear,

                    CreateDate = t_RegisterBooks.CreateDate,

                    DeliveryDate = t_RegisterBooks.DeliveryDate,

                    CategoryId= (Guid)t_RegisterBooks.CategoryId,

                };
            }
        }

        public static bool EditBook(Guid id, RegisterBookBLL registerBookBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var t_RegisterBooks = context.t_RegisterBooks.Find(id);

                        t_RegisterBooks.Title = registerBookBLL.Title;

                        t_RegisterBooks.SubTitle = registerBookBLL.SubTitle;

                        t_RegisterBooks.BookNo = registerBookBLL.BookNo;

                        t_RegisterBooks.LanguageId = registerBookBLL.LanguageId;

                        t_RegisterBooks.ISBN_No = registerBookBLL.ISBN_No;

                        t_RegisterBooks.Edition = registerBookBLL.Edition;

                        t_RegisterBooks.Copies = registerBookBLL.Copies;

                        t_RegisterBooks.PublisherId = registerBookBLL.PublisherId;

                        t_RegisterBooks.PublishedYear = registerBookBLL.PublishedYear;

                        t_RegisterBooks.DeliveryDate = registerBookBLL.DeliveryDate;

                        t_RegisterBooks.CategoryId = registerBookBLL.CategoryId;

                        context.SaveChanges();

                        transaction.Commit();

                        return true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }

            }
        }







    }


}
