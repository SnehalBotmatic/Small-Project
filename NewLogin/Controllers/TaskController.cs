using NewLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewLogin.Controllers
{
    public class TaskController : Controller
    {
        private static List<TaskModel> tasks = new List<TaskModel>();
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UpdateTask()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateTask(TaskModel updatedTask)
        {
            tasks.Add(updatedTask);
            return RedirectToAction("AddTask","Task");
        }

        [HttpGet]
        public ActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTask(TaskModel newTask)
        {
            tasks.Add(newTask);
            return RedirectToAction("TaskDetails");
        }

        [HttpGet]
        public ActionResult TaskDetails()
        {
            return View(tasks);
        }
    }
}