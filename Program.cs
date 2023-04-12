using ConnectWithDadata.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(AppMappingProfile));

var app = builder.Build();

//app.Environment.EnvironmentName = "Production";

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Main/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
		name: "default",
		pattern: "{controller=Main}/{action=Index}/{id?}");

app.Run();
