namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VoteEntities", "IsAnonymous", c => c.Boolean(nullable: false));
            DropColumn("dbo.PollEntities", "IsAnonymous");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PollEntities", "IsAnonymous", c => c.Boolean(nullable: false));
            DropColumn("dbo.VoteEntities", "IsAnonymous");
        }
    }
}
