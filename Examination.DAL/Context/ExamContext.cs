using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examination.DAL.Entities;


namespace Examination.DAL.Context
{
    public class ExamContext : IdentityDbContext
    {
        public ExamContext()
        {

        }

        public ExamContext(DbContextOptions<ExamContext> opt) : base(opt)
        {

        }


        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }


    }
}
