using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class RepositoryStudent
    {
        public static bool AddStudent(StudentBLL studentBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {

                    var t_Students = new t_Students
                    {
                        Id = Guid.NewGuid(),

                        AdmNo = studentBLL.AdmNo,

                        FirstName = studentBLL.FirstName,

                        MiddleName = studentBLL.MiddleName,

                        LastName = studentBLL.LastName,

                        ClassName = studentBLL.ClassName,

                        StreamId = studentBLL.StreamId,

                        EntryTerm = studentBLL.EntryTerm,


                        EntryDate = DateTime.Now,
                    };

                    context.t_Students.Add(t_Students);

                    return context.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);

                    return false;
                }

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

                    student.StreamName = t_Student.t_Stream .Name ;

                    student.EntryDate = t_Student.EntryDate;

                    students.Add(student);
                }

                return students;
            }
        }



        public static StudentBLL GetSingleStudent(Guid id)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_Students = context.t_Students.Find(id);

                return new StudentBLL
                {
                    Id = t_Students.Id,

                    AdmNo = t_Students.AdmNo,

                    FirstName = t_Students.FirstName,

                    MiddleName = t_Students.MiddleName,

                    LastName = t_Students.LastName,

                    ClassName = t_Students.ClassName,

                    StreamId = t_Students.StreamId,

                    EntryDate = t_Students.EntryDate,
                };
            }
        }

        public static bool EditStudent(Guid id, StudentBLL studentBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var t_Students = context.t_Students.Find(id);

                        t_Students.AdmNo = studentBLL.AdmNo;

                        t_Students.FirstName = studentBLL.FirstName;

                        t_Students.MiddleName = studentBLL.MiddleName;

                        t_Students.LastName = studentBLL.LastName;

                        t_Students.ClassName = studentBLL.ClassName;

                        t_Students.StreamId = studentBLL.StreamId;

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
