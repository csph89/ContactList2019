namespace ContactList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateContacts : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Contacts (Name, Email, Address, Phone) VALUES ('Gerasimos Kriketos', 'gerkriketos@gmail.com', 'Alamanas 14', '6939634572')");

        }

        public override void Down()
        {
        }
    }
}
