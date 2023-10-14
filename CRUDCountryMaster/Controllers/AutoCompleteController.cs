using CRUDCountryMaster.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDCountryMaster.Controllers
{
    public class AutoCompleteController : Controller
    {
        // GET: AutoComplete
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Index(string Prefix, string Type)
        {

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["Result"] = "";
            string[,] param = new string[,]
                       {
                         {"@Type",Type.Trim()},
                         {"@Prefix",Prefix.Trim()},

                       };
            DataTable dt = Common.ExecuteProcedure("USP_AutoComplete", param);
            if (dt.Rows.Count > 0)
            {
                List<string> Items = new List<string>();
                foreach (DataRow dr in dt.Rows)
                {
                    Items.Add(dr[0].ToString());
                }
                return Json(Items.ToArray());

            }
            return Json("");

        }
    }
}