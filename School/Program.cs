using School.Application;
using School.Application.Base.Middleware;
using School.Infrestructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//------------------------------------
//Dependance Injection
builder.Services.AddInfrestructureDependencies(builder.Configuration);
builder.Services.AddDomainDependencies();

//-------------------------------------------


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Middleware
app.UseMiddleware<ErrorHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
