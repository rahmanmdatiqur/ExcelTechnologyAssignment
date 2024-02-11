using PatientInformationPortalAPI;
using PatientInformationPortalAPI.Models;
using PatientInformationPortalAPI.Repository.Abstraction;
using PatientInformationPortalAPI.Repository.Implementation;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using PatientInformationPortalAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.IgnoreNullValues = true;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PatientDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

builder.Services.AddTransient(typeof(IRepository<PatientInformation>), typeof(Repository<PatientInformation>));
builder.Services.AddTransient(typeof(IRepository<DiseaseInformation>), typeof(Repository<DiseaseInformation>));
builder.Services.AddTransient(typeof(IRepository<Allergies>), typeof(Repository<Allergies>));
builder.Services.AddTransient(typeof(IRepository<Allergies_Details>), typeof(Repository<Allergies_Details>));
builder.Services.AddTransient(typeof(IRepository<NCD>), typeof(Repository<NCD>));
builder.Services.AddTransient(typeof(IRepository<NCD_Details>), typeof(Repository<NCD_Details>));
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("corsPolicy", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
