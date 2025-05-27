using System.Text.Json.Serialization;
using SisQuartel.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<SisQuartelContextFactory>();
builder.Services.AddTransient(opt =>
    opt.GetService<SisQuartelContextFactory>()!
    .CreateDbContext());

builder.Services.AddControllers()
.AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.RoutePrefix = String.Empty;
        options.SwaggerEndpoint("/swagger/v1/swagger.json",
                                "GestaoQuartel.Api");
    });
}

app.UseHttpsRedirection();
app.MapControllers();

app.UseCors(polity => {
    polity.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod();
});

app.Run();
