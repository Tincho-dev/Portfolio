using Microsoft.EntityFrameworkCore;
using Model.About;

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
                .HasForeignKey(e => e.TimeFrameId);

            modelBuilder.Entity<Professional>()
                .HasMany(p => p.Tools)
                .WithOne()
                .HasForeignKey(t => t.Id);

            modelBuilder.Entity<Professional>()
                .HasMany(p => p.Trainings)
                .WithOne()
                .HasForeignKey(t => t.TimeFrameId);

            modelBuilder.Entity<Professional>().HasData(
                new Professional
                {
                    Id = 1,
                    Name = "Martin Lopez Rubio",
                    Contact = new Contact
                    {
                        Id = 1,
                        PhoneNumber = "+54 9 381 5500 999",
                        Email = "martin.lopezrubio@gmail.com",
                        Github = "https://github.com/Tincho-dev",
                        LinkedIn = "https://www.linkedin.com/in/martinlopezrubio/",
                        City = "Tucuman, Argentina"
                    },
                    Role = "Software Developer / Data Engineer",
                    Tools = new[]
                    {
                        new Tool
                        {
                            Id = 1,
                            Name = "C#",
                            Description = "",
                            LogoUrl = "images/Csharp_Logo.png"
                            //LogoUrl = "https://e7.pngegg.com/pngimages/328/221/png-clipart-c-programming-language-logo-microsoft-visual-studio-net-framework-javascript-icon-purple-logo.png"
                        },
                        new Tool{
                            Id = 2,
                            Name = "Azure DevOps",
                            Description = "",
                            LogoUrl = "images/AzureDevOps_Logo.webp"
                        },
                        new Tool
                        {
                            Id = 3,
                            Name = "Visual Studio",
                            Description = "",
                            LogoUrl = "images/VisualStudio2022_Logo.png"
                        },
                        new Tool
                        {
                            Id = 4,
                            Name = "Blazor",
                            Description = "",
                            LogoUrl = "images/Blazor_Logo.png"
                        },
                        new Tool
                        {
                            Id = 5,
                            Name = "Github",
                            Description = "",
                            LogoUrl = "images/GitHub_Logo.png"
                        }
                    },
                    AdditionalInfo = new[]
                    {
                        "English Certificate A1 - A2",
                        "English in Certification Process B1",
                        "Basic French learned in secondary as a Foreign Language",
                        "Courses Taken on Time Management and Emotional Intelligence",
                        "General average in the university of 7.84"
                    },
                    Interests = new[]
                    {
                        new Interest
                        {
                            Id = 1,
                            Name = "English"
                        },
                        new Interest
                        {
                            Id = 2,
                            Name = "Music"
                        },new Interest
                        {
                            Id = 3,
                            Name = "Emotional Intelligence"
                        },
                        new Interest
                        {
                            Id = 4,
                            Name = "Finance"
                        },
                        new Interest
                        {
                            Id = 5,
                            Name = "Sustainability"
                        },
                        new Interest
                        {
                            Id = 6,
                            Name = "Travel"
                        },
                        new Interest
                        {
                            Id = 7,
                            Name = "Augmented Reality"
                        },
                        new Interest
                        {
                            Id = 8,
                            Name = "Artificial Intelligence"
                        },
                        new Interest
                        {
                            Id = 9,
                            Name = "Data Analysis"
                        },
                        new Interest
                        {
                            Id = 10,
                            Name = "Machine Learning"
                        }
                    },
                    Trainings = new List<Training>
                    {
                        new Training
                        {
                            Id = 1,
                            Accademy = "National Technological University - UTN",
                            Speciality = "Informastion Systems Engineering",
                            TimeFrame = new TimeFrame
                            {
                                Id = 1,
                                YearStart = 2019
                            }
                        },
                        new Training
                        {
                            Id = 2,
                            Accademy = "Platzi",
                            Speciality = "English, Software Development and Soft Skills majors",
                            TimeFrame = new TimeFrame
                            {
                                Id = 2,
                                YearStart = 2022
                            }
                        }
                    },
                    Experiences = new List<Experience>
                    {
                        new Experience
                        {
                            Id = 1,
                            Name = "Integrator Final Works",
                            TimeFrameId = 1,
                            Role = "Project Leader - Programmer",
                            Skills = new string[]
                            {
                                "Queries to Entity Framework context using Linq",
                                "Managing GIT Versions",
                                "Apply Design Patterns",
                                "Develop UML Documentation",
                                "Programming Fullstack in C# ASP.NET MVC with Razor",
                                "Programming Fullstack in C# with components Blazor",
                                "Work in Agile and SCRUM Teams",
                                "Analyze the Domain and Business",
                                "Lead Work Teams",
                                "Train and Guide colleagues in the development",
                                "Perform Data Management and SQL Server Database",
                                "management",
                                "Configuration Management (Azure DevOps)",
                                "Apply Continuous Delivery and Continuous Deployment (CI-CD)",
                                "Work efficiently under pressure",
                                "Investigate solutions in a self-taught way"
                            }
                        },
                        new Experience
                        {
                            Id = 2,
                            Name = "CIASUR - RESEARCH CENTER",
                            TimeFrame = new TimeFrame
                            {
                                Id = 3,
                                YearStart = 2022,
                                YearFinish = 2023
                            },
                            Role = "Collection for Data Analysis - Intern",
                            Skills = new string[]
                            {
                                "Collect Ionospheric Data",
                                "Tools used: C#, Python (Jupyter Notebook)",
                                "Investigate about Machine Learning and Deep Learning",
                                "Teamwork",
                                "Automate data collection using RESTful APIs and ASP.NET"
                            }
                        }
                    },
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
        public DbSet<TimeFrame> TimeFrames => Set<TimeFrame>();
        public DbSet<Experience> Experiences => Set<Experience>();
        public DbSet<Training> Trainings => Set<Training>();
        public DbSet<Contact> Contacts => Set<Contact>();
    }
}
