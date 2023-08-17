﻿using Microsoft.EntityFrameworkCore;
using Model;

namespace Data
{
    public class ProfessionalContext : DbContext
    {
        public ProfessionalContext(DbContextOptions<ProfessionalContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Professional>()
                .HasOne(p => p.Contact)
                .WithOne()
                .HasForeignKey<Professional>(p => p.Id);



            modelBuilder.Entity<Professional>()
                .HasMany(p => p.Experiences)
                .WithOne()
                .HasForeignKey(e => e.ProfessionalId);

            modelBuilder.Entity<Professional>()
                .HasMany(p => p.Tools)
                .WithOne()
                .HasForeignKey(t => t.ProfessionalId);

            modelBuilder.Entity<Professional>()
                .HasMany(p => p.Trainings)
                .WithOne()
                .HasForeignKey(t => t.ProfessionalId);

            #region Seeds
            #endregion
            modelBuilder.Entity<Contact>().HasData(
                 new Contact
                 {
                     Id = 1,
                     ProfessionalId = 1,
                     PhoneNumber = "+54 9 381 5500 999",
                     Email = "martin.lopezrubio@gmail.com",
                     Github = "https://github.com/Tincho-dev",
                     LinkedIn = "https://www.linkedin.com/in/martinlopezrubio/",
                     City = "Tucuman, Argentina"
                 }
                );

            modelBuilder.Entity<Tool>().HasData(
                new Tool
                {
                    Id = 1,
                    Name = "C#",
                    ProfessionalId = 1,
                    Description = "",
                    LogoUrl = "images/Csharp_Logo.png"
                    //LogoUrl = "https://e7.pngegg.com/pngimages/328/221/png-clipart-c-programming-language-logo-microsoft-visual-studio-net-framework-javascript-icon-purple-logo.png"
                },
                new Tool
                {
                    Id = 2,
                    ProfessionalId = 1,
                    Name = "Azure DevOps",
                    Description = "",
                    LogoUrl = "images/AzureDevOps_Logo.png"
                },
                new Tool
                {
                    Id = 3,
                    ProfessionalId = 1,
                    Name = "Visual Studio",
                    Description = "",
                    LogoUrl = "images/VisualStudio2022_Logo.png"
                },
                new Tool
                {
                    Id = 4,
                    ProfessionalId = 1,
                    Name = "Blazor",
                    Description = "",
                    LogoUrl = "images/Blazor_Logo.png"
                },
                new Tool
                {
                    Id = 5,
                    ProfessionalId = 1,
                    Name = "Github",
                    Description = "",
                    LogoUrl = "images/GitHub_Logo.png"
                }
                );

            modelBuilder.Entity<Interest>().HasData(
                new Interest
                {
                    Id = 1,
                    ProfessionalId = 1,
                    Name = "English"
                },
                new Interest
                {
                    Id = 2,
                    ProfessionalId = 1,
                    Name = "Music"
                },
                new Interest
                {
                    Id = 3,
                    ProfessionalId = 1,
                    Name = "Emotional Intelligence"
                },
                new Interest
                {
                    Id = 4,
                    ProfessionalId = 1,
                    Name = "Finance"
                },
                new Interest
                {
                    Id = 5,
                    ProfessionalId = 1,
                    Name = "Sustainability"
                },
                new Interest
                {
                    Id = 6,
                    ProfessionalId = 1,
                    Name = "Travel"
                },
                new Interest
                {
                    Id = 7,
                    ProfessionalId = 1,
                    Name = "Augmented Reality"
                },
                new Interest
                {
                    Id = 8,
                    ProfessionalId = 1,
                    Name = "Artificial Intelligence"
                },
                new Interest
                {
                    Id = 9,
                    ProfessionalId = 1,
                    Name = "Data Analysis"
                },
                new Interest
                {
                    Id = 10,
                    ProfessionalId = 1,
                    Name = "Machine Learning"
                }
                );

            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Value = "Queries to Entity Framework context using Linq", ExperinceId = 1 },
                new Skill { Id = 2, Value = "Managing GIT Versions", ExperinceId = 1 },
                new Skill { Id = 3, Value = "Apply Design Patterns", ExperinceId = 1 },
                new Skill { Id = 4, Value = "Develop UML Documentation", ExperinceId = 1 },
                new Skill { Id = 5, Value = "Programming Fullstack in C# ASP.NET MVC with Razor", ExperinceId = 1 },
                new Skill { Id = 6, Value = "Programming Fullstack in C# with components Blazor", ExperinceId = 1 },
                new Skill { Id = 7, Value = "Work in Agile and SCRUM Teams", ExperinceId = 1 },
                new Skill { Id = 8, Value = "Analyze the Domain and Business", ExperinceId = 1 },
                new Skill { Id = 9, Value = "Lead Work Teams", ExperinceId = 1 },
                new Skill { Id = 10, Value = "Train and Guide colleagues in the development", ExperinceId = 1 },
                new Skill { Id = 11, Value = "Perform Data Management and SQL Server Database", ExperinceId = 1 },
                new Skill { Id = 12, Value = "management", ExperinceId = 1 },
                new Skill { Id = 13, Value = "Configuration Management (Azure DevOps)", ExperinceId = 1 },
                new Skill { Id = 14, Value = "Apply Continuous Delivery and Continuous Deployment (CI-CD)", ExperinceId = 1 },
                new Skill { Id = 15, Value = "Work efficiently under pressure", ExperinceId = 1 },
                new Skill { Id = 16, Value = "Investigate solutions in a self-taught way", ExperinceId = 1 },
                new Skill { Id = 17, Value = "Collect Ionospheric Data", ExperinceId = 2 },
                new Skill { Id = 18, Value = "Tools used: C#, Python (Jupyter Notebook)", ExperinceId = 2 },
                new Skill { Id = 19, Value = "Investigate about Machine Learning and Deep Learning", ExperinceId = 2 },
                new Skill { Id = 20, Value = "Teamwork", ExperinceId = 2 },
                new Skill { Id = 21, Value = "Automate data collection using RESTful APIs and ASP.NET", ExperinceId = 2 }
                );

