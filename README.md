https://github.com/Benknightdark/CommunityStandUpMinimalAPI

## DB Migration
``` bash
dotnet ef migrations add InitialCreate --context TodoDbContext --output-dir Migrations/SqliteMigrations
dotnet ef database update

```