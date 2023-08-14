namespace Model.About
{
    public class Professional
    {
        public int Id { get; set; }
        public string Role { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ProfessionalProfile { get; set; } = string.Empty;
        public ICollection<Interest> Interests { get; set; } = new List<Interest>();
        public ICollection<Experience> Experiences { get; set; } = new List<Experience>();
        public string[]? AdditionalInfo { get; set; } 
        public ICollection<Tool> Tools { get; set; } = new List<Tool>();
        public ICollection<Training> Trainings { get; set; } = new List<Training>();
        public Contact? Contact { get; set; }
    }

    public class Interest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class Tool
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
    }

    public class TimeFrame
    {
        public int Id { get; set; }
        public int YearStart { get; set; }
        public int? YearFinish { get; set; }

        public bool IsValid()
        {
            return !YearFinish.HasValue || YearStart <= YearFinish.Value;
        }
    }

    public class Experience
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string[]? Skills { get; set; }
        public int TimeFrameId { get; set; }
        public TimeFrame TimeFrame { get; set; } = new TimeFrame { YearStart = DateTime.UtcNow.Year, YearFinish = DateTime.UtcNow.Year };
    }

    public class Training
    {
        public int Id { get; set; }
        public string Accademy { get; set; } = string.Empty;
        public string Speciality { get; set; } = string.Empty;
        public int TimeFrameId { get; set; }
        public TimeFrame TimeFrame { get; set; } = new TimeFrame { YearStart = DateTime.UtcNow.Year, YearFinish = DateTime.UtcNow.Year };
    }

    public class Contact
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string LinkedIn { get; set; } = string.Empty;
        public string Github { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}
