namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0e92f18a-e80f-4458-955b-e7489610a85a', N'manager@vidly.com', 0, N'AB2TvWfAEUR3s3doRgeQeX0BWSSy0ULODlDa72BdYX0JnCYgfi72hlChZUxdj8ji2g==', N'06bed410-5180-493d-b887-463a0f107765', NULL, 0, 0, NULL, 1, 0, N'manager@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ae30912e-0aa3-47db-9415-0f953ed9d723', N'guest@vidly.com', 0, N'AFSYSMLAM91bhMZ07hDjSkgl0mLIk8Zb9DzzrF9etzn9PWq9YsAlicNgsWh1mJWpNQ==', N'b36cccb6-8e79-4917-80b5-cd23d2d3d22f', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c05ebcd2-ce85-49ae-a8f6-4f8e4ad54404', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0e92f18a-e80f-4458-955b-e7489610a85a', N'c05ebcd2-ce85-49ae-a8f6-4f8e4ad54404')
");

        }

    public override void Down()
        {
        }
    }
}
