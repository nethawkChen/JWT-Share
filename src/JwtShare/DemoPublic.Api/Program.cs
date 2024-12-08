using JwtAuth.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 設定 JWT Authentication for both services
var serviceASettings = builder.Configuration.GetSection("JwtSettings:ServiceA").Get<JwtSettings>();
var serviceBSettings = builder.Configuration.GetSection("JwtSettings:ServiceB").Get<JwtSettings>();
builder.Services.AddMultipleJwtAuthentication(serviceASettings!, serviceBSettings!);  // DemoPublic.Api 可接受 Service.A 和 Service.B 的 JWT 認證設定

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
