using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Letra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        [MaxLength(1)]
        public string Name { get; set; }
        [Required]
        public float Probability { get; set; }
        public float Information { get; set; }
        public string Code { get; set; } = string.Empty;
        public int FrecuenciaDeAparicion { get; set; }
        public string IdFuente { get; set; }
        [ForeignKey("IdFuente")]
        public virtual Fuente Fuente { get; set; }
        #region Contructor
        public Letra()
        {
            Id = Guid.NewGuid().ToString();
        }

        public Letra(string name, double probability, int freq)
        {
            Name = name;
            Probability = (float)probability;
            Information = (float)(Math.Log(1 / probability) / Math.Log(2));
            FrecuenciaDeAparicion = freq;
        }
        #endregion
    }
}
