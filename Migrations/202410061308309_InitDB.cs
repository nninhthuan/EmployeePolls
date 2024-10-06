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
                        AnswerId = c.Int(nullable: false, identity: true),
                        VotedOptionOne = c.String(),
                        TextOptionOne = c.String(),
                        VotedOptionTwo = c.String(),
                        TextOptionTwo = c.String(),
                    })
                .PrimaryKey(t => t.AnswerId);
            
            CreateTable(
                "dbo.QuestionAnswers",
                c => new
                    {
                        QAnsID = c.Int(nullable: false, identity: true),
                        QuestionId = c.String(maxLength: 128),
                        AnswerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QAnsID)
                .ForeignKey("dbo.Answers", t => t.AnswerId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .Index(t => t.QuestionId)
                .Index(t => t.AnswerId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.String(nullable: false, maxLength: 128),
                        Author = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        AnswerId = c.Int(nullable: false),
                        User_UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        Username = c.String(),
                        AvatarURL = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.QuestionAnswers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.QuestionAnswers", "AnswerId", "dbo.Answers");
            DropIndex("dbo.Questions", new[] { "User_UserId" });
            DropIndex("dbo.QuestionAnswers", new[] { "AnswerId" });
            DropIndex("dbo.QuestionAnswers", new[] { "QuestionId" });
            DropTable("dbo.Users");
            DropTable("dbo.Questions");
            DropTable("dbo.QuestionAnswers");
            DropTable("dbo.Answers");
        }
    }
}
