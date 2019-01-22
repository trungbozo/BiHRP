using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Model.AccessData;

namespace WebApi.Controllers.WS
{
    public class WS_SYS_MenuController : HomeController<SYS_Menu>
    {
        private DA_SYS_Menu menu = new DA_SYS_Menu();
        public IQueryable<SYS_Menu> GetAllParent()
        {
            try
            {
                //return menu.GetAllParent();
                //dataAccess.GetAll().Where(x => x.ID_Form == idForm).OrderBy(x => x.OrderBy).AsQueryable();
                return dataAccess.GetAll().Where(x => x.ID_SYS_Menu_Parent == null).OrderBy(x => x.OrderBy).AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}