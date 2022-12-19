using Microsoft.Extensions.Primitives;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//HTTP Status Code
//we can use if else statement also
/*app.Run(async (HttpContext context) =>
{
    context.Response.StatusCode = 400;
    await context.Response.WriteAsync("Hello World");
});*/


//HTTP Reasponse Headers
/*app.Run(async (HttpContext context) =>
{
    context.Response.Headers["MyKey"] = "My Value";
    context.Response.Headers["Server"] = "My Server";
    context.Response.Headers["Content-Type"] = "text/html";
    context.Response.StatusCode = 400;
    await context.Response.WriteAsync("<h1>Hello World</h1>");  
});*/

//HTTP Request 
/*app.Run(async (HttpContext context) =>
{
    string path=context.Request.Path;
    string method = context.Request.Method;
    context.Response.Headers["Content-type"] = "text/html";
    await context.Response.WriteAsync($"<p>{path}</p>");
    await context.Response.WriteAsync($"<p>{method}</p>");
});*/

//Query string
/*app.Run(async (HttpContext context) =>
{
    context.Response.Headers["Content-type"] = "text/html";
    if (context.Request.Method == "GET")
    {
        if(context.Request.Query.ContainsKey("id"))
        {
            var id = context.Request.Query["id"];
            await context.Response.WriteAsync($"<p>{id}</p>");
        }
    }   
  
});*/

//Request Headers
/*app.Run(async (HttpContext context) =>
{
    context.Response.Headers["Content-type"] = "text/html";
    if (context.Request.Headers.ContainsKey("User=Agent"))          //can not take get method becuse headers are prosent in both get & post
    {
        string UserAgent = context.Request.Headers["User-Agent"];
        await context.Response.WriteAsync($"<p>{UserAgent}</p>");
    }

});*/

//postman
/*app.Run(async (HttpContext context) =>
{
    context.Response.Headers["Content-type"] = "text/html";
    if (context.Request.Headers.ContainsKey("AuthorizationKey"))          
    {
        string auth = context.Request.Headers["AuthorizationKey"];
        await context.Response.WriteAsync($"<p>{auth}</p>");
    }

});*/

//read request body
app.Run(async (HttpContext context) =>
{
    StreamReader reader = new StreamReader(context.Request.Body);          //strem used then read data in stream format i.e file format
    String body=await reader.ReadToEndAsync();

    Dictionary<string, StringValues> queryDict =Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

    if(queryDict.ContainsValue("firstname"))
    {
        string firstName = queryDict["firstName"][0];
        await context.Response.WriteAsync(firstName);
    }
});
app.Run();
