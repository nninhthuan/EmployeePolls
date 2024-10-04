namespace EmployeePolls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdentity1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAnswers", "Answer_AnswerId", "dbo.Answers");
            DropForeignKey("dbo.UserAnswers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Questions", "Answers_AnswerId", "dbo.Answers");
            DropIndex("dbo.UserAnswers", new[] { "Answer_AnswerId" });
            DropIndex("dbo.UserAnswers", new[] { "User_UserId" });
            DropIndex("dbo.Questions", new[] { "Answers_AnswerId" });
            DropColumn("dbo.UserAnswers", "AnswerId");
            DropColumn("dbo.UserAnswers", "UserId");
            DropColumn("dbo.Questions", "AnswerId");
            RenameColumn(table: "dbo.UserAnswers", name: "Answer_AnswerId", newName: "AnswerId");
            RenameColumn(table: "dbo.UserAnswers", name: "User_UserId", newName: "UserId");
            RenameColumn(table: "dbo.Questions", name: "Answers_AnswerId", newName: "AnswerId");
            AlterColumn("dbo.UserAnswers", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserAnswers", "AnswerId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserAnswers", "AnswerId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserAnswers", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "QuestionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "AnswerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "AnswerId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserAnswers", "UserId");
            CreateIndex("dbo.UserAnswers", "AnswerId");
            CreateIndex("dbo.Questions", "AnswerId");
            AddForeignKey("dbo.UserAnswers", "AnswerId", "dbo.Answers", "AnswerId", cascadeDelete: true);
            AddForeignKey("dbo.UserAnswers", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "AnswerId", "dbo.Answers", "AnswerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "AnswerId", "dbo.Answers");
            DropForeignKey("dbo.UserAnswers", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserAnswers", "AnswerId", "dbo.Answers");
            DropIndex("dbo.Questions", new[] { "AnswerId" });
            DropIndex("dbo.UserAnswers", new[] { "AnswerId" });
            DropIndex("dbo.UserAnswers", new[] { "UserId" });
            AlterColumn("dbo.Questions", "AnswerId", c => c.Int());
            AlterColumn("dbo.Questions", "AnswerId", c => c.String());
            AlterColumn("dbo.Users", "QuestionId", c => c.String());
            AlterColumn("dbo.UserAnswers", "UserId", c => c.Int());
            AlterColumn("dbo.UserAnswers", "AnswerId", c => c.Int());
            AlterColumn("dbo.UserAnswers", "AnswerId", c => c.String());
            AlterColumn("dbo.UserAnswers", "UserId", c => c.String());
            RenameColumn(table: "dbo.Questions", name: "AnswerId", newName: "Answers_AnswerId");
            RenameColumn(table: "dbo.UserAnswers", name: "UserId", newName: "User_UserId");
            RenameColumn(table: "dbo.UserAnswers", name: "AnswerId", newName: "Answer_AnswerId");
            AddColumn("dbo.Questions", "AnswerId", c => c.String());
            AddColumn("dbo.UserAnswers", "UserId", c => c.String());
            AddColumn("dbo.UserAnswers", "AnswerId", c => c.String());
            CreateIndex("dbo.Questions", "Answers_AnswerId");
            CreateIndex("dbo.UserAnswers", "User_UserId");
            CreateIndex("dbo.UserAnswers", "Answer_AnswerId");
            AddForeignKey("dbo.Questions", "Answers_AnswerId", "dbo.Answers", "AnswerId");
            AddForeignKey("dbo.UserAnswers", "User_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.UserAnswers", "Answer_AnswerId", "dbo.Answers", "AnswerId");
        }
    }
}
