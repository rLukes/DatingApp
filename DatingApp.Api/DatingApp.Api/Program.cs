using DatingApp.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

//var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
//            ValidateIssuer = false,
//            ValidateAudience= false
//        };
//    });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(builder =>
           builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
           );

// this jusk do you have valid token
app.UseAuthentication();

//ok, you have a valid token, now what are you allwoed to do
app.UseAuthorization();

app.MapControllers();

app.Run();
