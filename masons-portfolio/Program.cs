namespace WebApplication2;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddRazorPages();
        builder.Services.AddSingleton<ProjectRepository>();
        var app = builder.Build();
        
        
        app.UseStaticFiles();
        app.MapRazorPages();
        
        app.MapGet("/debug/projects", (ProjectRepository repo) => repo.GetAll());


        app.Run();
    }
}