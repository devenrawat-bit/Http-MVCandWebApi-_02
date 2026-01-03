var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.Run(async (HttpContext context) =>
{
    //context.Response.Headers["My-key"] = "my value";
    //note that in the key there should not a single space but in the value you can add the space in between 
    //context.Response.Headers["Server"] = "Abhimanyu";
    //this should only be the dictionary(key value pair)

    context.Response.Headers["Content-Type"] = "text/html";

    if (context.Request.Method=="GET")
    {
        if (context.Request.Query.ContainsKey("id"))
        {
            string id = context.Request.Query["id"];
            await context.Response.WriteAsync($"<h1>{id}</h1>"); //before using this tag line make sure that you use the content type above it 
        }
    }


    //other are 
    //content type 
    //content length 
    //cache control-->no cache, that means that dont store that in the cache memory, if you want to enable the cache then set the number of the seconds that you want the cached data for (max-age=60) 60 here is the seconds 
    //set-cookie 
    //location -->contains the url to redirect 
    //access-control-access-origin --> used to set the cors 


    string path=context.Request.Path; //this will give us the path that is present in the request body 
    string methamphatamine = context.Request.Method;
    await context.Response.WriteAsync($"<p>{path}</p>");
    await context.Response.WriteAsync($"<p>{methamphatamine}</p>");

    //below we can also use the if else case 

    //context.Request
    //context.Response.StatusCode = 400;
    //here no need to give the status description the browser will take that automatically 

    //now to write something in the response body we will use the below 
    //await context.Response.WriteAsync("Hey Deven Developer");
    //await context.Response.WriteAsync("<h1>Hey Deven Developer</h1>");
});
app.Run();
