using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class RepositoryLanguage
    {
        public static bool AddLanguage(LanguageBLL languageBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                 
                    var t_Language = new t_Languages
                    {
                        Id = Guid.NewGuid(),

                        LanguageName = languageBLL.LanguageName.Substring(0, 1).ToUpper() + languageBLL.LanguageName.Substring(1).ToLower(),

                    CreateDate = DateTime.Now,
                    };

                    context.t_Languages.Add(t_Language);

                    return context.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }

            }
        }

        public static List<LanguageBLL> GetAllLanguages()
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_Languages = context.t_Languages.OrderByDescending(x => x.CreateDate).ToList();

                var languages = new List<LanguageBLL>();

                foreach (var t_Language in t_Languages)
                {
                    var language = new LanguageBLL();

                    language.Id = t_Language.Id;

                    language.LanguageName = t_Language.LanguageName;

                    language.CreateDate = t_Language.CreateDate;

                    languages.Add(language);
                }

                return languages;
            }
        }



        public static LanguageBLL GetSingleLanguage(Guid id)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_Languages = context.t_Languages.Find(id);

                return new LanguageBLL
                {
                    Id = t_Languages.Id,

                    LanguageName = t_Languages.LanguageName,

                    CreateDate = t_Languages.CreateDate,
                };
            }
        }





        public static bool EditLanguage(Guid id, LanguageBLL languageBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var t_Languages = context.t_Languages.Find(id);
                        t_Languages.LanguageName = languageBLL.LanguageName;
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
