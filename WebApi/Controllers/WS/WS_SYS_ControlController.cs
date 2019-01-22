using System.Linq;
using System.Web.Http;
using WebApi.Controllers;
using Model;
using System;

namespace Administrator.Controllers.WS
{
    public class WS_SYS_ControlController : HomeController<SYS_Control>
    {
        [Route("bitecco/WS_SYS_Control/GetByFormAction/{idForm}/{idAction}")]
        public IHttpActionResult GetByFormAction(int idForm, int idAction)
        {
            try
            {
                SYS_Control obj = dataAccess.GetAll().Where(x => x.ID_Form == idForm && x.ID_Action == idAction).First();
                //SYS_Control obj = db.SYS_Control.FirstOrDefault(x => x.ID_Form == idForm && x.ID_Action == idAction);
                if (obj == null)
                {
                    return NotFound();
                }
                return Ok(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}