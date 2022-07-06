using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Survey.MMVCUI.Areas.Admin.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Admin/Logout
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            Session["AdminUserName"] = null;
            return Redirect("/");
        }
    }
}