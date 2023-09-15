using Examination.BL.Interfaces;
using Examination.BL.Repository;
using Examination.DAL.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Examination.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();



            builder.Services.AddDbContext<ExamContext>(opt =>
           opt.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
               .AddEntityFrameworkStores<ExamContext>();


            builder.Services.AddScoped<IExamRepo, ExamRepo>();
            builder.Services.AddScoped<IQuestionRepo, QuestionRepo>();
            builder.Services.AddScoped<IQuestionTypeRepo, QuestionTypeRepo>();
            builder.Services.AddScoped<IAnswerRepo, AnswerRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                //pattern: "{controller=Account}/{action=Login}/{id?}");
                pattern: "{controller=Home}/{action=AllExams}/{id?}");

            app.Run();
        }
    }
}