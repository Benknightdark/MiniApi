using MiniApi.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.AddCustomBuilder();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{builder.Environment.ApplicationName} v1"));
    app.MapFallback(() => Results.Redirect("/swagger"));
}


// app.MapGet("/hello", (HttpContext context, HelloService helloService) =>
//     helloService.SayHello(context.Request.Query["name"].ToString())
//     );

app.AddTodo();
await app.RunAsync();