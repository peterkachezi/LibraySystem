using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class RepositoryUser
    {
        public static bool AddUsers(UserBLL userBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {

                    var t_Users = new t_Users
                    {
                        Id = Guid.NewGuid(),

                        FirstName = userBLL.FirstName.Substring(0, 1).ToUpper() + userBLL.FirstName.Substring(1).ToLower(),

                        LastName = userBLL.LastName.Substring(0, 1).ToUpper() + userBLL.LastName.Substring(1).ToLower(),

                        EmailID = userBLL.EmailID.Substring(0, 1).ToLower() + userBLL.EmailID.Substring(1).ToLower(),

                        Password = HashPassword.Hash(userBLL.Password),

                        ActivationCode = Guid.NewGuid(),

                        CreateDate = DateTime.Now,

                        IsEmailVerified =false,

                        MobileNumber = userBLL.MobileNumber,
                    };

                    context.t_Users.Add(t_Users);

                    return context.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }

            }
        }

        public static List<UserBLL> GetAllUsers()
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_Users = context.t_Users.OrderByDescending(x => x.CreateDate).ToList();

                var users = new List<UserBLL>();

                foreach (var t_User in t_Users)
                {
                    var user = new UserBLL();

                    user.Id = t_User.Id;

                    user.FirstName = t_User.FirstName;

                    user.LastName = t_User.LastName;

                    user.EmailID = t_User.EmailID;

                    user.CreateDate = t_User.CreateDate;

                    user.IsEmailVerified = t_User.IsEmailVerified;

                    user.MobileNumber = t_User.MobileNumber;

                    users.Add(user);
                }

                return users;
            }
        }



        public static UserBLL GetSingleUser(Guid id)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_Users = context.t_Users.Find(id);

                return new UserBLL
                {
                    Id = t_Users.Id,

                    FirstName = t_Users.FirstName,

                    LastName = t_Users.LastName,

                    EmailID = t_Users.EmailID,

                    CreateDate = t_Users.CreateDate,

                    MobileNumber = t_Users.MobileNumber,
                };
            }
        }

        public static bool EditUser(Guid id, UserBLL userBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var t_Users = context.t_Users.Find(id);

                        t_Users.FirstName = userBLL.FirstName;

                        t_Users.LastName = userBLL.LastName;

                        t_Users.EmailID = userBLL.EmailID;

                        t_Users.MobileNumber = userBLL.MobileNumber;

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


        public static bool ChangePassword(Guid PasswordResetToken, UserBLL userBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var t_Users = context.t_Users.Find(PasswordResetToken);

                        t_Users.Password = userBLL.Password;

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
