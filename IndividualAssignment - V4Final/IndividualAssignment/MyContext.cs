namespace IndividualAssignment
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using IndividualAssignment.Models;

    public class MyContext : DbContext
    {
        // Your context has been configured to use a 'MyContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'IndividualAssignment.MyContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MyContext' 
        // connection string in the application configuration file.
        public MyContext()
            : base("name=MyContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<StudentAssignment> StudentAssignments { get; set; }

        public virtual DbSet<HeadMaster> HeadMasters { get; set; }


    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}