

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Host=localhost;Port=5433;Username=postgres;Password=12345;Database=mydb";

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

app.UseHttpsRedirection();

app.MapPost("/user", async (AppDbContext context, UserRequest request) =>
{
    var user = new User
    {
        Name = request.Name,
        Email = request.Email
    };

    var entriesBeforeAdd = context.ChangeTracker.Entries()
        .Select(e => new
        {
            EntityName = e.Entity.GetType().Name,
            State = e.State.ToString()

        });

    Console.WriteLine();
    Console.WriteLine($"entriesBeforeAdd");

    foreach (var entry in entriesBeforeAdd)
    {
        Console.WriteLine($"Entity: {entry.EntityName}");
        Console.WriteLine($"State: {entry.State}");
        Console.WriteLine("--------------------------------------------");
    }

    await context.Users.AddAsync(user);

    var entriesAfterAdd = context.ChangeTracker.Entries()
        .Select(e => new
        {
            EntityName = e.Entity.GetType().Name,
            State = e.State.ToString()

        });

    Console.WriteLine();
    Console.WriteLine($"entriesAfterAdd");

    foreach (var entry in entriesAfterAdd)
    {
        Console.WriteLine($"Entity: {entry.EntityName}");
        Console.WriteLine($"State: {entry.State}");
        Console.WriteLine("--------------------------------------------");
    }

    await context.SaveChangesAsync();

    var entriesAfterSave = context.ChangeTracker.Entries()
        .Select(e => new
        {
            EntityName = e.Entity.GetType().Name,
            State = e.State.ToString()

        });

    Console.WriteLine();
    Console.WriteLine($"entriesAfterSave");

    foreach (var entry in entriesAfterSave)
    {
        Console.WriteLine($"Entity: {entry.EntityName}");
        Console.WriteLine($"State: {entry.State}");
        Console.WriteLine("--------------------------------------------");
    }
});

app.Run();
