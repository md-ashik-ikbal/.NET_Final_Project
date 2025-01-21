namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OptionEntities",
                c => new
                    {
                        OptionId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        VoteCount = c.Int(nullable: false),
                        PollId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OptionId)
                .ForeignKey("dbo.PollEntities", t => t.PollId, cascadeDelete: true)
                .Index(t => t.PollId);
            
            CreateTable(
                "dbo.PollEntities",
                c => new
                    {
                        PollId = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        EndDateTime = c.DateTime(nullable: false),
                        IsAnonymous = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PollId);
            
            CreateTable(
                "dbo.VoteEntities",
                c => new
                    {
                        VoteId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        OptionId = c.Int(nullable: false),
                        PollId = c.Int(nullable: false),
                        UserEntity_UserId = c.Int(),
                        PollEntity_PollId = c.Int(),
                        OptionEntity_OptionId = c.Int(),
                    })
                .PrimaryKey(t => t.VoteId)
                .ForeignKey("dbo.OptionEntities", t => t.OptionId)
                .ForeignKey("dbo.PollEntities", t => t.PollId)
                .ForeignKey("dbo.UserEntities", t => t.UserEntity_UserId)
                .ForeignKey("dbo.UserEntities", t => t.UserId)
                .ForeignKey("dbo.PollEntities", t => t.PollEntity_PollId)
                .ForeignKey("dbo.OptionEntities", t => t.OptionEntity_OptionId)
                .Index(t => t.UserId)
                .Index(t => t.OptionId)
                .Index(t => t.PollId)
                .Index(t => t.UserEntity_UserId)
                .Index(t => t.PollEntity_PollId)
                .Index(t => t.OptionEntity_OptionId);
            
            CreateTable(
                "dbo.UserEntities",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        UserEmail = c.String(),
                        PasswordHash = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VoteEntities", "OptionEntity_OptionId", "dbo.OptionEntities");
            DropForeignKey("dbo.OptionEntities", "PollId", "dbo.PollEntities");
            DropForeignKey("dbo.VoteEntities", "PollEntity_PollId", "dbo.PollEntities");
            DropForeignKey("dbo.VoteEntities", "UserId", "dbo.UserEntities");
            DropForeignKey("dbo.VoteEntities", "UserEntity_UserId", "dbo.UserEntities");
            DropForeignKey("dbo.VoteEntities", "PollId", "dbo.PollEntities");
            DropForeignKey("dbo.VoteEntities", "OptionId", "dbo.OptionEntities");
            DropIndex("dbo.VoteEntities", new[] { "OptionEntity_OptionId" });
            DropIndex("dbo.VoteEntities", new[] { "PollEntity_PollId" });
            DropIndex("dbo.VoteEntities", new[] { "UserEntity_UserId" });
            DropIndex("dbo.VoteEntities", new[] { "PollId" });
            DropIndex("dbo.VoteEntities", new[] { "OptionId" });
            DropIndex("dbo.VoteEntities", new[] { "UserId" });
            DropIndex("dbo.OptionEntities", new[] { "PollId" });
            DropTable("dbo.UserEntities");
            DropTable("dbo.VoteEntities");
            DropTable("dbo.PollEntities");
            DropTable("dbo.OptionEntities");
        }
    }
}
