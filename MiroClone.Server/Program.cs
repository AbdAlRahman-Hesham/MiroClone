using Microsoft.EntityFrameworkCore;
using MiroClone.Server.AppRegistration;
using MiroClone.Server.DAL.Data;
using MiroClone.Server.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSignalR();
builder.Services.AddCors();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Custom App services registration

builder.Services.AddAppSwaggerAuthConfiguration();
builder.Services.AddAppAuthServices(builder.Configuration);
builder.Services.AddAppServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policy =>
    policy.AllowAnyHeader()
          .AllowAnyMethod()
          .SetIsOriginAllowed(_ => true)
          .AllowCredentials());
app.MapHub<BoardHub>("/boardhub");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
