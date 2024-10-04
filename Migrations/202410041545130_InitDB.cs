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
                .ForeignKey("dbo.Answers", t => t.AnswerId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.AnswerId)
                .Index(t => t.User_UserId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Questions", "AnswerId", "dbo.Answers");
            DropIndex("dbo.Questions", new[] { "User_UserId" });
            DropIndex("dbo.Questions", new[] { "AnswerId" });
            DropTable("dbo.Users");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
