var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<CatService>(new CatService());

var app = builder.Build();

app.MapGet("/", () => "TODO: add manual");
app.MapGet("/hello", () => "Hello World!");
app.MapGet("/cat", async (HttpContext context, CatService helloService) => context.Response.Redirect((await helloService.RandomImage())));
app.MapGet("/catlocal", async (HttpContext context, CatService helloService) => {
    using var inputStream = await helloService.RandomImageStream();
    await inputStream.CopyToAsync(context.Response.Body);
});

app.Run();
