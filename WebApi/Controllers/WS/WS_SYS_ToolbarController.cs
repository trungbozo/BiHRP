using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Model;

namespace WebApi.Controllers.WS
{
    public class WS_SYS_ToolbarController : HomeController<SYS_Toolbar>
    {
        [Route("bitecco/WS_SYS_Toolbar/GetAllByLanguage/{idForm}/{idAction}/{language}")]
        public IQueryable<SYS_Toolbar> GetAllByLanguage(int idForm, int idAction, string language)
        {
            try
            {
                return dataAccess.GetAll().Where(x => x.ID_Form == idForm).Where(x => x.ID_SYS_Toolbar_Parent == null && x.ID_Action == idAction && x.Language == language).OrderBy(x => x.OrderBy).AsQueryable();
                //return db.SYS_Toolbar.Where(x => x.ID_Form == idForm).Where(x => x.ID_SYS_Toolbar_Parent == null && x.ID_Action == idAction && x.Language == language).OrderBy(x => x.OrderBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
