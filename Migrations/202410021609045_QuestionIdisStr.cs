namespace EmployeePolls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionIdisStr : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Questions");
            AlterColumn("dbo.Users", "QuestionId", c => c.String());
            AlterColumn("dbo.Questions", "QuestionId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Questions", "QuestionId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Questions");
            AlterColumn("dbo.Questions", "QuestionId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Users", "QuestionId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Questions", "QuestionId");
        }
    }
}
