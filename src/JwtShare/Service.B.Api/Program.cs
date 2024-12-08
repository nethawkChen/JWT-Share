using JwtAuth.Common.Extensions;
using JwtAuth.Common.Services;
using Service.B.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// �[�J JWT �{�Ұt�m
builder.Services.AddJwtAuthentication(builder.Configuration);
// �[�J JWT �����A��(�i���w�ͩR�g��)
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
