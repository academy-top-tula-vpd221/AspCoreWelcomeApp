using AspCoreWelcomeApp;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
//app.UseWelcomePage();

//int count = 1;

//app.Run(async (context) =>
//{
//    count *= 2;
//    await context.Response.WriteAsync($"Count = {count}");
//});


//app.Run(async (context) =>
//{
//    var request = context.Request;
//    var response = context.Response;

//    response.Headers.ContentLanguage = "ru-Ru";
//    response.Headers.ContentType = "text/html; charset=utf8";
//    //response.Headers.Append("my_id", "1234");

//    //foreach (var item in request.Headers)
//    //    await response.WriteAsync($"{item.Key} -> {item.Value}\n");

//    //response.StatusCode = 404;
//    await response.WriteAsync("<h1>Hello</h1><p>Lorem ipsum</p>");
//});


//app.Run(async (context) =>
//{
//    var response = context.Response;

//    var fileProveder = new PhysicalFileProvider(Directory.GetCurrentDirectory());
//    var fileInfo = fileProveder.GetFileInfo("icon.png");

//    response.Headers.ContentDisposition = "attachment; filename=super_image.png";
//    await response.SendFileAsync(fileInfo);
//    //await response.SendFileAsync(@"index.html");
//});

//app.Run(async (context) =>
//{
//    var request = context.Request;
//    var response = context.Response;

//    response.Headers.ContentType = "text/html; charset=utf8";

//    if(request.Path == "/formsend")
//    {
//        var form = request.Form;
//        string name = form["name"];
//        string age = form["age"];
//        string[] cities = form["city"];

//        string cityStr = "";
//        foreach (var s in cities) cityStr += $"<p>City: {s}</p>";

//        await response.WriteAsync($"<div><p>Name: {name}</p><p>Age: {age}</p>{cityStr}</div>");
//    }
//    else
//    {
//        await response.SendFileAsync("html/index.html");
//    }

//});

//app.Run(async (context) =>
//{
//    var request = context.Request;
//    var response = context.Response;

//    if (request.Path == "/oldpage")
//        response.Redirect("/newpage");
//    //await response.WriteAsync("Old Page");
//    else if (request.Path == "/newpage")
//        await response.WriteAsync("New Page");
//    else
//        await response.WriteAsync("Home Page");
//});


//app.Run(async (context) =>
//{
//    var request = context.Request;
//    var response = context.Response;

//    Employee employee = new() { Name = "Bobby", Age = 27 };
//    await response.WriteAsJsonAsync(employee);
//});

app.Run(async (context) =>
{
    var request = context.Request;
    var response = context.Response;

    if(request.Path == "/api/empl")
    {
        string message = "";
        try
        {
            var employee = await request.ReadFromJsonAsync<Employee>();
            if (employee is not null)
                message = $"From server: name: {employee.Name}, age: {employee.Age}";
            else
                message = "Incorrect data";
        }
        catch { }

        await response.WriteAsJsonAsync(new { text = message });
    }
    else
    {
        response.ContentType = "text/html; charset = utf8";
        await response.SendFileAsync("html/index_json.html");
    }
});


app.Run();
