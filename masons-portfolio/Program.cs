namespace WebApplication2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.UseStaticFiles();

        app.MapGet("/", () => Results.File("index.html", "text/html"));
        app.MapGet("/projects", () => Results.File("projects.html", "text/html"));

        app.Run();
    }
}