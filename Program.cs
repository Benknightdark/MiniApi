var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<HelloService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/hello", (HttpContext context, HelloService helloService) =>
    helloService.SayHello(context.Request.Query["name"].ToString())
    );
await app.RunAsync();