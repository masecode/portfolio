using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.wwwroot;

public class projects_cshtml : PageModel
{
    private readonly ProjectRepository _repo;
    public List<Project> Projects { get; set; } = new();

    public projects_cshtml(ProjectRepository repo)   // ASP.NET injects it here
    {
        _repo = repo;
    }

    public void OnGet()                             // runs on every GET request
    {
        Projects = _repo.GetAll();
    }
}