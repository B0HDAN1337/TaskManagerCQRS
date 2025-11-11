using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManager_server.Data;
using TaskManager_server.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<TaskWriteRepository>();
builder.Services.AddScoped<TaskReadRepository>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

// Write DB
builder.Services.AddDbContext<WriteDbContext>(options =>
    options.UseSqlite("Data Source=WriteDB.db"));

// Read DB
builder.Services.AddDbContext<ReadDbContext>(options =>
    options.UseSqlite("Data Source=ReadDB.db"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

    });
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var writeDb = scope.ServiceProvider.GetRequiredService<WriteDbContext>();
    writeDb.Database.EnsureCreated();

    var readDb = scope.ServiceProvider.GetRequiredService<ReadDbContext>();
    readDb.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Allow");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
