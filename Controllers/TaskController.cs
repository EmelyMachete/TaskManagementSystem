using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;
using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Controllers
{
    public class TaskController : Controller
    {
        private static List<TaskItem> tasks = new List<TaskItem>
        {
            new TaskItem
            {
                Id = 1,
                Title = "Prepare project documentation",
                Description = "Write README and project overview",
                Status = "To Do",
                DueDate = DateTime.Today.AddDays(3)
            },
            new TaskItem
            {
                Id = 2,
                Title = "Implement CRUD operations",
                Description = "Add create, edit, and delete functionality",
                Status = "In Progress",
                DueDate = DateTime.Today.AddDays(5)
            }
        };

        // READ
        public IActionResult Index()
        {
            return View(tasks);
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            return View();
        }

        // CREATE (POST)
        [HttpPost]
        public IActionResult Create(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                task.Id = tasks.Count + 1;
                tasks.Add(task);
                return RedirectToAction("Index");
            }

            return View(task);
        }

        // EDIT (GET)
        public IActionResult Edit(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            return View(task);
        }

        // EDIT (POST)
        [HttpPost]
        public IActionResult Edit(TaskItem task)
        {
            var existingTask = tasks.Find(t => t.Id == task.Id);

            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.Status = task.Status;
                existingTask.DueDate = task.DueDate;
            }

            return RedirectToAction("Index");
        }

        // DELETE (NO DATABASE)
        public IActionResult Delete(int id)
        {
            var task = tasks.Find(t => t.Id == id);

            if (task != null)
            {
                tasks.Remove(task);
            }

            return RedirectToAction("Index");
        }
    }
}
