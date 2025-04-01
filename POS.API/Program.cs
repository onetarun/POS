using Microsoft.AspNetCore.Identity;
using POS.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using POS.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")??string.Empty;
builder.Services.AddDataBase(connectionString)
    .AddIdentity(builder.Configuration);


builder.Services.AddControllers();
var app = builder.Build();
await app.SeedDatabaseAsync();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
