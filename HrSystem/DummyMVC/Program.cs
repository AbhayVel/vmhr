using DummyMVC.filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddMvcCore((o) =>
{
    o.Filters.Add(new MyResultActionFIlter());
});

builder.Services.AddAuthentication("cookies").AddCookie("cookies",(x) =>
{
    x.LoginPath = "/Login/Index";
    x.LogoutPath = "/Login/Logout";
    x.ExpireTimeSpan = TimeSpan.FromMinutes(2);

   
});


var app = builder.Build();

Dictionary<string, int> keyValues =new Dictionary<string, int>();

app.Use((http, fun) =>
{

    var path = http.Request.Path;
    if (keyValues.ContainsKey(path))
    {
        keyValues[path] = keyValues[path]+1;
    }else
    {
        keyValues[path] = 1;
    }


        http.Response.Headers.Add("Count", keyValues[path].ToString());
        return fun(http);
     

       
     

});


app.Use((http, fun) =>
{
    var path = http.Request.Path.ToString();
    if (path.ToUpper().Contains("GETDATA2"))
    {
       http.Response.Redirect("/home/GetData");
        return Task.CompletedTask;
    }
    else
    {
        return fun(http);
    }
});
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
