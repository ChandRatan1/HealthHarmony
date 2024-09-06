using HealthHarmony2.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace HealthHarmony2.Controllers
{
    public class ExerciseCategoryController : Controller
    {
        #region Connection String
        ExerciseDBContext dc = new ExerciseDBContext();
        #endregion

        #region Lists all Category
        public ViewResult DisplayCategorys()
        {
            return View(dc.ExerciseCategories);
        }
        #endregion


        #region Admin Controll
        [Authorize(Roles = "admin")]
        public ViewResult AdminCategory()
        {
            return View(dc.ExerciseCategories);
        }
        #endregion

        #region Displays a form to add a new Category
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ViewResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult AddCategory(ExerciseCategory Category, HttpPostedFileBase file)
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
                    Category.CategoryImage = file.FileName;
                }

                dc.ExerciseCategories.Add(Category);
                dc.SaveChanges();

                return RedirectToAction("DisplayCategorys");
            }
            catch
            {
                return RedirectToAction("DisplayCategorys");
            }

        }
        #endregion


        #region Displays a form to edit an existing Category.
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ViewResult EditCategory(int Id)
        {
            return View(dc.ExerciseCategories.Find(Id));
        }
        [HttpPost]
        public RedirectToRouteResult EditCategory(ExerciseCategory Category, HttpPostedFileBase file)
        {
            var ec = dc.ExerciseCategories.Find(Category.CategoryID);

            if (file != null)
            {
                string FolderPath = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }
                file.SaveAs(FolderPath + file.FileName);
                ec.CategoryImage = file.FileName;
            }
            ec.CategoryName = Category.CategoryName;
            ec.CategoryDescription = Category.CategoryDescription;



            dc.Entry(ec).State = EntityState.Modified;
            dc.SaveChanges();

            return RedirectToAction("AdminCategory");
        }

        #endregion

        #region  Shows details of a specific Category
        [Authorize]
        public ViewResult DisplayCategory(int id)
        {

            ExerciseCategory category = dc.ExerciseCategories.Find(id);
            ICollection<Exercise> temp = new List<Exercise>();
            foreach (var v in dc.Exercises)
            {
                temp.Add(v);
            }
            category.Exercises = temp;
            category.CategoryID = id;
            return View(category);
        }
        #endregion

        #region Allows deleting an exercise.
        [Authorize(Roles = "admin")]
        public RedirectToRouteResult DeleteCategory(int id)
        {
            ExerciseCategory ec = dc.ExerciseCategories.Find(id);
            dc.ExerciseCategories.Remove(ec);
            dc.SaveChanges();
            return RedirectToAction("AdminCategory");
        }
        #endregion
    }
}