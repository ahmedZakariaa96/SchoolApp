using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using School.Application;
using School.Application.Base.Middleware;
using School.Infrestructure;
using System.Globalization;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
#region Dependance Injection
builder.Services.AddInfrestructureDependencies(builder.Configuration);
builder.Services.AddDomainDependencies();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region localozation1
builder.Services.AddLocalization(options => options.ResourcesPath = "");
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    List<CultureInfo> supportedCultures = new List<CultureInfo>
    {
            new CultureInfo("en-US"),
            new CultureInfo("de-DE"),
            new CultureInfo("fr-FR"),
            new CultureInfo("ar-EG")
    };
    options.DefaultRequestCulture = new RequestCulture("ar-EG");//ar-EG en-US
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});
#endregion
//----------------------------------------------------------------------


var app = builder.Build();

//Middleware
app.UseMiddleware<ErrorHandlerMiddleware>();

#region localozation2

var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);
#endregion

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
