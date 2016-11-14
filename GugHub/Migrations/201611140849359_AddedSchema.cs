namespace GugHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSchema : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Attendances", newSchema: "GigHub");
            MoveTable(name: "dbo.AspNetUsers", newSchema: "GigHub");
            MoveTable(name: "dbo.AspNetUserClaims", newSchema: "GigHub");
            MoveTable(name: "dbo.Followings", newSchema: "GigHub");
            MoveTable(name: "dbo.AspNetUserLogins", newSchema: "GigHub");
            MoveTable(name: "dbo.UserNotifications", newSchema: "GigHub");
            MoveTable(name: "dbo.Notifications", newSchema: "GigHub");
            MoveTable(name: "dbo.Gigs", newSchema: "GigHub");
            MoveTable(name: "dbo.Genres", newSchema: "GigHub");
            MoveTable(name: "dbo.AspNetUserRoles", newSchema: "GigHub");
            MoveTable(name: "dbo.AspNetRoles", newSchema: "GigHub");
        }
        
        public override void Down()
        {
            MoveTable(name: "GigHub.AspNetRoles", newSchema: "dbo");
            MoveTable(name: "GigHub.AspNetUserRoles", newSchema: "dbo");
            MoveTable(name: "GigHub.Genres", newSchema: "dbo");
            MoveTable(name: "GigHub.Gigs", newSchema: "dbo");
            MoveTable(name: "GigHub.Notifications", newSchema: "dbo");
            MoveTable(name: "GigHub.UserNotifications", newSchema: "dbo");
            MoveTable(name: "GigHub.AspNetUserLogins", newSchema: "dbo");
            MoveTable(name: "GigHub.Followings", newSchema: "dbo");
            MoveTable(name: "GigHub.AspNetUserClaims", newSchema: "dbo");
            MoveTable(name: "GigHub.AspNetUsers", newSchema: "dbo");
            MoveTable(name: "GigHub.Attendances", newSchema: "dbo");
        }
    }
}
