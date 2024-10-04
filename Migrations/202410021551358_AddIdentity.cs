namespace EmployeePolls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAnswers", "AnswerId", "dbo.Answers");
            DropForeignKey("dbo.UserAnswers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Questions", "AnswerId", "dbo.Answers");
            DropForeignKey("dbo.Questions", "User_UserId", "dbo.Users");
            DropIndex("dbo.UserAnswers", new[] { "UserId" });
            DropIndex("dbo.UserAnswers", new[] { "AnswerId" });
            DropIndex("dbo.Questions", new[] { "AnswerId" });
            DropIndex("dbo.Questions", new[] { "User_UserId" });
            DropPrimaryKey("dbo.Answers");
            DropPrimaryKey("dbo.UserAnswers");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Questions");
            AddColumn("dbo.UserAnswers", "Answer_AnswerId", c => c.Int());
            AddColumn("dbo.UserAnswers", "User_UserId", c => c.Int());
            AddColumn("dbo.Questions", "Answers_AnswerId", c => c.Int());
            AlterColumn("dbo.Answers", "AnswerId", c => c.Int(nullable: true, identity: true));
            AlterColumn("dbo.UserAnswers", "UserAnswerId", c => c.Int(nullable: true, identity: true));
            AlterColumn("dbo.UserAnswers", "UserId", c => c.String());
            AlterColumn("dbo.UserAnswers", "AnswerId", c => c.String());
            AlterColumn("dbo.Users", "UserId", c => c.Int(nullable: true, identity: true));
            AlterColumn("dbo.Questions", "QuestionId", c => c.Int(nullable: true, identity: true));
            AlterColumn("dbo.Questions", "AnswerId", c => c.String());
            AlterColumn("dbo.Questions", "User_UserId", c => c.Int());
            AddPrimaryKey("dbo.Answers", "AnswerId");
            AddPrimaryKey("dbo.UserAnswers", "UserAnswerId");
            AddPrimaryKey("dbo.Users", "UserId");
            AddPrimaryKey("dbo.Questions", "QuestionId");
            CreateIndex("dbo.UserAnswers", "Answer_AnswerId");
            CreateIndex("dbo.UserAnswers", "User_UserId");
            CreateIndex("dbo.Questions", "Answers_AnswerId");
            CreateIndex("dbo.Questions", "User_UserId");
            AddForeignKey("dbo.UserAnswers", "Answer_AnswerId", "dbo.Answers", "AnswerId");
            AddForeignKey("dbo.UserAnswers", "User_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Questions", "Answers_AnswerId", "dbo.Answers", "AnswerId");
            AddForeignKey("dbo.Questions", "User_UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Questions", "Answers_AnswerId", "dbo.Answers");
            DropForeignKey("dbo.UserAnswers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.UserAnswers", "Answer_AnswerId", "dbo.Answers");
            DropIndex("dbo.Questions", new[] { "User_UserId" });
            DropIndex("dbo.Questions", new[] { "Answers_AnswerId" });
            DropIndex("dbo.UserAnswers", new[] { "User_UserId" });
            DropIndex("dbo.UserAnswers", new[] { "Answer_AnswerId" });
            DropPrimaryKey("dbo.Questions");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.UserAnswers");
            DropPrimaryKey("dbo.Answers");
            AlterColumn("dbo.Questions", "User_UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Questions", "AnswerId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Questions", "QuestionId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Users", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserAnswers", "AnswerId", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserAnswers", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserAnswers", "UserAnswerId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Answers", "AnswerId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Questions", "Answers_AnswerId");
            DropColumn("dbo.UserAnswers", "User_UserId");
            DropColumn("dbo.UserAnswers", "Answer_AnswerId");
            AddPrimaryKey("dbo.Questions", "QuestionId");
            AddPrimaryKey("dbo.Users", "UserId");
            AddPrimaryKey("dbo.UserAnswers", "UserAnswerId");
            AddPrimaryKey("dbo.Answers", "AnswerId");
            CreateIndex("dbo.Questions", "User_UserId");
            CreateIndex("dbo.Questions", "AnswerId");
            CreateIndex("dbo.UserAnswers", "AnswerId");
            CreateIndex("dbo.UserAnswers", "UserId");
            AddForeignKey("dbo.Questions", "User_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Questions", "AnswerId", "dbo.Answers", "AnswerId");
            AddForeignKey("dbo.UserAnswers", "UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.UserAnswers", "AnswerId", "dbo.Answers", "AnswerId");
        }
    }
}
