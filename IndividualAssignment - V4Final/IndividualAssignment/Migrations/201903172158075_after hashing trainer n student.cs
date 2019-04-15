namespace IndividualAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afterhashingtrainernstudent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Password", c => c.Double(nullable: false));
            AlterColumn("dbo.Trainers", "Password", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainers", "Password", c => c.String());
            AlterColumn("dbo.Students", "Password", c => c.String());
        }
    }
}
