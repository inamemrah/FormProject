using Data.DAL;
using Data.Entity;
using System;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class AuthController : Controller
    {
        private LenaDbContext dbContext = new LenaDbContext();
       

        public ActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {
            try
            {
                if(UserName != "" && Password != "")
                {
                    UserDAL userDAL = new UserDAL();

                    var result = userDAL.LoginControl(UserName, HashPassword(Password));
                    if(result != null)
                    {
                        HttpCookie userInfo = new HttpCookie("userInfo");
                        userInfo["User"] = result.Username;
                        userInfo["Id"] = result.Id.ToString();
                        userInfo.Expires.Add(new TimeSpan(1, 0, 0));
                        Response.Cookies.Add(userInfo);
                    }
                    else
                    {
                        throw new System.Exception("Login Error");
                    }
                }
                else
                {
                    throw new System.Exception("Login Error");
                }
            }
            catch (System.Exception ex)
            {
                return Json("ERROR");
            }
            return Json("Success");
        }

        public ActionResult SignUpPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string UserName, string Password)
        {
            try
            {
                if (UserName != "" && Password != "")
                {
                    UserDAL userDAL = new UserDAL();
            
                    var newUser = new User()
                    {
                        Username = UserName,
                        Password = HashPassword(Password)
                    };
                    userDAL.Insert(newUser);
                }
                else
                {
                    throw new System.Exception("SignUp Error");
                }
            }
            catch (System.Exception)
            {
                return Json("ERROR");
            }
            return Json("Success");
        }

        public string HashPassword(string Password)
        {
            byte[] hash = System.Text.ASCIIEncoding.ASCII.GetBytes(Password);
            string hashPassword = System.Convert.ToBase64String(hash);
            return hashPassword;
        }

        public void Logout()
        {
            Request.Cookies.Remove("userInfo");
        }

    }
}