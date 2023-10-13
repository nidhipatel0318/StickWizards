using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StickWizards.Models
{
    public class Stick
    {
        public int Id { get; set; }
        public int Length { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]

        public string Material { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]

        public string Texture { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]

        public string Weight { get; set; }

        
    }
}