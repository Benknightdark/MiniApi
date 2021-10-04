using Microsoft.EntityFrameworkCore;

namespace MiniApi.Controllers
{
    public static class TodoController
    {
        public static void AddTodo(this WebApplication app)
        {

            
            app.MapGet("/todos",async (TodoDbContext db) =>
            {
                return await db.Todos.ToListAsync();
            });

            app.MapGet("/todos/{id}", async (TodoDbContext db, int id) =>
            {
                return await db.Todos.FindAsync(id) switch
                {
                    Todo todo => Results.Ok(todo),
                    null => Results.NotFound()
                };
            });

            app.MapPost("/todos", async (TodoDbContext db, Todo todo) =>
            {
                await db.Todos.AddAsync(todo);
                await db.SaveChangesAsync();

                return Results.Created($"/todo/{todo.Id}", todo);
            });

            app.MapPut("/todos/{id}", async (TodoDbContext db, int id, Todo todo) =>
            {
                if (id != todo.Id)
                {
                    return Results.BadRequest();
                }

                if (!await db.Todos.AnyAsync(x => x.Id == id))
                {
                    return Results.NotFound();
                }

                db.Update(todo);
                await db.SaveChangesAsync();

                return Results.Ok();
            });


            app.MapDelete("/todos/{id}", async (TodoDbContext db, int id) =>
            {
                var todo = await db.Todos.FindAsync(id);
                if (todo is null)
                {
                    return Results.NotFound();
                }

                db.Todos.Remove(todo);
                await db.SaveChangesAsync();

                return Results.Ok();
            });
        }
    }
}