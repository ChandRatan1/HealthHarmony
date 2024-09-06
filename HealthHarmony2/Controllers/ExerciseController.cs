using HealthHarmony2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace HealthHarmony2.Controllers
{

    public class ExerciseController : Controller
    {
        #region Connection String
        ExerciseDBContext dc = new ExerciseDBContext();
        #endregion

        #region Lists all exercises

        [Authorize]
        public ViewResult DisplayExercises()
        {
            return View(dc.Exercises);
        }
        #endregion

        #region Displays a form to add a new exercise
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ViewResult AddExercise()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var Exercise in dc.ExerciseCategories)
            {
                SelectListItem li = new SelectListItem { Text = Exercise.CategoryName, Value = Exercise.CategoryID.ToString() };
                items.Add(li);
            }
            Exercise ex = new Exercise();
            ex.Categories = items;
            return View(ex);
        }


        [HttpPost]
        public RedirectToRouteResult AddExercise(Exercise exercise, HttpPostedFileBase file)
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
                    exercise.ExerciseImage = file.FileName;
                }

                dc.Exercises.Add(exercise);
                dc.SaveChanges();

                return RedirectToAction("AdminExercise");
            }
            catch
            {
                return RedirectToAction("AdminExercise");
            }
        }
        #endregion

        #region Admin Exercise
        [Authorize(Roles = "admin")]
        public ViewResult AdminExercise()
        {

            return View(dc.Exercises);
        }
        #endregion


        #region Displays a form to edit an existing exercise.
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ViewResult EditExercise(int Id)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var Exercise in dc.ExerciseCategories)
            {
                SelectListItem li = new SelectListItem { Text = Exercise.CategoryName, Value = Exercise.CategoryID.ToString() };
                items.Add(li);
            }
            Exercise ex = new Exercise();
            //ex.Categories = items;
            var temp = dc.Exercises.Find(Id);
            //temp.Categories = ex;
            temp.Categories = items;
            return View(temp);
        }
        [HttpPost]
        public RedirectToRouteResult EditExercise(Exercise exercise, HttpPostedFileBase file)
        {
            try
            {
                var v = dc.Exercises.Find(exercise.ExerciseID);
                if (file != null)
                {
                    //Checking whether the folder "Uploads" is exists or not and creating it if not exists
                    string PhysicalPath = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(PhysicalPath))
                    {
                        Directory.CreateDirectory(PhysicalPath);
                    }
                    file.SaveAs(PhysicalPath + file.FileName);
                    exercise.ExerciseImage = file.FileName;
                    v.ExerciseImage = exercise.ExerciseImage;
                }
                v.ExerciseName = exercise.ExerciseName;
                v.ExerciseDescription = exercise.ExerciseDescription;
                v.ExerciseCategory = exercise.ExerciseCategory;
                v.Categories = exercise.Categories;
                v.ExerciseBodyPart = exercise.ExerciseBodyPart;
                
                v.ExerciseInstructions = exercise.ExerciseInstructions;
                dc.Entry(v).State = EntityState.Modified;


                //dc.Entry(v).State = EntityState.Modified;
                dc.SaveChanges();

                return RedirectToAction("AdminExercise");
            }
            catch
            {
                return RedirectToAction("AdminExercise");
            }

        }

        #endregion

        #region  Shows details of a specific exercise
        [Authorize]
        public ViewResult DisplayExercise(int id)
        {
            return View(dc.Exercises.Find(id));
        }
        #endregion

        #region Allows deleting an exercise.
        [Authorize(Roles = "admin")]
        public RedirectToRouteResult DeleteExercise(int id)
        {

            try
            {
                var ex = dc.Exercises.Find(id);
                dc.Exercises.Remove(ex);  
                dc.SaveChanges();
                return RedirectToAction("AdminExercise");
            }
            catch (Exception a)
            {
                return RedirectToAction("AdminExercise");
            }

        }
        #endregion
    }
}