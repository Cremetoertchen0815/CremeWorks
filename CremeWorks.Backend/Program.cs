using CremeWorks.Backend;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Register database context
var connectionStr = builder.Configuration.GetValue<string>("DbConnection");
builder.Services.AddDbContextFactory<DataContext>(x => 
    x.UseMySql(connectionStr,
        ServerVersion.AutoDetect(connectionStr), 
        x => x.SchemaBehavior(MySqlSchemaBehavior.Translate, (x, y) => $"{x}.{y}")
              .MigrationsHistoryTable("__EFMigrationsHistory", "cw")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Migrate database
var dbFactory = app.Services.GetRequiredService<IDbContextFactory<DataContext>>();
using (var db = await dbFactory.CreateDbContextAsync()) await db.Database.MigrateAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
