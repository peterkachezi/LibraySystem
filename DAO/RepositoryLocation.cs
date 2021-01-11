using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class RepositoryLocation
    {
        public static bool AddLocation(LocationBLL locationBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    var BookLocation = new t_Location
                    {
                        Id = Guid.NewGuid(),

                        Name = locationBLL .Name,

                        Description=locationBLL .Description,

                        Createdby_Id =locationBLL .Createdby_Id ,

                        CreateDate = DateTime.Now,
                        
                    };

                    context.t_Location.Add(BookLocation);

                    return context.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }

            }
        }

        public static List<LocationBLL > GetAllLocation()
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_Locations = context.t_Location .OrderByDescending(x => x.CreateDate).ToList();

                var locations = new List<LocationBLL >();

                foreach (var t_Location in t_Locations)
                {
                    var location = new LocationBLL ();

                    location .Id = t_Location .Id;

                    location.Name = t_Location.Name;

                    location.Description = t_Location.Description;

                    location .CreateDate = t_Location .CreateDate;

                    location.Createdby_Id =(Guid) t_Location.Createdby_Id;

                    locations .Add(location);
                }

                return locations;
            }
        }



        public static LocationBLL  GetSingleLocation(Guid id)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_Location = context.t_Location .Find(id);

                return new LocationBLL 
                {
                    Id = t_Location.Id,

                    Name  = t_Location.Name,

                    Description=t_Location .Description,

                    CreateDate = t_Location.CreateDate,
                };
            }
        }


        public static bool EditLocation(Guid id, LocationBLL  locationBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var t_Location = context.t_Location.Find(id);

                        t_Location.Name  = locationBLL .Name ;

                        t_Location.Description = locationBLL.Description;

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
