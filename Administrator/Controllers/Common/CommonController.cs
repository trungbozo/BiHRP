using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using System.Xml;
using Model;

namespace Administrator.Controllers.Common
{
    public class CommonController : Controller
    {
        private Common clsCommmon = new Common();
        // GET: Control
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TreeView(int id)
        {
            try
            {
                #region Config For Tree
                SYS_Tree tree = (SYS_Tree)clsCommmon.getListWebAPI("WS_SYS_Tree/" + id, "Model.SYS_Tree");
                ViewBag.TreeText = tree.TextValue;
                ViewBag.TreeId = tree.IdValue;
                ViewBag.TreeChild = tree.ChildValue;
                ViewBag.TreeData = clsCommmon.getListWebAPI(tree.ApiName);
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }
        public ActionResult Grid(int id)
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }
        [HttpGet]
        public string TreeView(string ApiName, string DisplayText, string ValueText, string ValueChild)
        {
            try
            {
                string xmlTree = "";
                if (Session[ApiName] == null)
                {
                    var data = clsCommmon.getListWebAPI(ApiName);
                    Session[ApiName] = data;
                    xmlTree = clsCommmon.getXmlTree((IEnumerable<JObject>)Session[ApiName], DisplayText, ValueText, ValueChild);
                }
                else
                {
                    xmlTree = clsCommmon.getXmlTree((IEnumerable<JObject>)Session[ApiName], DisplayText, ValueText, ValueChild);
                }
                return xmlTree;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public string Form(int idForm, int idAction)
        {
            try
            {
                SYS_Form formConfig = null;
                SYS_Control controlConfig = null;
                if ((SYS_Form)Session["SYS_Form_" + idForm] == null)
                {
                    formConfig = (SYS_Form)clsCommmon.getListWebAPI("WS_SYS_Form/GetById/" + idForm, "SYS_Form");
                    Session["SYS_Form_" + idForm] = formConfig;
                }
                else
                {
                    formConfig = (SYS_Form)Session["SYS_Form_" + idForm];
                }
                XmlDocument xmldoc = new XmlDocument();
                string xmlForm;
                if (Session["SYS_Control_" + idForm + "_" + idAction] == null)
                {
                    controlConfig = (SYS_Control)clsCommmon.getListWebAPI("WS_SYS_Control/GetByFormAction/" + idForm + "/" + idAction, "SYS_Control");
                    Session["SYS_Control_" + idForm + "_" + idAction] = controlConfig;
                    xmldoc.Load(HttpContext.Server.MapPath("~/XML/" + Session["Language"] + ((SYS_Control)Session["SYS_Control_" + idForm + "_" + idAction]).XML_Link));
                    xmlForm = xmldoc.InnerXml;
                }
                else
                {
                    xmldoc.Load(HttpContext.Server.MapPath("~/XML/" + Session["Language"] + ((SYS_Control)Session["SYS_Control_" + idForm + "_" + idAction]).XML_Link));
                    xmlForm = xmldoc.InnerXml;
                }
                return xmlForm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public string Toolbar(int idForm, int idAction)
        {
            try
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
                string xmlToolbar = "";
                if (Session[formConfig.ApiNameToolbar + "_" + Session["Language"] + "_" + idForm + "_" + idAction] == null)
                {
                    var data = clsCommmon.getListWebAPI(formConfig.ApiNameToolbar + "/" + idForm + "/" + idAction + "/" + Session["Language"]);
                    Session[formConfig.ApiNameToolbar + "_" + Session["Language"] + "_" + idForm + "_" + idAction] = data;
                    xmlToolbar = clsCommmon.getXmlToolbar((IEnumerable<JObject>)Session[formConfig.ApiNameToolbar + "_" + Session["Language"] + "_" + idForm + "_" + idAction]);
                }
                else
                {
                    xmlToolbar = clsCommmon.getXmlToolbar((IEnumerable<JObject>)Session[formConfig.ApiNameToolbar + "_" + Session["Language"] + "_" + idForm + "_" + idAction]);
                }
                return xmlToolbar;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public JsonResult DataForm(string ApiName, int id)
        {
            try
            {
                return Json(clsCommmon.getDataForm(clsCommmon.getListWebAPI(ApiName + "/" + id)), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public string ToolbarAction(int idForm, int idParrentAction, int idAction)
        {
            try
            {
                SYS_Form formConfig = (SYS_Form)Session["SYS_Form_" + idForm];
                IEnumerable<JObject> toolBar = (IEnumerable<JObject>)Session[formConfig.ApiNameToolbar + "_" + Session["Language"] + "_" + idForm + "_" + idParrentAction];
                return clsCommmon.getToolbarAction(toolBar, idAction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FileResult DownloadFile(string file_name, int idForm, string model)
        {
            string type = file_name.Substring(file_name.LastIndexOf('.') + 1);
            file_name = file_name.Substring(0, file_name.Length - type.Length - 1);
            string saveAsFileName = string.Format(file_name + "-{0:d}." + type, DateTime.Now).Replace("/", "-");
            var exportData = new MemoryStream();

            SYS_Form formConfig = (SYS_Form)Session["SYS_Form_" + idForm];
            IEnumerable<JObject> toolBar = (IEnumerable<JObject>)Session[formConfig.ApiNameToolbar + "_" + Session["Language"] + "_" + idForm + "_0"];


            if ("xls".Equals(type))
                clsCommmon.read_xls(file_name + "." + type, toolBar, model).Write(exportData);
            else if ("xlsx".Equals(type))
                clsCommmon.read_xlsx(file_name + "." + type, toolBar, model).Write(exportData);
            byte[] bytes = exportData.ToArray();
            return File(bytes, "application/vnd.ms-excel", saveAsFileName);
        }
    }
}