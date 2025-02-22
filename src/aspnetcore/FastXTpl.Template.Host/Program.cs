
using FastX.App.Host;
using FastX.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseAutofac();

await builder.AddApplicationAsync<AppHostModule>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseSpaStaticFiles();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseResultWrapper();
app.UseException();

app.Run();

