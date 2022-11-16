using ECommerceGP.Bl;
using ECommerceGP.Bl.Managers.UserManager;
using ECommerceGP.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace ECommerceGP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddCors();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //Adding Dbcontext service
            builder.Services.AddDbContext<ApplicationDbcontext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("connection")));
            
            //adding automapp service
            builder.Services.AddAutoMapper(typeof(AuotMapperProfile).Assembly);
            //AddGenderServices
            builder.Services.AddScoped<IGenderRepo,GenderRepo>();
            builder.Services.AddScoped<IGenderManager,GenderManager>();
            builder.Services.AddScoped<Icateogoryrepo, CategoryRepo>();
            builder.Services.AddScoped<IcateogoryManeger,Cateogorymanager>();
            builder.Services.AddScoped<IProductRepo, Productrepo>();
            builder.Services.AddScoped<IProductManager, ProductManager>();
            builder.Services.AddScoped<IShoppingCardHeaderRepo, ShoppingCardHeaderRepo>();
            builder.Services.AddScoped<IShoppingCardHeaderManager, ShoppingCardHeaderManager>();
            builder.Services.AddScoped<IUserRepo,UserRepo>();
            builder.Services.AddScoped<IUserManager,UserManager>();

            #region Identity
            //adding dbcontext for identity
            builder.Services.AddIdentity<User, IdentityRole<int>>(Options =>
            {
                Options.User.RequireUniqueEmail= true;
                Options.Password.RequiredLength = 8;
                Options.Lockout.MaxFailedAccessAttempts = 5;
                Options.Lockout.DefaultLockoutTimeSpan= TimeSpan.FromSeconds(20);
                

            }).AddEntityFrameworkStores<ApplicationDbcontext>();
            #endregion

            #region Authentication
            builder.Services.AddAuthentication(Options=>
            {
                Options.DefaultAuthenticateScheme = "Default";
                Options.DefaultChallengeScheme= "Default";
            })
          .AddJwtBearer("Default", options =>
            {
                var KeyString = builder.Configuration.GetValue<string>("SecretKey");
                var KeyInBytes= Encoding.ASCII.GetBytes(KeyString);
                var Key = new SymmetricSecurityKey(KeyInBytes);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey=Key,
                    ValidateIssuer=false,
                    ValidateAudience=false
                };
            });

            #endregion

            #region Authorization
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("user", policy => policy
                .RequireClaim(ClaimTypes.Role, "Client")
                .RequireClaim(ClaimTypes.NameIdentifier)
                );
            });
            #endregion

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseCors(c => c
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin());

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}