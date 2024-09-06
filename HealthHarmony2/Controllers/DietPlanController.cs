using HealthHarmony2.Models;
using System;
using System.Data.Entity;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace HealthHarmony2.Controllers
{
    public class DietPlanController : Controller
    {
        #region Connection String
        ExerciseDBContext dc = new ExerciseDBContext();
        #endregion

        //done
        #region Lists all DietPlan
        [Authorize]
        public ViewResult DisplayDietPlans()
        {
            return View(dc.DietPlans);
        }
        #endregion

        //done
        #region Displays a form to add a new DietPlan
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ViewResult AddDietPlan()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public RedirectToRouteResult AddDietPlan(DietPlan DietPlan, HttpPostedFileBase file)
        {

            try
            {
                if (file != null)
                {
                    //Checking whether the folder "Uploads" is exists or not and creating it if not exists
                    string PhysicalPath = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(PhysicalPath))
                    {
                        Directory.CreateDirectory(PhysicalPath);
                    }
                    file.SaveAs(PhysicalPath + file.FileName);
                    DietPlan.DietPlanImage = file.FileName;
                }

                dc.DietPlans.Add(DietPlan);
                try
                {
                    dc.SaveChanges();
                }
                catch
                {

                    ModelState.AddModelError("", "Username and Password is incorrect");
                    return RedirectToAction("AddDietPlan");
                }
                

                return RedirectToAction("AdminDietExercise");
            }
            catch
            {
                return RedirectToAction("AddDietPlan");
            }

        }
        #endregion //done

        //done
        #region Displays a form to edit an existing DietPlan.
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ViewResult EditDietPlan(int Id)
        {
            return View(dc.DietPlans.Find(Id));
        }
        [Authorize(Roles = "admin")]
        [HttpPost]

        public RedirectToRouteResult EditDietPlan(DietPlan DietPlan, HttpPostedFileBase file)
        {
            try
            {
                var v = dc.DietPlans.Find(DietPlan.DietPlanID);
                if (file != null)
                {
                    //Checking whether the folder "Uploads" is exists or not and creating it if not exists
                    string PhysicalPath = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(PhysicalPath))
                    {
                        Directory.CreateDirectory(PhysicalPath);
                    }
                    file.SaveAs(PhysicalPath + file.FileName);
                    DietPlan.DietPlanImage = file.FileName;
                    v.DietPlanImage = DietPlan.DietPlanImage;
                }
                v.DietName = DietPlan.DietName;
                v.DietDescription = DietPlan.DietDescription;
                v.Calories = DietPlan.Calories;
               
                dc.Entry(v).State = EntityState.Modified;


                //dc.Entry(v).State = EntityState.Modified;
                dc.SaveChanges();

                return RedirectToAction("AdminDietExercise");
            }
            catch
            {
                return RedirectToAction("AdminDietExercise");
            }
            
        }

        #endregion

        //done
        #region  Shows details of a specific DietPlan
        [Authorize]
        public ViewResult DisplayDietPlan(int id)
        {
            return View(dc.DietPlans.Find(id));
        }
        #endregion

        //done
        #region Allows deleting an DietPlan.
        [Authorize(Roles = "admin")]
        public RedirectToRouteResult DeleteDietPlan(int id)
        {
            try
            {
                var ex = dc.DietPlans.Find(id);
                dc.DietPlans.Remove(ex);
                dc.SaveChanges();
                return RedirectToAction("AdminDietExercise");
            }
            catch(Exception ex) 
            {
                return RedirectToAction("AdminDietExercise");
                

            }


            
        }
        #endregion



        #region Admin Exercise
        [Authorize(Roles = "admin")]
        public ViewResult AdminDietExercise()
        {
            return View(dc.DietPlans);
        }
        #endregion

    }
}