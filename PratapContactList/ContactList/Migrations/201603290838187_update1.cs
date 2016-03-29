namespace ContactList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contacts", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
