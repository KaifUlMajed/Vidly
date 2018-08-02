namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreModel : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres (Name) values ('Comedy')");
            Sql("Insert into Genres (Name) values ('Horror')");
            Sql("Insert into Genres (Name) values ('Romance')");
            Sql("Insert into Genres (Name) values ('Action')");
            Sql("Insert into Genres (Name) values ('Thriller')");
        }
        
        public override void Down()
        {
        }
    }
}
