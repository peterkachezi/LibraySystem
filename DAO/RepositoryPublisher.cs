using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class RepositoryPublisher
    {
        public static bool AddPublisher(PublisherBLL publisherBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    var t_Publishers = new t_Publishers
                    {
                        Id = Guid.NewGuid(),

                        Name = publisherBLL.Name.Substring(0, 1).ToUpper() + publisherBLL.Name.Substring(1).ToLower(),

                        CreateDate = DateTime.Now,
                    };

                    context.t_Publishers.Add(t_Publishers);

                    return context.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }

            }
        }

        public static List<PublisherBLL> GetAllPublishers()
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_Publishers = context.t_Publishers.OrderByDescending(x => x.CreateDate).ToList();

                var publishers = new List<PublisherBLL>();

                foreach (var t_Publisher in t_Publishers)
                {
                    var publisher = new PublisherBLL();

                    publisher.Id = t_Publisher.Id;

                    publisher.Name = t_Publisher.Name;

                    publisher.CreateDate = t_Publisher.CreateDate;

                    publishers.Add(publisher);
                }

                return publishers;
            }
        }



        public static PublisherBLL GetSinglePublisher(Guid id)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_Publishers = context.t_Publishers.Find(id);

                return new PublisherBLL
                {
                    Id = t_Publishers.Id,

                    Name = t_Publishers.Name,

                    CreateDate = t_Publishers.CreateDate,
                };
            }
        }

        public static bool EditPublisher(Guid id, PublisherBLL publisherBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var t_Publishers = context.t_Publishers.Find(id);
                        t_Publishers.Name = publisherBLL.Name;
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
