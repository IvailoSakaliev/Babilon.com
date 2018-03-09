namespace DataAcsess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Facultets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Lectures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Kabinet = c.Int(nullable: false),
                        Mobile = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Login = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Course = c.Int(nullable: false),
                        Semester = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Scholarships",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Srok = c.Int(nullable: false),
                        StartData = c.DateTime(nullable: false),
                        DeadLine = c.DateTime(nullable: false),
                        Size = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SingIns",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Role = c.Int(nullable: false),
                        LastName = c.String(),
                        Email = c.String(),
                        Login = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Specialties",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        YearOFStudy = c.Int(nullable: false),
                        Inspector = c.String(),
                        OKS = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Course = c.Int(nullable: false),
                        Groups = c.Int(nullable: false),
                        OKS = c.Int(nullable: false),
                        LastName = c.String(),
                        Email = c.String(),
                        Login = c.Int(nullable: false),
                        Name = c.String(),
                        Scholarship_ID = c.Int(),
                        Specialties_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Scholarships", t => t.Scholarship_ID)
                .ForeignKey("dbo.Specialties", t => t.Specialties_ID)
                .Index(t => t.Scholarship_ID)
                .Index(t => t.Specialties_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Specialties_ID", "dbo.Specialties");
            DropForeignKey("dbo.Students", "Scholarship_ID", "dbo.Scholarships");
            DropIndex("dbo.Students", new[] { "Specialties_ID" });
            DropIndex("dbo.Students", new[] { "Scholarship_ID" });
            DropTable("dbo.Students");
            DropTable("dbo.Specialties");
            DropTable("dbo.SingIns");
            DropTable("dbo.Scholarships");
            DropTable("dbo.Subjects");
            DropTable("dbo.Lectures");
            DropTable("dbo.Facultets");
        }
    }
}
