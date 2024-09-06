using HealthHarmony2.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace HealthHarmony2.Controllers
{
    public class AccountController : Controller
    {
        ExerciseDBContext dc = new ExerciseDBContext();

        #region Login
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(User user)
        {
            try
            {
                bool Isvalid = dc.Users.Any(u => u.Username == user.Username && u.Password == user.Password);
                if (Isvalid)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("DisplayCategorys", "ExerciseCategory");
                }
                else
                {
                    ModelState.AddModelError("", "Username and Password is incorrect");
                }
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Signup

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User user)
        {
            try
            {
                if (user.Username != null && user.Password != null && user.Email != null)
                {
                    dc.Users.Add(user);
                    try
                    {
                        dc.SaveChanges();
                        return RedirectToAction("Login");
                    }
                    catch
                    {
                        ModelState.AddModelError("", "Username and Password is incorrect");
                        return View();
                    }

                }
                else
                {

                }
                return View();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region LogOut
        public RedirectToRouteResult LogOut()
        {
            try
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("LogIn");
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion

    }
}