using JwtAuth.Common.Extensions;
using JwtAuth.Common.Services;
using Service.A.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 加入 JWT 認證配置
builder.Services.AddJwtAuthentication(builder.Configuration);
// 加入 JWT 相關服務(可指定生命週期)
builder.Services.AddJwtServices(builder.Configuration, ServiceLifetime.Scoped);

// Register Services
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
