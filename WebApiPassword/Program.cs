using WebApi_Minimal.Domain.Services;
using WebApi_Minimal.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Pesonalized Services
builder.Services.AddScoped<PasswordManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Endpoints Configuration
app.MapMethods(CheckPasswordPost.Template, CheckPasswordPost.Methods, CheckPasswordPost.Handle);

app.Run();