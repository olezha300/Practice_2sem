namespace Reports.Persistence;

public class DbInitializer
{
    public static void Initialize(ReportsDbContext context)
    {
        context.Database.EnsureCreated();
    }
}