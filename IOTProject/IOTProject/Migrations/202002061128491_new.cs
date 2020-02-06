namespace IOTProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Issues",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DefectID = c.String(),
                        RequestTime = c.DateTime(nullable: false),
                        ResponceTime = c.DateTime(nullable: false),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.Identifies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Identifies",
                c => new
                    {
                        IdentifyID = c.Int(nullable: false, identity: true),
                        DefectID = c.String(),
                        BeltID = c.String(),
                        IdentifiedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdentifyID);
            
            DropTable("dbo.Issues");
        }
    }
}
