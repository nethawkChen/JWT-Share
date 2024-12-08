using JwtAuth.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// �]�w JWT Authentication for both services
var serviceASettings = builder.Configuration.GetSection("JwtSettings:ServiceA").Get<JwtSettings>();
var serviceBSettings = builder.Configuration.GetSection("JwtSettings:ServiceB").Get<JwtSettings>();
builder.Services.AddMultipleJwtAuthentication(serviceASettings!, serviceBSettings!);  // DemoPublic.Api �i���� Service.A �M Service.B �� JWT �{�ҳ]�w

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
