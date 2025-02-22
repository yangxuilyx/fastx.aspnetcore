using FastX.AspNetCore;
using FastXTpl.WebTemplate.Host;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseAutofac();

await builder.AddApplicationAsync<WebTemplateHostModule>();

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

app.UseException();
app.UseResultWrapper();

app.Run();

