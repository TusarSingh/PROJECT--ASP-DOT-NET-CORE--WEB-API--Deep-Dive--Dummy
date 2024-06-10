using Radhey.DAL.DatabaseContext;

//using Microsoft.EntityFrameworkCore.SqlServer;                  //          UseSqlServer
using Microsoft.EntityFrameworkCore;                              //          UseSqlServer
using Radhey.DAL.IdentityTables;


using Radhey.BAL.Interface.IAccountBAL;
using Radhey.BAL.Implementation.AccountBAL;
using Microsoft.Extensions.DependencyInjection;

using Radhey.Repository.Interface.IAccountRepo;
using Radhey.Repository.Implementation.AccountRepo;
using Radhey.Repository.Interface.IAccountRepo.IUserRegistrationRepo;
using Radhey.Repository.Implementation.AccountRepo.UserRegistrationRepo;


using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);





// Add services to the container.

builder.Services.AddControllers();











// All Services Register



builder.Services.AddTransient<IAccountBAL, AccountBAL>();
builder.Services.AddTransient<IAccountRepo, AccountRepo>();

builder.Services.AddTransient<IUserRegistrationWithEFC, UserRegistrationWithEFC>();


builder.Services.AddTransient<ICustomUserManager, CustomUserManager>();
builder.Services.AddTransient<ICustomSignInManager, CustomSignInManager>();


builder.Services.AddTransient<UserManager<TblApplicationUser>>();
builder.Services.AddTransient<SignInManager<TblApplicationUser>>();













var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<RadheyDbContext>(options =>
    options.UseSqlServer(connectionString));


//builder.Services.AddIdentityCore<TblApplicationUser>().AddEntityFrameworkStores<RadheyDbContext>();


builder.Services.AddIdentity<TblApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<RadheyDbContext>()
    .AddDefaultTokenProviders();













// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.Run(async context =>
    //{
    //    await context.Response.WriteAsync("Hello Readers!");
    //});

    app.UseSwagger();
    app.UseSwaggerUI();
}






// Middleware 




//app.UseHttpsRedirection();
//app.UseStaticFiles();
//// app.UseCookiePolicy();

//app.UseRouting();














app.UseAuthorization();





//app.MapDefaultControllerRoute();






app.MapControllers();

app.Run();
