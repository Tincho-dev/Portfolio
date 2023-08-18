namespace Model
{
    public class Professional : EntidadBase
    {
        public int Id { get; set; }
        public string Role { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ProfessionalProfile { get; set; } = string.Empty;
        public virtual List<Interest> Interests { get; set; } = new List<Interest>();
        public virtual List<Experience> Experiences { get; set; } = new List<Experience>();
        public virtual List<Detail> AdditionalInfo { get; set; } = new List<Detail>();
        public virtual List<Tool> Tools { get; set; } = new List<Tool>();
        public virtual List<Training> Trainings { get; set; } = new List<Training>();
        public virtual Contact? Contact { get; set; }
    }


    public class Interest : EntidadBase
    {
        public int Id { get; set; }
        public int ProfessionalId { get; set; }
        public virtual Professional? Professional { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
    public class Detail : EntidadBase
    {
        public int Id { get; set; }
        public int ProfessionalId { get; set; }
        public virtual Professional? Professional{ get; set; }
        public string Value { get; set; } = string.Empty;
    }
    public class Skill : EntidadBase
    {
        public int Id { get; set; }
        public int ExperienceId { get; set; }
        public virtual Experience? Experience { get; set; }
        public string Value { get; set; } = string.Empty;
    }

    public class Experience : EntidadBase
    {
        public int Id { get; set; }
        public int ProfessionalId { get; set; }
        public virtual Professional? Professional { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public virtual List<Skill> Skills { get; set; } = new List<Skill>();
        public int YearStart { get; set; }
        public int? YearFinish { get; set; }

        public bool IsValid()
            => !YearFinish.HasValue || YearStart <= YearFinish.Value;
    }

    public class Category : EntidadBase
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class Tool : EntidadBase
    {
        public int Id { get; set; }
        public int ProfessionalId { get; set; }
        public virtual Professional? Professional { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
    }

    public class Training : EntidadBase
    {
        public int Id { get; set; }
        public int ProfessionalId { get; set; }
        public virtual Professional? Professional { get; set; }
        public string Accademy { get; set; } = string.Empty;
        public string Speciality { get; set; } = string.Empty;
        public int YearStart { get; set; }
        public int? YearFinish { get; set; }

        public bool IsValid()
            => !YearFinish.HasValue || YearStart <= YearFinish.Value;
    }

    public class Contact : EntidadBase
    {
        public int Id { get; set; }
        public int ProfessionalId { get; set; }
        public virtual Professional? Professional { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string LinkedIn { get; set; } = string.Empty;
        public string Github { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
    }
}
