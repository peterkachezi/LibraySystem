using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class RepositoryMember
    {
        public static bool AddMember(MemberBLL memberBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    var t_Members = new t_Members
                    {
                        Id = Guid.NewGuid(),

                        Name = memberBLL.FirstName +" "+ memberBLL.LastName,

                        CreateDate = DateTime.Now,

                        MobileNumber= memberBLL.MobileNumber,

                        MembershipNo = memberBLL.MembershipNo,
                    };

                    context.t_Members.Add(t_Members);

                    return context.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }

            }
        }

        public static List<MemberBLL> GetAllMembers()
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_Members = context.t_Members.OrderByDescending(x => x.CreateDate).ToList();

                var members = new List<MemberBLL>();

                foreach (var t_Member in t_Members)
                {
                    var member = new MemberBLL();

                    member.Id = t_Member.Id;

                    member.Name = t_Member.Name;

                    member.MobileNumber = t_Member.MobileNumber;

                    member.MembershipNo = t_Member.MembershipNo;

                    member.CreateDate = t_Member.CreateDate;

                    members.Add(member);
                }

                return members;
            }
        }



        public static MemberBLL GetSingleMember(Guid id)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_Members = context.t_Members.Find(id);

                return new MemberBLL
                {
                    Id = t_Members.Id,

                    Name = t_Members.Name,

                    MobileNumber=t_Members .MobileNumber,

                    MembershipNo =t_Members .MembershipNo ,

                    CreateDate = t_Members.CreateDate,

                };
            }
        }

        public static bool EditMember(Guid id, MemberBLL memberBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var t_Members = context.t_Members.Find(id);

                        t_Members.Name = memberBLL.Name;

                        t_Members.MobileNumber = memberBLL.MobileNumber;

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
