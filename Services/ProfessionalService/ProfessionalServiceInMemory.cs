using Model;
using System.Diagnostics.Contracts;

namespace Services
{
    public class ProfessionalServiceInMemory : IProfessionalService
    {
        private List<Professional> _professionals;
        private List<Contact> _contacts;
        private List<Tool> _tools;
        private List<Interest> _interests;
        private List<Skill> _skills;
        private List<Detail> _details;
        private List<Experience> _experiences;
        private List<Training> _trainings;

        public ProfessionalServiceInMemory()
        {
            Iniciar();
        }

        private void Iniciar()
        {
            _tools = new List<Tool>()
            {
                                new Tool
                {
                    Id = 1,
                    Name = "C#",
                    ProfessionalId = 1,
                    Description = "",
                    LogoUrl = "images/Csharp_Logo.png"
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
            };
            _interests = new List<Interest>()
            {
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
            };
            _skills = new List<Skill>() {
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
                new Skill { Id = 21, Value = "Automate data collection using RESTful APIs and ASP.NET", ExperinceId = 2 } };
            _details = new List<Detail>() { new Detail { Id = 1, Value = "English Certificate A1 - A2", ProfessionalId = 1 },
                new Detail { Id = 2, Value = "English in Certification Process B1", ProfessionalId = 1 },
                new Detail { Id = 3, Value = "Basic French learned in secondary as a Foreign Language", ProfessionalId = 1 },
                new Detail { Id = 4, Value = "Courses Taken on Time Management and Emotional Intelligence", ProfessionalId = 1 },
                new Detail { Id = 5, Value = "General average in the university of 7.84", ProfessionalId = 1 }
            };
            _experiences = new List<Experience>() { 
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
                }
            };
            _trainings = new List<Training>()
            {
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
            };
            _professionals = new List<Professional>()
            {
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
            };
            _contacts = new List<Contact>
            {
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
            };
        }



        public async Task<Contact> GetContactFromProfessionalAsync(int professionalId)
            => _contacts.Where(t => t.ProfessionalId == professionalId).Single();

        public async Task<List<Tool>> GetToolsFromProfessionalAsync(int professionalId)
            => _tools.Where(t => t.ProfessionalId == professionalId).ToList();
        
        public async Task<List<Interest>> GetInterestsFromProfessionalAsync(int professionalId)
            => _interests.Where(t => t.ProfessionalId == professionalId).ToList();
        
        public async Task<List<Training>> GetTrainingsFromProfessionalAsync(int professionalId)
            => _trainings.Where(t => t.ProfessionalId == professionalId).ToList();
        
        public async Task<List<Experience>> GetExperiencesFromProfessionalAsync(int professionalId)
            =>  _experiences.Where(t => t.ProfessionalId == professionalId).ToList();
        
        public async Task<List<Detail>> GetAdditionalInfoFromProfessionalAsync(int professionalId)
            =>  _details.Where(t => t.ProfessionalId == professionalId).ToList();
        
        public async Task<List<Skill>> GetSkillsFromExperienceAsync(int experinceId)
            =>  _skills.Where(s => s.ExperinceId == experinceId).ToList();
        

        public async Task<Training> GetTrainingAsync(int id) {
            return _trainings.FirstOrDefault(t => t.Id == id);
        }

        public async Task<Professional?> GetProfessionalAsync(int id)
        {
            return _professionals.FirstOrDefault(p => p.Id == id);
        }
    }
}
