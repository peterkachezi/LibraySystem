using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class RepositoryStream
    {
        public static bool AddStream (StreamBLL streamBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    var t_Stream = new t_Stream
                    {
                        Id = Guid.NewGuid(),

                        Name = streamBLL.Name,

                 

                        CreateDate = DateTime.Now,
                    };

                    context.t_Stream.Add(t_Stream);

                    return context.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);

                    return false;
                }

            }
        }

        public static List<StreamBLL> GetAllStreams()
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_Stream = context.t_Stream.OrderByDescending(x => x.CreateDate).ToList();

                var classes = new List<StreamBLL>();

                foreach (var t_Class in t_Stream)
                {
                    var studentclass = new StreamBLL();

                    studentclass.Id = t_Class.Id;

                    studentclass.Name = t_Class.Name;

    

                    studentclass.CreateDate = t_Class.CreateDate;

                    classes.Add(studentclass);
                }

                return classes;
            }
        }



        public static StreamBLL GetSingleStream(Guid id)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_Stream = context.t_Stream.Find(id);

                return new StreamBLL
                {
                    Id = t_Stream.Id,

                    Name = t_Stream.Name,

          

                    CreateDate = t_Stream.CreateDate,
                };
            }
        }

        public static bool EditClass(Guid id, StreamBLL streamBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var t_Stream = context.t_Stream.Find(id);

                        t_Stream.Name = streamBLL.Name;

           

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
