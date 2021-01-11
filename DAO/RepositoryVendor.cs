using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class RepositoryVendor
    {
        public static bool AddVendor(VendorBLL vendorBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    var t_Vendors = new t_Vendors
                    {
                        Id = Guid.NewGuid(),

                        Name = vendorBLL.Name,

                        MobileNumber = vendorBLL.MobileNumber,

                        Website = vendorBLL.Website,

                        EmailAddress = vendorBLL.EmailAddress,

                        PostalAddress = vendorBLL.PostalAddress,

                        PostalCode = vendorBLL.PostalCode,

                        CreateDate = DateTime .Now ,

                        Createdby_Id = vendorBLL.Createdby_Id,

                    };

                    context.t_Vendors.Add(t_Vendors);

                    return context.SaveChanges() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }

            }
        }

        public static List<VendorBLL> GetAllVendors()
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_Vendors = context.t_Vendors.OrderByDescending(x => x.CreateDate).ToList();

                var vendors = new List<VendorBLL>();

                foreach (var t_Vendor in t_Vendors)
                {
                    var vendor = new VendorBLL();

                    vendor.Id = t_Vendor.Id;

                    vendor.Name = t_Vendor.Name;

                    vendor.MobileNumber = t_Vendor.MobileNumber;

                    vendor.Website = t_Vendor.Website;

                    vendor.EmailAddress = t_Vendor.EmailAddress;

                    vendor.PostalAddress = t_Vendor.PostalAddress;

                    vendor.PostalCode = t_Vendor.PostalCode;

                    vendor.CreateDate = t_Vendor.CreateDate;

                    vendor.Createdby_Id = (Guid)t_Vendor.Createdby_Id;

                    vendors.Add(vendor);
                }

                return vendors;
            }
        }

        public static VendorBLL GetSingleVendor(Guid id)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                var t_Vendors = context.t_Vendors.Find(id);

                return new VendorBLL
                {
                    Id = t_Vendors.Id,
                    Name = t_Vendors.Name,

                    MobileNumber = t_Vendors.MobileNumber,

                    Website = t_Vendors.Website,

                    EmailAddress = t_Vendors.EmailAddress,

                    PostalAddress = t_Vendors.PostalAddress,

                    PostalCode = t_Vendors.PostalCode,

                    CreateDate = t_Vendors.CreateDate,

                    Createdby_Id = (Guid)t_Vendors.Createdby_Id,

                };
            }
        }

        public static bool EditVendor(Guid id, VendorBLL vendorBLL)
        {
            using (StudentsEntities context = new StudentsEntities())
            {
                try
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var t_Vendors = context.t_Vendors.Find(id);

                        t_Vendors.Id = vendorBLL.Id;

                        t_Vendors.Name = vendorBLL.Name;

                        t_Vendors.MobileNumber = vendorBLL.MobileNumber;

                        t_Vendors.Website = vendorBLL.Website;

                        t_Vendors.EmailAddress = vendorBLL.EmailAddress;

                        t_Vendors.PostalAddress = vendorBLL.PostalAddress;

                        t_Vendors.PostalCode = vendorBLL.PostalCode;
                                               

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
