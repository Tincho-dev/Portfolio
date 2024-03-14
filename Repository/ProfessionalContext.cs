using Microsoft.EntityFrameworkCore;
using Model;
using System.Diagnostics.SymbolStore;

namespace Data;

public class ProfessionalContext : DbContext
{
    public ProfessionalContext(DbContextOptions<ProfessionalContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Seeds
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
             },
             //Professional 2
             new Contact
             {
                 Id = 2,
                 ProfessionalId = 2,
                 PhoneNumber = "+54 9 381 5500 999",
                 Email = "martin.lopezrubio@gmail.com",
                 Github = "https://github.com/Tincho-dev",
                 LinkedIn = "https://www.linkedin.com/in/martinlopezrubio/",
                 City = "Tucuman, Argentina"
             }
            );

        modelBuilder.Entity<Tool>().HasData(
        #region Professional 1 English
            new Tool
            {
                Id = 1,
                Name = "C#",
                ProfessionalId = 1,
                Description = "",
                LogoUrl = "images/Csharp_Logo"//webp"
            },
            new Tool
            {
                Id = 2,
                ProfessionalId = 1,
                Name = "Azure DevOps",
                Description = "",
                LogoUrl = "images/AzureDevOps_Logo"//webp"
            },
            new Tool
            {
                Id = 3,
                ProfessionalId = 1,
                Name = "Visual Studio",
                Description = "",
                LogoUrl = "images/VisualStudio2022_Logo"//webp"
            },
            new Tool
            {
                Id = 4,
                ProfessionalId = 1,
                Name = "Blazor",
                Description = "",
                LogoUrl = "images/Blazor_Logo"//webp"
            },
            new Tool
            {
                Id = 5,
                ProfessionalId = 1,
                Name = "Github",
                Description = "",
                LogoUrl = "images/GitHub_Logo"//webp"
            },
        #endregion
            //Professional 2
        #region Professional 2 Español
            new Tool
            {
                Id = 6,
                Name = "Angular",
                ProfessionalId = 2,
                Description = "",
                LogoUrl = "images/Angular_Logo"//webp"
            },
            new Tool
            {
                Id = 7,
                ProfessionalId = 2,
                Name = "Github",
                Description = "",
                LogoUrl = "images/GitHub_Logo"//webp"
            },
            new Tool
            {
                Id = 8,
                Name = "C#",
                ProfessionalId = 2,
                Description = "",
                LogoUrl = "images/Csharp_Logo"//webp"
            },
            new Tool
            {
                Id = 9,
                ProfessionalId = 2,
                Name = "Blazor",
                Description = "",
                LogoUrl = "images/Blazor_Logo"//webp"
            },
            new Tool
            {
                Id = 10,
                ProfessionalId = 2,
                Name = "Azure DevOps",
                Description = "",
                LogoUrl = "images/AzureDevOps_Logo"//webp"
            },
            new Tool
            {
                Id = 11,
                ProfessionalId = 2,
                Name = "Visual Studio",
                Description = "",
                LogoUrl = "images/VisualStudio2022_Logo"//webp"
            }
            );
        #endregion
        
        modelBuilder.Entity<Interest>().HasData(
        #region Professional 1 English
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
            },
        #endregion
        #region Professional 2 Español
            new Interest
            {
                Id = 11,
                ProfessionalId = 2,
                Name = "Inglés"
            },
            new Interest
            {
                Id = 12,
                ProfessionalId = 2,
                Name = "Musica"
            },
            new Interest
            {
                Id = 13,
                ProfessionalId = 2,
                Name = "Inteligencia Emocional"
            },
            new Interest
            {
                Id = 14,
                ProfessionalId = 2,
                Name = "Finanzas"
            },
            new Interest
            {
                Id = 15,
                ProfessionalId = 2,
                Name = "Sostenibilidad"
            },
            new Interest
            {
                Id = 16,
                ProfessionalId = 2,
                Name = "Viajes"
            },
            new Interest
            {
                Id = 17,
                ProfessionalId = 2,
                Name = "Realidad Aumentada"
            },
            new Interest
            {
                Id = 18,
                ProfessionalId = 2,
                Name = "Inteligencia Artificial"
            },
            new Interest
            {
                Id = 19,
                ProfessionalId = 2,
                Name = "Análisis de Datos"
            },
            new Interest
            {
                Id = 20,
                ProfessionalId = 2,
                Name = "Aprendizaje Automático"
            });
            #endregion

        modelBuilder.Entity<Skill>().HasData(
        #region Professional 1 English
            new Skill { Id = 1, Value = "Queries to Entity Framework context using Linq", ExperienceId = 1 },
            new Skill { Id = 2, Value = "Managing GIT Versions", ExperienceId = 1 },
            new Skill { Id = 3, Value = "Apply Design Patterns", ExperienceId = 1 },
            new Skill { Id = 4, Value = "Develop UML Documentation", ExperienceId = 1 },
            new Skill { Id = 5, Value = "Programming Fullstack in C# ASP.NET MVC with Razor", ExperienceId = 1 },
            new Skill { Id = 6, Value = "Programming Fullstack in C# with components Blazor", ExperienceId = 1 },
            new Skill { Id = 7, Value = "Work in Agile and SCRUM Teams", ExperienceId = 1 },
            new Skill { Id = 8, Value = "Analyze the Domain and Business", ExperienceId = 1 },
            new Skill { Id = 9, Value = "Lead Work Teams", ExperienceId = 1 },
            new Skill { Id = 10, Value = "Train and Guide colleagues in the development", ExperienceId = 1 },
            new Skill { Id = 11, Value = "Perform Data Management and SQL Server Database", ExperienceId = 1 },
            new Skill { Id = 12, Value = "management", ExperienceId = 1 },
            new Skill { Id = 13, Value = "Configuration Management (Azure DevOps)", ExperienceId = 1 },
            new Skill { Id = 14, Value = "Apply Continuous Delivery and Continuous Deployment (CI-CD)", ExperienceId = 1 },
            new Skill { Id = 15, Value = "Work efficiently under pressure", ExperienceId = 1 },
            new Skill { Id = 16, Value = "Investigate solutions in a self-taught way", ExperienceId = 1 },
            new Skill { Id = 17, Value = "Collect Ionospheric Data", ExperienceId = 2 },
            new Skill { Id = 18, Value = "Tools used: C#, Python (Jupyter Notebook)", ExperienceId = 2 },
            new Skill { Id = 19, Value = "Investigate about Machine Learning and Deep Learning", ExperienceId = 2 },
            new Skill { Id = 20, Value = "Teamwork", ExperienceId = 2 },
            new Skill { Id = 21, Value = "Automate data collection using RESTful APIs and ASP.NET", ExperienceId = 2 },
        #endregion
            //Professional 2
        #region Professional 2 Español
            new Skill { Id = 22, Value = "Consultas al contexto de Entity Framework usando Linq", ExperienceId = 4 },
            new Skill { Id = 23, Value = "Gestión de versiones con GIT", ExperienceId = 4 },
            new Skill { Id = 24, Value = "Aplicar Patrones de Diseño", ExperienceId = 4 },
            new Skill { Id = 25, Value = "Desarrollar Documentación UML", ExperienceId = 4 },
            new Skill { Id = 26, Value = "Programación Fullstack en C# ASP.NET MVC con Razor", ExperienceId = 4 },
            new Skill { Id = 27, Value = "Programación Fullstack en C# con componentes Blazor", ExperienceId = 4 },
            new Skill { Id = 28, Value = "Trabajar en Equipos Ágiles y SCRUM", ExperienceId = 4 },
            new Skill { Id = 29, Value = "Analizar el Dominio y el Negocio", ExperienceId = 4 },
            new Skill { Id = 30, Value = "Liderar Equipos de Trabajo", ExperienceId = 4 },
            new Skill { Id = 31, Value = "Entrenar y Guíar a colegas en el desarrollo", ExperienceId = 4 },
            new Skill { Id = 32, Value = "Realizar Gestión de Datos y Base de Datos SQL Server", ExperienceId = 4 },
            new Skill { Id = 33, Value = "Gestión", ExperienceId = 4 },
            new Skill { Id = 34, Value = "Gestión de Configuración (Azure DevOps)", ExperienceId = 4 },
            new Skill { Id = 35, Value = "Aplicar Entrega Continua y Despliegue Continuo (CI-CD)", ExperienceId = 4 },
            new Skill { Id = 36, Value = "Trabajar eficientemente bajo presión", ExperienceId = 4 },
            new Skill { Id = 37, Value = "Investigar soluciones de manera autodidacta", ExperienceId = 4 },
            new Skill { Id = 38, Value = "Recopilar Datos Ionosféricos", ExperienceId = 5 },
            new Skill { Id = 39, Value = "Herramientas utilizadas: C#, Python (Jupyter Notebook)", ExperienceId = 5 },
            new Skill { Id = 40, Value = "Investigar sobre Aprendizaje Automático y Aprendizaje Profundo", ExperienceId = 5 },
            new Skill { Id = 41, Value = "Trabajo en Equipo", ExperienceId = 5 },
            new Skill { Id = 42, Value = "Automatizar la recolección de datos usando APIs RESTful y ASP.NET", ExperienceId = 5 },
            #endregion
            //Cediad
            new Skill { Id = 43, Value = "Creación y Mantenimiento de Sistemas de Gestión", ExperienceId = 6 },
            new Skill { Id = 44, Value = "Recolección y Análisis de Datos", ExperienceId = 6 },
            new Skill { Id = 45, Value = "Visibilización de la Ocupación de las Canchas", ExperienceId = 6 },
            new Skill { Id = 46, Value = "Categorización de Ganancias", ExperienceId = 6 },
            new Skill { Id = 47, Value = "Cálculo de Rentabilidad Global y Periódica", ExperienceId = 6 }

            );

        modelBuilder.Entity<Detail>().HasData(
            new Detail { Id = 1, Value = "English Certificate A1 - A2", ProfessionalId = 1 },
            new Detail { Id = 2, Value = "English in Certification Process B1", ProfessionalId = 1 },
            new Detail { Id = 3, Value = "Basic French learned in secondary as a Foreign Language", ProfessionalId = 1 },
            new Detail { Id = 4, Value = "Courses Taken on Time Management and Emotional Intelligence", ProfessionalId = 1 },
            new Detail { Id = 5, Value = "General average in the university of 8", ProfessionalId = 1 },
            //Professional 2
            new Detail { Id = 6, Value = "Certificado de Inglés A1 - A2", ProfessionalId = 2 },
            new Detail { Id = 7, Value = "Inglés en Proceso de Certificación B1", ProfessionalId = 2 },
            new Detail { Id = 8, Value = "Francés Básico aprendido en la secundaria como Lengua Extranjera", ProfessionalId = 2 },
            new Detail { Id = 9, Value = "Cursos Realizados sobre Gestión del Tiempo e Inteligencia Emocional", ProfessionalId = 2 },
            new Detail { Id = 10, Value = "Promedio General en la universidad de 8", ProfessionalId = 2 },
            new Detail { Id = 11, Value = "Dueño de Complejo Deportivo Cediad", ProfessionalId = 2 }
            );

        modelBuilder.Entity<Experience>().HasData(
            new Experience
            {
                Id = 1,
                ProfessionalId = 1,
                Name = "Integrator Final Works",
                YearStart = 2019,
                Role = "Project Leader - Programmer",
            },
            new Experience
            {
                Id = 2,
                ProfessionalId = 1,
                Name = "CIASUR - RESEARCH CENTER",
                YearStart = 2022,
                YearFinish = 2023,
                Role = "Collection for Data Analysis - Intern",
            },
            new Experience
            {
                Id = 3,
                ProfessionalId = 1,
                Name = "CEDIAD: Sport Center",
                YearStart = 2023,
                YearFinish = null,
                Role = "Administrator",
            },
            //Professional 2
            new Experience
            {
                Id = 4,
                ProfessionalId = 2,
                Name = "Trabajos Finales Integradores",
                YearStart = 2019,
                Role = "Líder de Proyecto - Programador",
            },
            new Experience
            {
                Id = 5,
                ProfessionalId = 2,
                Name = "CIASUR - CENTRO DE INVESTIGACIÓN",
                YearStart = 2022,
                YearFinish = 2023,
                Role = "Recolección para Análisis de Datos - Pasante",
            },

            new Experience
            {
                Id = 6,
                ProfessionalId = 2,
                Name = "CEDIAD: Complejo Deportivo",
                YearStart = 2023,
                YearFinish = null,
                Role = "Administrador",
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
            },
            //Professional 2
            new Training
            {
                Id = 3,
                ProfessionalId = 2,
                Accademy = "Universidad Tecnológica Nacioanl - UTN",
                Speciality = "Ingenieria en Sitemas de Información",
                YearStart = 2019
            },
            new Training
            {
                Id = 4,
                ProfessionalId = 2,
                Accademy = "Platzi",
                Speciality = "Inglés, Desarrollo de Software y Habilidades Blandas",
                YearStart = 2022
            }
            );

        modelBuilder.Entity<Professional>().HasData(
            new Professional
            {
                Id = 1,
                Name = "Martin Lopez Rubio",
                Language = Language.English,
                Role = "Software Developer / Data Engineer",
                ProfessionalProfile = @"I am an Information Systems Engineering Student with 3 years of
experience in software development. I am looking to collaborate in a
position as a .Net Developer since I have certified in Fundamentals
of Entity Framework, Linq and Blazor."
            },
            new Professional
            {
                Id = 2,
                Name = "Martin Lopez Rubio",
                Language = Language.Spanish,
                Role = "Desarrollador de Software / Ingeniero de Datos",
                ProfessionalProfile = @"Soy estudiante de Ingeniería de Sistemas de Información con 3 años de
experiencia en desarrollo de software y Administrador del Complejo Deportivo Cediad. Busco formar parte del equipo 
de desarrollo de una empresa de software relacionada con el manejo de complejos deportivos, como desarrollador Angular
ya que poseo experiencia en las areas de desarrollo y administracion"
            }
        );
        #endregion
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
