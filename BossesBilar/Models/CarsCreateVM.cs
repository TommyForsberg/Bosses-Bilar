using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BossesBilar.Models
{
    public class CarsCreateVM
    {
        [Required]
        [Display(Name = "Make")]
        public string Brand { get; set; }

        [Required]
        [Display(Name = "Number of doors")]
        [Range(3,5)]
        public int Doors { get; set; }

        [Required]
        [Range(0,300)]
        public int TopSpeed { get; set; }
    }
}
