using ShowcaseServer.Interface;
using ShowcaseServer.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddSingleton<IMailSender, MailtrapMailer>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
        .WithOrigins("http://localhost:4080")  // Alleen frontend poort
        .WithHeaders("Content-Type", "API-Key")
        .WithMethods("POST");
    });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
