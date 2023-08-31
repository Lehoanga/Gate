using FPT_UniGate.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPT_UniGate.Controllers
{
    public class HomeController : Controller
    {
     
        public ActionResult Index()
        {            
            return RedirectToAction("Index","TaxiTicket");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            string user = fc["user"];
            string pass = fc["pass"];
            var ReturnUrl = fc["ReturnUrl"];
            try
            {
                if (user == "admin" && pass == "admin.Unigate")
                {
                    var userSession = new UserLogin();
                    /*userSession.UserName = user.Name;*/
                    userSession.UserName = user;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                }
                else
                {
                    ViewBag.errLogin = "Username hoặc Password không chính xác";
                    return View();
                }
            }
            catch
            {

                return RedirectToAction("Login");
            }

            return redirectpage(ReturnUrl);
        }

        public ActionResult redirectpage(string url)
        {
            // Kiểm tra xem URL có giá trị không trống
            if (!string.IsNullOrEmpty(url))
            {
                // Kiểm tra xem URL có bắt đầu bằng '/' không
                if (!url.StartsWith("/"))
                {
                    // Nếu không bắt đầu bằng '/', thêm '/' vào trước URL
                    url = "/" + url;
                }

                // Thực hiện chuyển hướng đến URL được cung cấp
                return Redirect(url);
            }

            // Nếu URL không hợp lệ, chuyển hướng đến trang mặc định
            return RedirectToAction("Index", "Home");
        }



        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Login");
        }
    }
}