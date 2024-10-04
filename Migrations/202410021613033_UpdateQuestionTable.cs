namespace EmployeePolls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateQuestionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "VotedOptionOne", c => c.String());
            AddColumn("dbo.Answers", "TextOptionOne", c => c.String());
            AddColumn("dbo.Answers", "VotedOptionTwo", c => c.String());
            AddColumn("dbo.Answers", "TextOptionTwo", c => c.String());
            DropColumn("dbo.Answers", "IsSelectedOptionOne");
            DropColumn("dbo.Answers", "IsSelectedOptionTwo");
            DropColumn("dbo.Questions", "QuestionLabel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "QuestionLabel", c => c.String());
            AddColumn("dbo.Answers", "IsSelectedOptionTwo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Answers", "IsSelectedOptionOne", c => c.Boolean(nullable: false));
            DropColumn("dbo.Answers", "TextOptionTwo");
            DropColumn("dbo.Answers", "VotedOptionTwo");
            DropColumn("dbo.Answers", "TextOptionOne");
            DropColumn("dbo.Answers", "VotedOptionOne");
        }
    }
}
