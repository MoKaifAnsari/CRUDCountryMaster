
using CRUDCountryMaster.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web.Mvc;

namespace CRUDCountryMaster.Controllers
{
    public class MasterController : Controller
    {
        // GET: Master
        #region CountryMaster
        public ActionResult CountryMaster()
        {
            return View();
        }
        public JsonResult InsertUpdateCountryMaster
            (string CountryID, string CountryCode, string CountryName, bool IsActive, bool StateRequired, bool PincodeRequired)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["Message"] = "";
            dic["Focus"] = "";
            dic["Status"] = "";
            try
            {
                if (CountryCode.Trim() == "")
                {
                    dic["Message"] = "Please Enter Country Code";
                    dic["Focus"] = "txtCountryCode";
                }
                if (CountryName.Trim() == "")
                {
                    dic["Message"] = "Please Enter Country Name";
                    dic["Focus"] = "txtCountryName";
                }
                else
                {
                    string[,] param = new string[,]
                    {
                         {"@CountryID",CountryID},
                         {"@CountryCode",CountryCode},
                         {"@CountryName",CountryName},
                         {"@IsActive",IsActive?"1":"0"},
                         {"@State",StateRequired?"1":"0"},
                         {"@Pincode",PincodeRequired?"1":"0"},
                    };
                    DataTable dt = Common.ExecuteProcedure("InsertUpdateCountryMaster", param);
                    if (dt.Rows.Count > 0)
                    {
                        dic["Message"] = dt.Rows[0]["Msg"].ToString();
                        dic["Focus"] = dt.Rows[0]["Focus"].ToString();
                        dic["Status"] = dt.Rows[0]["Status"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                dic["Message"] = ex.Message;
            }
            return Json(dic);
        }
        public JsonResult ShowCountryMaster(string CountryID)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["Message"] = "";
            dic["Grid"] = "";

            try
            {
                string[,] param = new string[,]
                    {
                        {"@Countryid","0"},
                          {"@Type","S" }

                     };
                DataTable dt = Common.ExecuteProcedure("USP_ShowCountryMaster", param);
                if (dt.Rows.Count > 0)
                {
                    sb.Append("<table style='padding:20px;'border='1' id='tbl' class='table-bordered table table-striped table-responsive'><tr>");
                    sb.Append("<th class='table-dark'>Action</th>");
                    sb.Append("<th class='table-dark'>CountryCode</th>");
                    sb.Append("<th class='table-dark'>CountryName</th>");

                    sb.Append("<th class='table-dark'>IsActive</th>");
                    sb.Append("<th class='table-dark'>State</th>");
                    sb.Append("<th class='table-dark'>Pincode</th></tr>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sb.Append("<tr><td><button type='button' onclick='DeleteCountryMaster(" + dt.Rows[i]["CountryID"] + ")' class='btn btn-danger'>Delete</button>" +
                            "<button type='button' onclick='EditMaster(" + dt.Rows[i]["CountryID"] + ")'class='btn btn-success'>Edit</button></td>");

                        sb.Append("<td>" + dt.Rows[i]["CountryCode"].ToString() + "</td>");
                        sb.Append("<td>" + dt.Rows[i]["CountryName"].ToString() + "</td>");

                        sb.Append("<td>" + dt.Rows[i]["IsActive"].ToString() + "</td>");
                        sb.Append("<td>" + dt.Rows[i]["State"].ToString() + "</td>");
                        sb.Append("<td>" + dt.Rows[i]["Pincode"].ToString() + "</td></tr>");
                    }
                    sb.Append("</table>");
                    dic["Grid"] = sb.ToString();
                }
            }

            catch (Exception ex)
            {
                dic["Message"] = ex.Message;
            }
            return Json(dic);
        }

        public JsonResult DeleteCountryMaster(string ID)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["Message"] = "";
            try
            {
                string[,] param = new string[,]
                 {
                    {"@CountryID", ID.ToString()},
                 };
                DataTable dt = Common.ExecuteProcedure("DeleteCountryMaster", param);
                if (dt.Rows.Count > 0)
                {
                    dic["Message"] = dt.Rows[0]["Msg"].ToString();
                }
            }
            catch (Exception ex)
            {
                dic["Message"] = ex.Message;
            }

            return Json(dic);
        }
        public JsonResult EditMaster(string ID)
        {

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["Message"] = "";
            dic["Status"] = "0";

            try
            {

                string[,] param = new string[,]
                {
                         {"@CountryID",ID.ToString()},
                         {"@Type","E" }
                };
                DataTable dt = Common.ExecuteProcedure("USP_ShowCountryMaster", param);
                if (dt.Rows.Count > 0)
                {
                    dic["CountryID"] = dt.Rows[0]["CountryID"].ToString();
                    dic["CountryCode"] = dt.Rows[0]["CountryCode"].ToString();
                    dic["CountryName"] = dt.Rows[0]["CountryName"].ToString();
                    dic["IsActive"] = dt.Rows[0]["IsActive"].ToString();
                    dic["State"] = dt.Rows[0]["State"].ToString();
                    dic["Pincode"] = dt.Rows[0]["Pincode"].ToString();
                    dic["Status"] = "1";
                }

            }
            catch (Exception ex)
            {
                dic["Message"] = ex.Message;
            }
            return Json(dic);
        }



