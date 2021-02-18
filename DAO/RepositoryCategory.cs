using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class RepositoryCategory
    {
        public static bool AddCategory(CategoryBLL categoryBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    var t_Categories = new t_Categories
                    {
                        Id = Guid.NewGuid(),

                        Name = categoryBLL.Name.Substring(0, 1).ToUpper() + categoryBLL.Name.Substring(1).ToLower(),

                        CreateDate = DateTime.Now,

                        CreatedBy=categoryBLL .CreatedBy ,
                    };

                    context.t_Categories.Add(t_Categories);

                    return context.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }

            }
        }

        public static List<CategoryBLL> GetAllCategories()
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_Categories = context.t_Categories.OrderByDescending(x => x.CreateDate).ToList();

                var categories = new List<CategoryBLL>();

                foreach (var t_Book_Category in t_Categories)
                {
                    var category = new CategoryBLL();

                    category.Id = t_Book_Category.Id;

                    category.Name = t_Book_Category.Name;

                    category.CreateDate = t_Book_Category.CreateDate;

                    category.CreatedBy = t_Book_Category.CreatedBy;

                    categories.Add(category);
                }

                return categories;
            }
        }



        public static CategoryBLL GetSingleCategory(Guid id)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_Categories = context.t_Categories.Find(id);

                return new CategoryBLL
                {
                    Id = t_Categories.Id,

                    Name = t_Categories.Name,

                    CreateDate = t_Categories.CreateDate,

                };
            }
        }

        public static bool EditCategory(Guid id, CategoryBLL categoryBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var t_Book_Categories = context.t_Categories.Find(id);

                        t_Book_Categories.Name = categoryBLL.Name;

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
