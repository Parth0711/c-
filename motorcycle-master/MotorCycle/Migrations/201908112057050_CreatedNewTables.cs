namespace MotorCycle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedNewTables : DbMigration
    {
        public override void Up()
        {

            //Migrations
            CreateTable(
                "dbo.MotorBikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MotorName = c.String(nullable: false, maxLength: 50),
                        MakeYear = c.Int(nullable: false),
                        Company = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MotorCycleDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MotorBrand = c.String(nullable: false, maxLength: 20),
                        MotorModel = c.String(nullable: false, maxLength: 20),
                        Country = c.String(nullable: false, maxLength: 20),
                        MotorCycleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MotorBikes", t => t.MotorCycleId, cascadeDelete: true)
                .Index(t => t.MotorCycleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MotorCycleDetails", "MotorCycleId", "dbo.MotorBikes");
            DropIndex("dbo.MotorCycleDetails", new[] { "MotorCycleId" });
            DropTable("dbo.MotorCycleDetails");
            DropTable("dbo.MotorBikes");
        }
    }
}
