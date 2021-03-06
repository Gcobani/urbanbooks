﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace urbanbooks
{
    public class Manufacturer 
    {
        [Key]
        public int ManufacturerID { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name="Manufacturer")]
        public string Name { get; set; }
        //public List<Technology> TechnologyList { get; set; }
    }
}
