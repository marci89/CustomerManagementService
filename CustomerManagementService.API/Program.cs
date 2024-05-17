using CustomerManagementService.Business;
using CustomerManagementService.Business.Factories;
using CustomerManagementService.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//appSettings
var databaseSettings = new DatabaseSettings(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region DI

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<CustomerFactory>();

#endregion

#region Database

builder.Services.AddDbContext<DataContext>(options =>
{
	options.UseSqlite(databaseSettings.ConnectionString);
});

#endregion


builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

#region If database is not exists or there is a new migration to update, this will handle it.

if (databaseSettings.AutoMigrationEnabled)
{
	using var scope = app.Services.CreateScope();
	var db = scope.ServiceProvider.GetRequiredService<DataContext>();
	if (db.Database.GetPendingMigrations().Any())
	{
		db.Database.Migrate();
	}
}


#endregion

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("*"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
