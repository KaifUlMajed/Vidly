namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres (ID,Name) values (1,'Comedy')");
            Sql("Insert into Genres (ID,Name) values (2,'Horror')");
            Sql("Insert into Genres (ID,Name) values (3,'Romance')");
            Sql("Insert into Genres (ID,Name) values (4,'Action')");
            Sql("Insert into Genres (ID,Name) values (5,'Thriller')");
            Sql("Insert into Genres (ID,Name) values (6,'Crime')");
            Sql("Insert into Genres (ID,Name) values (7,'Drama')");
            Sql("Insert into Genres (ID,Name) values (8,'Fantasy')");
        }
        
        public override void Down()
        {
        }
    }
}