            modelBuilder.Entity<Detail>().HasData(
                new Detail { Id = 1, Value = "English Certificate A1 - A2", ProfessionalId = 1 },
                new Detail { Id = 2, Value = "English in Certification Process B1", ProfessionalId = 1 },
                new Detail { Id = 3, Value = "Basic French learned in secondary as a Foreign Language", ProfessionalId = 1 },
                new Detail { Id = 4, Value = "Courses Taken on Time Management and Emotional Intelligence", ProfessionalId = 1 },
                new Detail { Id = 5, Value = "General average in the university of 7.84", ProfessionalId = 1 }
                );

            modelBuilder.Entity<Experience>().HasData(
                new Experience
                {
                    Id = 1,
                    Name = "Integrator Final Works",
                    YearStart = 2019,
                    Role = "Project Leader - Programmer",
                },
                new Experience
                {
                    Id = 2,
                    Name = "CIASUR - RESEARCH CENTER",
                    YearStart = 2022,
                    YearFinish = 2023,
                    Role = "Collection for Data Analysis - Intern",
                }
                );

            modelBuilder.Entity<Training>().HasData(
                new Training
                {
                    Id = 1,
                    ProfessionalId = 1,
                    Accademy = "National Technological University - UTN",
                    Speciality = "Informastion Systems Engineering",
                    YearStart = 2019
                },
                new Training
                {
                    Id = 2,
                    ProfessionalId = 1,
                    Accademy = "Platzi",
                    Speciality = "English, Software Development and Soft Skills majors",
                    YearStart = 2022
                }
                );

            modelBuilder.Entity<Professional>().HasData(
                new Professional
                {
                    Id = 1,
                    Name = "Martin Lopez Rubio",
                    Role = "Software Developer / Data Engineer",
                    ProfessionalProfile = @"I am an Information Systems Engineering Student with 3 years of
experience in software development. I am looking to collaborate in a
position as a .Net Developer since I have certified in Fundamentals
of Entity Framework, Linq and Blazor."
                }
            );
        }

        public DbSet<Professional> Professionals => Set<Professional>();
        public DbSet<Interest> Interests => Set<Interest>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Tool> Tools => Set<Tool>();
        public DbSet<Experience> Experiences => Set<Experience>();
        public DbSet<Training> Trainings => Set<Training>();
        public DbSet<Contact> Contacts => Set<Contact>();
        public DbSet<Detail> Details => Set<Detail>();
        public DbSet<Skill> Skills => Set<Skill>();
    }
}
