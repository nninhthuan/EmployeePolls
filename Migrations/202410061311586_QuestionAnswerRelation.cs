namespace EmployeePolls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionAnswerRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "CreatedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Questions", "Timestamp");
            DropColumn("dbo.Questions", "AnswerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "AnswerId", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "Timestamp", c => c.DateTime(nullable: false));
            DropColumn("dbo.Questions", "CreatedDate");
        }
    }
}
