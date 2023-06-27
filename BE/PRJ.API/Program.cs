
var builder = WebApplication.CreateBuilder(args);
builder.Services.InstallServiceAssembly(builder.Configuration);

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
  builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandling>();

app.MapControllers();

app.UseStatusCodePages(async context =>
{
    if (
            context.HttpContext.Response.StatusCode == StatusCodes.Status401Unauthorized ||
            context.HttpContext.Response.StatusCode == StatusCodes.Status403Forbidden
        )
    {
        context.HttpContext.Response.StatusCode = Convert.ToInt32(HttpStatusCode.Unauthorized);
        context.HttpContext.Response.ContentType = "application/json";
        await context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(new OutputDTO<dynamic>()
        {
            Succeeded = false,
            HttpStatusCode = Convert.ToInt32(HttpStatusCode.Unauthorized),
            Message = Convert.ToString(HttpStatusCode.Unauthorized),
            Data = null
        }));
    }


});

app.Run();
