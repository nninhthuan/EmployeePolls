namespace EmployeePolls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerId = c.String(nullable: false, maxLength: 128),
                        NumberOfOptionOne = c.String(),
                        IsSelectedOptionOne = c.Boolean(nullable: false),
                        NumberOfOptionTwo = c.String(),
                        IsSelectedOptionTwo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerId);
            
            CreateTable(
                "dbo.UserAnswers",
                c => new
                    {
                        UserAnswerId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        AnswerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserAnswerId)
                .ForeignKey("dbo.Answers", t => t.AnswerId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.AnswerId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        Username = c.String(),
                        AvatarURL = c.String(),
                        QuestionId = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.String(nullable: false, maxLength: 128),
                        Author = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        QuestionLabel = c.String(),
                        AnswerId = c.String(maxLength: 128),
                        User_UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Answers", t => t.AnswerId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.AnswerId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAnswers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Questions", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Questions", "AnswerId", "dbo.Answers");
            DropForeignKey("dbo.UserAnswers", "AnswerId", "dbo.Answers");
            DropIndex("dbo.Questions", new[] { "User_UserId" });
            DropIndex("dbo.Questions", new[] { "AnswerId" });
            DropIndex("dbo.UserAnswers", new[] { "AnswerId" });
            DropIndex("dbo.UserAnswers", new[] { "UserId" });
            DropTable("dbo.Questions");
            DropTable("dbo.Users");
            DropTable("dbo.UserAnswers");
            DropTable("dbo.Answers");
        }
    }
}
