using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Model;
namespace Administrator.Controllers.Admin
{
    public class SYS_MenuController : Controller
    {
        private Administrator.Controllers.Common.Common clsCommmon = new Administrator.Controllers.Common.Common();
        // GET: SYS_Menu
        public ActionResult Index()
        {
            #region Get Data
            ViewBag.GridData = clsCommmon.getListWebAPI("WS_SYS_Menu/GetAll");
            #endregion
            #region Config Data
            ViewBag.GridConfig = clsCommmon.getListWebAPI("WS_SYS_Grid/GetAllByForm/18");
            #endregion
            return View();
        }
        // GET: SYS_Menu/Create
        public ActionResult List(int idForm)
        {
            SYS_Form formConfig = null;
            if ((SYS_Form)Session["SYS_Form_" + idForm] == null)
            {
                formConfig = (SYS_Form)clsCommmon.getListWebAPI("WS_SYS_Form/GetById/" + idForm, "SYS_Form");
                Session["SYS_Form_" + idForm] = formConfig;
            }
            else
            {
                formConfig = (SYS_Form)Session["SYS_Form_" + idForm];
            }
            ViewBag.idForm = idForm;
            ViewBag.titleForm = formConfig.NameForm;
            ViewBag.helpForm = formConfig.HelpForm;
            ViewBag.ApiListData = formConfig.ApiListData;
            ViewBag.ApiData = formConfig.ApiData;
            return View();
        }
        [HttpGet]
        public string ListData(string ApiName, string DisplayText, string ValueText, string ValueChild)
        {
            try
            {
                string xmlTree = "";
                Session[ApiName] = null;
                var data = clsCommmon.getListWebAPI(ApiName);
                Session[ApiName] = data;
                xmlTree = clsCommmon.getXmlTree((IEnumerable<JObject>)Session[ApiName], DisplayText, ValueText, ValueChild);
                return xmlTree;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // POST: SYS_Menu/Create
        [HttpPost]
        public string Create(string collection)
        {
            try
            {
                var jObject = JObject.Parse(collection);
                if (clsCommmon.postObjectWebAPI(jObject, "WS_SYS_Menu/Post", "SYS_Menu"))
                {
                    return "Ok";
                }
                return "Error";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        // POST: SYS_Menu/Edit/5
        [HttpPost]
        public string Edit(int id, string collection)
        {
            try
            {
                var jObject = JObject.Parse(collection);
                if (clsCommmon.putObjectWebAPI(jObject, "WS_SYS_Menu/Put/"+id, "SYS_Menu"))
                {
                    return "Ok";
                }
                return "Error";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        // POST: SYS_Menu/Delete/5
        [HttpPost]
        public string Delete(int id)
        {
            try
            {
                if (clsCommmon.deleteObjectWebAPI("WS_SYS_Menu/Delete/" + id))
                {
                    return "Ok";
                }
                return "Error";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
