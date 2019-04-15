namespace IndividualAssignment.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using IndividualAssignment.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<IndividualAssignment.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IndividualAssignment.MyContext context)
        {


            //context.Students.AddOrUpdate(
            //    if(context.Students.Count

            //new Student
            //{

            //    FirstName = "Manthos",
            //    LastName = "Kalaitzakis",
            //    DateOfBirth = new DateTime(1983 / 15 / 4),
            //    TuitionFees = 3435,
            //    Password = Hashing.HashingMethod("mankal")



         


            

            








            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
