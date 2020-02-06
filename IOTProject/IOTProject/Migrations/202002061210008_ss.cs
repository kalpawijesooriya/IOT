namespace IOTProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Switches");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Switches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Defect1 = c.Boolean(nullable: false),
                        Defect3 = c.Boolean(nullable: false),
                        Defect2 = c.Boolean(nullable: false),
                        Defect4 = c.Boolean(nullable: false),
                        status = c.String(),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
