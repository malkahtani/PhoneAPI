namespace PhoneAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deps",
                c => new
                    {
                        dep_Id = c.Int(nullable: false, identity: true),
                        dep_name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.dep_Id);
            
            CreateTable(
                "dbo.Emps",
                c => new
                    {
                        emp_Id = c.Int(nullable: false, identity: true),
                        rank_Id = c.Int(nullable: false),
                        dep_Id = c.Int(nullable: false),
                        phone = c.Int(nullable: false),
                        mobile = c.Int(nullable: false),
                        emp_name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.emp_Id)
                .ForeignKey("dbo.Deps", t => t.dep_Id, cascadeDelete: true)
                .ForeignKey("dbo.Ranks", t => t.rank_Id, cascadeDelete: true)
                .Index(t => t.rank_Id)
                .Index(t => t.dep_Id);
            
            CreateTable(
                "dbo.Ranks",
                c => new
                    {
                        rank_Id = c.Int(nullable: false, identity: true),
                        rank_name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.rank_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emps", "rank_Id", "dbo.Ranks");
            DropForeignKey("dbo.Emps", "dep_Id", "dbo.Deps");
            DropIndex("dbo.Emps", new[] { "dep_Id" });
            DropIndex("dbo.Emps", new[] { "rank_Id" });
            DropTable("dbo.Ranks");
            DropTable("dbo.Emps");
            DropTable("dbo.Deps");
        }
    }
}
