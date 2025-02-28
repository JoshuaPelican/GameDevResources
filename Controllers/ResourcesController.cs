﻿using GameDevResources.Data;
using GameDevResources.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameDevResources.Controllers
{
    public class ResourcesController : Controller
    {
        private readonly GameDevResourcesContext _context;

        // Constructor to initialize the context
        public ResourcesController(GameDevResourcesContext context)
        {
            _context = context;
        }

        // GET: Resources
        // Displays a list of all resources
        public async Task<IActionResult> Index()
        {
            return View(await _context.Resource.ToListAsync());
        }

        // GET: Resources/Details/5
        // Displays details of a specific resource
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _context.Resource
                .FirstOrDefaultAsync(m => m.ID == id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // GET: Resources/Create
        // Displays the form to create a new resource
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resources/Create
        // Handles the form submission to create a new resource
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Type,URL,Pricing,Tags")] Resource resource)
        {
            if (ModelState.IsValid)
            {
                resource.Icon = GetIconUrl(resource.URL);
                _context.Add(resource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        // GET: Resources/Edit/5
        // Displays the form to edit an existing resource
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _context.Resource.FindAsync(id);
            if (resource == null)
            {
                return NotFound();
            }
            return View(resource);
        }

        // POST: Resources/Edit/5
        // Handles the form submission to edit an existing resource
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Type,URL,Pricing,Tags")] Resource resource)
        {
            if (id != resource.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    resource.Icon = GetIconUrl(resource.URL);
                    if (String.IsNullOrWhiteSpace(resource.Tags[0]))
                        resource.Tags = new List<string>();
                    else
                        resource.Tags = resource.Tags[0].Split(",", StringSplitOptions.TrimEntries).Where(t => !string.IsNullOrEmpty(t)).ToList();
                    _context.Update(resource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResourceExists(resource.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        // GET: Resources/Delete/5
        // Displays the form to confirm deletion of a resource
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _context.Resource
                .FirstOrDefaultAsync(m => m.ID == id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: Resources/Delete/5
        // Handles the form submission to delete a resource
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resource = await _context.Resource.FindAsync(id);
            if (resource != null)
            {
                _context.Resource.Remove(resource);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Checks if a resource exists in the database
        private bool ResourceExists(int id)
        {
            return _context.Resource.Any(e => e.ID == id);
        }

        // Generates the icon URL based on the resource's URL
        private static string GetIconUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return string.Empty;
            }

            var uri = new Uri(url);
            var hostname = uri.Host;
            return $"https://icons.duckduckgo.com/ip3/{hostname}.ico";
        }

        // GET: Resources/GetTagSuggestions
        // Provides tag suggestions based on existing tags
        [HttpGet]
        public JsonResult GetTagSuggestions(string term)
        {
            if (string.IsNullOrEmpty(term) || term.Length < 2)
            {
                return Json(new List<string>());
            }

            var suggestions = _context.Resource
                .SelectMany(r => r.Tags)
                .Where(t => t.StartsWith(term))
                .GroupBy(t => t)
                .Select(g => new { Tag = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count)
                .Take(5)
                .Select(g => g.Tag)
                .ToList();

            return Json(suggestions);
        }
    }
}