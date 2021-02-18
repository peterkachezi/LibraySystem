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
    public class AlartController : Controller
    {
        // GET: BulkUpload
        public ActionResult Index()
        {
            return View();
        }
    }

}