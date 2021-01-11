using BLL;
using DAO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;

namespace Software.Controllers
{
    public class BulkUploadController : Controller
    {
        // GET: BulkUpload
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase excelfile)
        {
            string filePath = string.Empty;
            if (excelfile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(excelfile.FileName);
                string extension = Path.GetExtension(excelfile.FileName);
                excelfile.SaveAs(filePath);

                string conString = string.Empty;

                switch (extension)
                {
                    case ".xls": //Excel 97-03.
                        conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES'";
                        break;
                    case ".xlsx": //Excel 07 and above.
                        conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=YES'";
                        break;
                }

                DataTable dt = new DataTable();
                conString = string.Format(conString, filePath);

                using (OleDbConnection connExcel = new OleDbConnection(conString))
                {
                    using (OleDbCommand cmdExcel = new OleDbCommand())
                    {
                        using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                        {
                            cmdExcel.Connection = connExcel;

                            //Get the name of First Sheet.
                            connExcel.Open();
                            DataTable dtExcelSchema;
                            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                            connExcel.Close();

                            //Read Data from First Sheet.
                            connExcel.Open();
                            cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                            odaExcel.SelectCommand = cmdExcel;
                            odaExcel.Fill(dt);
                            connExcel.Close();
                        }
                    }
                }

                conString = @"Persist Security Info=False;Integrated Security=true;Initial Catalog=Students;server=(local)";
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name.
                        sqlBulkCopy.DestinationTableName = "dbo.t_Bulk";

                        // Map the Excel columns with that of the database table, this is optional but good if you do
                        // 

                        sqlBulkCopy.ColumnMappings.Add("FirstName", "FirstName");
                        sqlBulkCopy.ColumnMappings.Add("LastName", "LastName");
                        sqlBulkCopy.ColumnMappings.Add("Age", "Age");

                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                    }
                }
            }
            //if the code reach here means everthing goes fine and excel data is imported into database
            ViewBag.Success = "File Imported and excel data saved into database";

            return View();
        }

        [HttpPost]
        public ActionResult Import(HttpPostedFileBase excelfile)
        {


            if (excelfile == null || excelfile.ContentLength == 0)
            {
                ViewBag.Error = "Please upload excel file";
                return View("Index");
            }
            else
            {
                if (excelfile.FileName.EndsWith("xls") || excelfile.FileName.EndsWith("xlsx"))
                {

                    string path = Server.MapPath("~/Content/" + excelfile.FileName);


                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                    excelfile.SaveAs(path);

                    //read data from excel file
                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(path);
                    Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Excel.Range range = worksheet.UsedRange;

                    List<BulkBLL> listContacts = new List<BulkBLL>();
                    for (int row = 3; row < range.Rows.Count; row++)
                    {
                        BulkBLL contact = new BulkBLL();
                        // contact.Id = ((Excel.Range)range.Cells[row, 1]).Text;
                        contact.FirstName = ((Excel.Range)range.Cells[row, 1]).Text;
                        contact.LastName = ((Excel.Range)range.Cells[row, 2]).Text;
                        contact.Age = ((Excel.Range)range.Cells[row, 3]).Text;
                        listContacts.Add(contact);

                    }


                    ViewBag.ListContacts = listContacts;

                    return View("success");
                }
                else
                {
                    ViewBag.Error = "File type is incorrect";
                    return View();
                }


            }




        }


        public ActionResult Upload(FormCollection formCollection)
        {
            var contactList = new List<t_Bulk>();
            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["UploadedFile"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                    ExcelPackage.LicenseContext = LicenseContext.Commercial;

                    // If you use EPPlus in a noncommercial context
                    // according to the Polyform Noncommercial license:
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;
                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            var BulkBLL = new t_Bulk();
                            BulkBLL.FirstName = workSheet.Cells[rowIterator, 1].Value.ToString();
                            BulkBLL.LastName = workSheet.Cells[rowIterator, 2].Value.ToString();
                            BulkBLL.Age = workSheet.Cells[rowIterator, 2].Value.ToString();
                            contactList.Add(BulkBLL);
                        }
                    }
                }
            }
            using (StudentsEntities studentsEntities = new StudentsEntities())
            {
                foreach (var item in contactList)
                { 

                    studentsEntities.t_Bulk.Add(item);
                }

                studentsEntities.SaveChanges();
            }
            ViewBag.Success = "File Imported and excel data saved into database";
            return View("Index");
        }




    }
}