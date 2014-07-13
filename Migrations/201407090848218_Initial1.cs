namespace PhoneAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Emps", "phone", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Emps", "mobile", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Emps", "mobile", c => c.Int(nullable: false));
            AlterColumn("dbo.Emps", "phone", c => c.Int(nullable: false));
        }
    }
}