        #endregion CountryMaster

        #region StateMaster
        public ActionResult StateMaster()
        {
            return View();
        }

        public JsonResult InsertUpdateStateMaster
            (string StateId, string Country, string StateCode, string StateName, bool IsActive)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["Message"] = "";
            dic["Focus"] = "";
            dic["Status"] = "";
            try
            {
                if (StateCode.Trim() == "")
                {
                    dic["Message"] = "Please Enter State Code";
                    dic["Focus"] = "txtStateCode";
                }
                else if (StateName.Trim() == "")
                {
                    dic["Message"] = "Please Enter State Name";
                    dic["Focus"] = "txtStateName";
                }
                else
                {
                    string[,] param = new string[,]
                    {
                         {"@StateId",StateId},
                         {"@Country",Country},
                         {"@StateCode",StateCode},
                         {"@StateName",StateName},
                         {"@IsActive",IsActive?"1":"0"}
                    };
                    DataTable dt = Common.ExecuteProcedure("InsertUpdateStateMaster", param);
                    if (dt.Rows.Count > 0)
                    {
                        dic["Message"] = dt.Rows[0]["Msg"].ToString();
                        dic["Focus"] = dt.Rows[0]["Focus"].ToString();
                        dic["Status"] = dt.Rows[0]["Status"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                dic["Message"] = ex.Message;
            }
            return Json(dic);
        }

        public JsonResult ShowStateMaster(string StateId)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["Message"] = "";
            dic["Grid"] = "";

            try
            {
                string[,] param = new string[,]
                    {
                         {"@StateId","0" },
                         {"@Type","S" }
                    };
                DataTable dt = Common.ExecuteProcedure("USP_ShowStateMaster", param);
                if (dt.Rows.Count > 0)
                {
                    sb.Append("<table style='padding:20px;' border='1' id='tbl' class='table-bordered table table-striped table-responsive'><tr>");
                    sb.Append("<th class='table-dark'>Action</th>");
                    sb.Append("<th class='table-dark'>Country</th>");
                    sb.Append("<th class='table-dark'>StateCode</th>");
                    sb.Append("<th class='table-dark'>StateName</th>");

                    sb.Append("<th class='table-dark'>Active</th>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sb.Append("<tr><td><button type='button' onclick='DeleteStateMaster(" + dt.Rows[i]["StateId"] + ")' class='btn btn-danger'>Delete</button>" +
                            "<button type='button' onclick='EditStateMaster(" + dt.Rows[i]["StateId"] + ")'class='btn btn-success'>Edit</button></td>");

                        sb.Append("<td>" + dt.Rows[i]["Country"].ToString() + "</td>");
                        sb.Append("<td>" + dt.Rows[i]["StateCode"].ToString() + "</td>");
                        sb.Append("<td>" + dt.Rows[i]["StateName"].ToString() + "</td>");

                        sb.Append("<td>" + dt.Rows[i]["IsActive"].ToString() + "</td>");
                    }
                    sb.Append("</table>");
                    dic["Grid"] = sb.ToString();
                }
            }
            catch (Exception ex)
            {
                dic["Message"] = ex.Message;
            }
            return Json(dic);
        }

        public JsonResult DeleteStateMaster(string StateID)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["Message"] = "";
            try
            {
                string[,] param = new string[,]
                 {
                    {"@StateId", StateID.ToString()},
                 };
                DataTable dt = Common.ExecuteProcedure("DeleteStateMaster", param);
                if (dt.Rows.Count > 0)
                {
                    dic["Message"] = dt.Rows[0]["Msg"].ToString();
                }
            }
            catch (Exception ex)
            {
                dic["Message"] = ex.Message;
            }

            return Json(dic);
        }

        public JsonResult EditStateMaster(string StateId)
        {

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["Message"] = "";
            dic["Status"] = "0";

            try
            {
                string[,] param = new string[,]
                    {
                         {"@StateId",StateId.ToString()},
                         {"@Type","E" }
                    };
                DataTable dt = Common.ExecuteProcedure("USP_ShowStateMaster", param);
                if (dt.Rows.Count > 0)
                {
                    dic["StateId"] = dt.Rows[0]["StateId"].ToString();
                    dic["Country"] = dt.Rows[0]["Country"].ToString();
                    dic["StateCode"] = dt.Rows[0]["StateCode"].ToString();
                    dic["StateName"] = dt.Rows[0]["StateName"].ToString();
                    dic["IsActive"] = dt.Rows[0]["IsActive"].ToString();

                    dic["Status"] = "1";
                }
            }
            catch (Exception ex)
            {
                dic["Message"] = ex.Message;
            }
            return Json(dic);
        }


        #endregion StateMaster

    }
}

