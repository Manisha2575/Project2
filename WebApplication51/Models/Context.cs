using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication51.Models
{
    public class Context : DbContext
    {
       public Context() : base("name=MyConnectionString")
        {

        }
        public DbSet<Studente> studentes { get; set; }
        public DbSet<StudenteDetail> studenteDetails { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Student>()
        //       .HasKey(o => o.Id);

        //    modelBuilder.Entity<StudentDetail>()
        //       .HasKey(o => o.Id);

        //    modelBuilder.Entity<StudentDetail>()
        //            .HasRequired(o => o.student)
        //            .WithRequiredDependent(o => o.studentdetail);

        //    base.OnModelCreating(modelBuilder);
        //}
   

    }
}