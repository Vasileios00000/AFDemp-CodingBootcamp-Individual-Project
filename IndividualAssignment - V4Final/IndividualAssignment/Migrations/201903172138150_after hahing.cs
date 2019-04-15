namespace IndividualAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afterhahing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        AssignmentID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        SubmissionDateAndTime = c.DateTime(nullable: false),
                        Course_CourseID = c.Int(),
                        Trainer_TrainerID = c.Int(),
                    })
                .PrimaryKey(t => t.AssignmentID)
                .ForeignKey("dbo.Courses", t => t.Course_CourseID)
                .ForeignKey("dbo.Trainers", t => t.Trainer_TrainerID)
                .Index(t => t.Course_CourseID)
                .Index(t => t.Trainer_TrainerID);
            
            CreateTable(
                "dbo.StudentAssignments",
                c => new
                    {
                        StudentID = c.Int(nullable: false),
                        AssignmentID = c.Int(nullable: false),
                        SubmittedYesorNo = c.String(),
                        Mark = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentID, t.AssignmentID })
                .ForeignKey("dbo.Assignments", t => t.AssignmentID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.AssignmentID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        TuitionFees = c.Int(nullable: false),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Stream = c.Boolean(nullable: false),
                        Type = c.Boolean(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Trainer_TrainerID = c.Int(),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Trainers", t => t.Trainer_TrainerID)
                .Index(t => t.Trainer_TrainerID);
            
            CreateTable(
                "dbo.HeadMasters",
                c => new
                    {
                        HeadMasterID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Password = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.HeadMasterID);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        TrainerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Subject = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.TrainerID);
            
            CreateTable(
                "dbo.CourseStudents",
                c => new
                    {
                        Course_CourseID = c.Int(nullable: false),
                        Student_StudentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_CourseID, t.Student_StudentID })
                .ForeignKey("dbo.Courses", t => t.Course_CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_StudentID, cascadeDelete: true)
                .Index(t => t.Course_CourseID)
                .Index(t => t.Student_StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Trainer_TrainerID", "dbo.Trainers");
            DropForeignKey("dbo.Assignments", "Trainer_TrainerID", "dbo.Trainers");
            DropForeignKey("dbo.StudentAssignments", "StudentID", "dbo.Students");
            DropForeignKey("dbo.CourseStudents", "Student_StudentID", "dbo.Students");
            DropForeignKey("dbo.CourseStudents", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.Assignments", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.StudentAssignments", "AssignmentID", "dbo.Assignments");
            DropIndex("dbo.CourseStudents", new[] { "Student_StudentID" });
            DropIndex("dbo.CourseStudents", new[] { "Course_CourseID" });
            DropIndex("dbo.Courses", new[] { "Trainer_TrainerID" });
            DropIndex("dbo.StudentAssignments", new[] { "AssignmentID" });
            DropIndex("dbo.StudentAssignments", new[] { "StudentID" });
            DropIndex("dbo.Assignments", new[] { "Trainer_TrainerID" });
            DropIndex("dbo.Assignments", new[] { "Course_CourseID" });
            DropTable("dbo.CourseStudents");
            DropTable("dbo.Trainers");
            DropTable("dbo.HeadMasters");
            DropTable("dbo.Courses");
            DropTable("dbo.Students");
            DropTable("dbo.StudentAssignments");
            DropTable("dbo.Assignments");
        }
    }
}
