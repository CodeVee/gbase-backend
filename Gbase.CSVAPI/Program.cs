using Gbase.CSVAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var version = new MySqlServerVersion(new Version(8, 0, 29));
builder.Services.AddDbContext<AppDbContext>(
   dbContextOptions => dbContextOptions
       .UseMySql(connectionString, version,
           mySqlOptions => {
               mySqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
               mySqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
           })
);

var corsPolicy = "CorsPollicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy,
        builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsPolicy);

app.MapControllers();

app.Run();
