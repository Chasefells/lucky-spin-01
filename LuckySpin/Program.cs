var builder = WebApplication.CreateBuilder(args);

// Install Services using the builder.Services methods
  //  Done: add the "Controllers" method to the "builder" to enable MVC controllers
 
builder.Services.AddControllersWithViews();
//Builds the app with the added services
var app = builder.Build();


// Configure the app's Middleware in the HTTP Request Pipeline
//   DONE: The following code "app.UseStaticFiles()" provides the ability to recognize static folders and files in the wwwroot directory
app.UseStaticFiles();

//   DONE: The following code "app.UseExceptionHandler" provides a default error page when not in development
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Spinner/Error");
}
//   Done: add Routing to recognize custom "Routes" in place of folders and files
app.MapControllerRoute(
    name: "default", // Default route
    pattern: "{controller=Home}/{action=Index}/{id?}");


//Configure Routing with a general pattern and a default setting if the URL path is left out
 // Done:if your have time, add a range(1,9) method to constrain luck between 1 and 9

app.MapControllerRoute(
    name: "luckRoute", 
    pattern: "spin/{luck:int:min(1):max(9)}",
    defaults: new { controller = "Spin", action = "Index" });
   

app.Run();


