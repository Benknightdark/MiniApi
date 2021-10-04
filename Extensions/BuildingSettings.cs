public static class BuildingSettings
{
    public static void AddCustomBuilder(this WebApplicationBuilder builder)
    {
        #region DataBase            
        var connectionString = builder.Configuration.GetConnectionString("Todos") ?? "Data Source=Todos.db";
        builder.Services.AddSqlite<TodoDbContext>(connectionString);
        #endregion

        #region Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = builder.Environment.ApplicationName, Version = "v1" });
        });
        #endregion

        #region DI Services
        builder.Services.AddScoped<HelloService>();
        #endregion
    }

}
