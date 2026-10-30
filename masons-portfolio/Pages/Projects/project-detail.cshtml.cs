using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;

namespace WebApplication2.Pages.Projects;

public class ProjectDetailModel : PageModel
{
    private readonly ProjectRepository _repo;
    public Project? Project { get; set; }
    public List<Project> Projects { get; set; } = new();

    public ProjectDetailModel(ProjectRepository repo)   // ASP.NET injects it here
    {
        _repo = repo;
    }

    public IActionResult OnGet(string slug)                             // runs on every GET request
    {
        Project = _repo.GetBySlug(slug);
        Console.Out.WriteLine("hit " + slug);
        if (Project == null)
        {
            Console.Out.WriteLine(slug);
            return NotFound();
        }

        return Page();
    }
}