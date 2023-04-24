using BankSystem.Application.Mappers;
using BankSystem.Application.Services;
using BankSystem.Infrastructure;
using BankSystem.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(BankSystem.Application.Commands.CreateUserAccountCommand).Assembly));
builder.Services.AddDbContext<BankContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserIdentityService, UserIdentitySevice>();
builder.Services.AddAutoMapper(typeof(UserMappingProfile));

var app = builder.Build();

SeedDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();


void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<BankContext>();
        new BankContextSeed().Seed(context);
    }
}