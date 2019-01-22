using System.Web.Mvc;
using System.Xml;

namespace Administrator.Controllers
{
    public class HomeController : Controller
    {
        private Administrator.Controllers.Common.Common clsCommmon = new Administrator.Controllers.Common.Common();
        public ActionResult Index()
        {
            ViewBag.Title = "Bitecco";
            #region Get Menu
            ViewBag.SYS_Menu = clsCommmon.getListWebAPI("WS_SYS_Menu/GetAllParent");
            #endregion
            LoadConfigLanguage("en");
            Session["DateFormat"] = System.Configuration.ConfigurationManager.AppSettings["DateFormat"];
            Session["DateFormatServer"] = System.Configuration.ConfigurationManager.AppSettings["DateFormatServer"];
            return View();
        }
        private void LoadConfigLanguage(string language)
        {
            Session["Language"] = language;
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(HttpContext.Server.MapPath("~/XML/" + language + "/common.xml"));
            Session["message.deleted"] = clsCommmon.LoadItemXML("message", "deleted", xmldoc);
            Session["message.acceptdelete"] = clsCommmon.LoadItemXML("message", "acceptdelete", xmldoc);
            Session["message.delete"] = clsCommmon.LoadItemXML("message", "delete", xmldoc);
            Session["message.updated"] = clsCommmon.LoadItemXML("message", "updated", xmldoc);
            Session["message.acceptupdate"] = clsCommmon.LoadItemXML("message", "acceptupdate", xmldoc);
            Session["message.checkupdate"] = clsCommmon.LoadItemXML("message", "checkupdate", xmldoc);
            Session["message.detail"] = clsCommmon.LoadItemXML("message", "detail", xmldoc);
            Session["message.added"] = clsCommmon.LoadItemXML("message", "added", xmldoc);
            Session["message.checkadd"] = clsCommmon.LoadItemXML("message", "checkadd", xmldoc);
            Session["message.detail"] = clsCommmon.LoadItemXML("message", "detail", xmldoc);
            Session["title.delete"] = clsCommmon.LoadItemXML("title", "delete", xmldoc);
            Session["title.update"] = clsCommmon.LoadItemXML("title", "update", xmldoc);
            Session["title.add"] = clsCommmon.LoadItemXML("title", "add", xmldoc);
            Session["title.detail"] = clsCommmon.LoadItemXML("title", "detail", xmldoc);
            Session["title.help"] = clsCommmon.LoadItemXML("title", "help", xmldoc);
        }
    }
}
