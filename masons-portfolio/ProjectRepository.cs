using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApplication2;
public enum ProjectDifficulty
{
    Easy,
    Medium,
    Hard
}
public class Project
{
    public string Slug { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public List<string> Description { get; set; }
    public string CardImageUrl { get; set; }
    public string DetailImageURL { get; set; }
    public string? RepoUrl { get; set; }
    public ProjectAttributes Attributes { get; set; }
}
public class ProjectAttributes
{
    public ProjectDifficulty Difficulty { get; set; }
    public List<string> Languages { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}


public class ProjectRepository
{
    private readonly List<Project> _projects;
    
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        Converters = { new JsonStringEnumConverter() }
    };

    public ProjectRepository(IWebHostEnvironment env)
    {
        var dir = Path.Combine(env.ContentRootPath, "data", "projects");
        _projects = Directory.GetFiles(dir, "*.json")
            .Select(f => JsonSerializer.Deserialize<Project>(
                File.ReadAllText(f), JsonOptions))
            .ToList();
    }

    public List<Project> GetAll() => _projects;
    public Project? GetBySlug(string slug) =>
        _projects.FirstOrDefault(p => p.Slug == slug);
}