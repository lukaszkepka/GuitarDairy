using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuitarDairy.Domain.Entities;
using GuitarDairy.Infrastructure;
using GuitarDairy.Application.Services;
using GuitarDairy.Application.Services.Interfaces;

namespace GuitarDairy.UI.Web.Controllers
{
    public class ExercisesController : Controller
    {
        private readonly IExerciseService _exerciseService;
        private readonly ICategoryService _categoryService;

        public ExercisesController(IExerciseService exerciseService, ICategoryService categoryService)
        {
            _exerciseService = exerciseService;
            _categoryService = categoryService;
        }

        // GET: Exercises
        public async Task<IActionResult> Index()
        {
            var exercises = await _exerciseService.All();
            return View(exercises);
        }

        // GET: Exercises/Create
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.All();
            ViewData["Categories"] = new SelectList(categories, "Id", "Name");
            return View();
        }

        // POST: Exercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,Name")] Exercise exercise)
        {
            var categories = await _categoryService.All();

            if (ModelState.IsValid)
            {
                _exerciseService.Add(exercise);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Id", exercise.CategoryId);
            return View(exercise);
        }

        // GET: Exercises/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            var categories = await _categoryService.All();

            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _exerciseService.Get(id.Value);
            if (exercise == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(categories, "Id", "Id", exercise.CategoryId);
            return View(exercise);
        }

        // POST: Exercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,CategoryId,Name")] Exercise exercise)
        {
            var categories = await _categoryService.All();

            if (id != exercise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _exerciseService.Update(exercise);
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(categories, "Id", "Id", exercise.CategoryId);
            return View(exercise);
        }

        // GET: Exercises/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _exerciseService.Get(id.Value);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        // POST: Exercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _exerciseService.Get(id)
                .ContinueWith(x => _exerciseService.Delete(x.Result));

            return RedirectToAction(nameof(Index));
        }
    }
}
