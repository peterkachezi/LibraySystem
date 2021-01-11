using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class RepositoryAuthor
    {
        public static bool AddAuthor(AuthorBLL  authorBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    var t_Authors = new t_Authors 
                    {
                        Id = Guid.NewGuid(),

                        Name  = authorBLL .Name ,

                        Createdby_Id =authorBLL .Createdby_Id ,

                        CreateDate = DateTime.Now,
                    };

                    context.t_Authors.Add(t_Authors );

                    return context.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }

            }
        }


        public static List<AuthorBLL> GetAllAuthors()
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_Authors = context.t_Authors.OrderByDescending(x => x.CreateDate).ToList();

                var authors = new List<AuthorBLL>();

                foreach (var t_Author in t_Authors)
                {
                    var author = new AuthorBLL();

                    author.Id = t_Author.Id;

                    author.Name = t_Author.Name;

                    author.CreateDate = t_Author.CreateDate;

                    authors.Add(author);
                }

                return authors;
            }
        }





        public static AuthorBLL  GetSingleAuthor(Guid id)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_Authors = context.t_Authors .Find(id);

                return new AuthorBLL 
                {
                    Id = t_Authors.Id,

                    Name = t_Authors.Name,

                    Createdby_Id  = (Guid)t_Authors.Createdby_Id ,

                    CreateDate = t_Authors.CreateDate,
                };
            }
        }

        public static bool EditAuthor(Guid id, AuthorBLL  authorBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var t_Authors = context.t_Authors.Find(id);

                        t_Authors.Name = authorBLL .Name ;

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
