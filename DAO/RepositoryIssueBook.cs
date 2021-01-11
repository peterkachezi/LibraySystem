using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class RepositoryIssueBook
    {

        public static bool ReturnBook(IssueBookBLL issueBookBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    var t_IssuedBooks = new t_IssuedBooks
                    {
                        Id = Guid.NewGuid(),

                        BookId = issueBookBLL.BookId,

                        BookNo = issueBookBLL.BookNo,

                        IssuedCopies = issueBookBLL.IssuedCopies,

                        BorrowerId = issueBookBLL.BorrowerId,

                        Status = (byte)BookStatus.Issued,

                        IssuedDate = DateTime.Now,
                    };

                    context.t_IssuedBooks.Add(t_IssuedBooks);

                    return context.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }

            }
        }



        public static List<IssueBookBLL> IssuedBooks()
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_IssuedBooks = context.t_IssuedBooks.OrderByDescending(x => x.IssuedDate).ToList();

                var books = new List<IssueBookBLL>();

                foreach (var t_IssuedBook in t_IssuedBooks)
                {
                    var book = new IssueBookBLL();

                    book.Id = t_IssuedBook.Id;

                    book.IssuedCopies = t_IssuedBook.IssuedCopies;

                    book.BookNo = t_IssuedBook.BookNo;

                    book.BorrowerId = t_IssuedBook.BorrowerId;

                    book.BookId = t_IssuedBook.BookId;

                    book.Title = t_IssuedBook.t_RegisterBooks.Title;

                    book.ISBN_No = t_IssuedBook.t_RegisterBooks.ISBN_No;

                    book.BorrowerName = t_IssuedBook.t_Students.FirstName + " " + t_IssuedBook.t_Students.LastName;

                    book.IssuedDate = t_IssuedBook.IssuedDate;

                    book.Status = (byte)BookStatus.Issued;

                    book.StatusDescription = UtilitiesBLL.GetDescription((BookStatus)(byte)t_IssuedBook.Status);

                    books.Add(book);
                }

                return books;
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

        public static IssueBookBLL GetSingleIssuedBook(Guid id)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_IssuedBooks = context.t_IssuedBooks.Find(id);

                return new IssueBookBLL
                {
                    Id = t_IssuedBooks.Id,

                    BorrowerId = t_IssuedBooks.BorrowerId,

                    BookId = t_IssuedBooks.BookId,

                    BookNo = t_IssuedBooks.BookNo,

                    IssuedCopies = t_IssuedBooks.IssuedCopies,

                    IssuedDate = t_IssuedBooks.IssuedDate,

                    BorrowerName = t_IssuedBooks.t_Students.FirstName + " " + t_IssuedBooks.t_Students.LastName,

                    AdmNo = t_IssuedBooks.t_Students.AdmNo,

                    Title = t_IssuedBooks.t_RegisterBooks.Title,

                    ISBN_No = t_IssuedBooks.t_RegisterBooks.ISBN_No,


                };
            }
        }

        public static List<StudentBLL> GetAllStudent()
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_Students = context.t_Students.OrderByDescending(x => x.EntryDate).ToList();

                var students = new List<StudentBLL>();

                foreach (var t_Student in t_Students)
                {
                    var student = new StudentBLL();

                    student.Id = t_Student.Id;

                    student.AdmNo = t_Student.AdmNo;

                    student.FirstName = t_Student.FirstName;

                    student.MiddleName = t_Student.MiddleName;

                    student.LastName = t_Student.LastName;

                    student.ClassName = t_Student.ClassName;

                    student.StreamId = t_Student.StreamId;

                    student.StreamName = t_Student.t_Stream.Name;

                    student.EntryDate = t_Student.EntryDate;

                    students.Add(student);
                }

                return students;
            }
        }

        public static bool CancelIssuedBook(Guid id, IssueBookBLL issueBookBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var t_IssuedBooks = context.t_IssuedBooks.Find(id);


                        t_IssuedBooks.Status = (byte)BookStatus.Canceled;

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
