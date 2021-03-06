﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urbanbooks
{
    public class Book : Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int BookID
        { get; set; }
        [Required]
        [RegularExpression(@"^(?=[0-9X]{10}$|(?=(?:[0-9]+[- ]){3})[- 0-9X]{13}$|97[89][0-9]{10}$|(?=(?:[0-9]+[- ]){4})[- 0-9]{17}$)(?:97[89][- ]?)?[0-9]{1,5}[- ]?[0-9]+[- ]?[0-9]+[- ]?[0-9X]$", ErrorMessage = "Incorrect ISBN Number")]
        public string ISBN
        { get; set; }
        [Required]
        [Display(Name="Book Title")]
        public string BookTitle 
        { get; set; }
        [DataType(DataType.MultilineText)]
        public string Synopsis 
        { get; set; }
        [ScaffoldColumn(false)]
        public int PublisherID 
        { get; set; }
        public string pubName
        { get; set; }
        [ScaffoldColumn(false)]
        public int BookCategoryID
        { get; set; }
        public string catName
        { get; set; }
        public string AuthName
        { get; set; }
        [Display(Name="Cover")]
        public string CoverImage
        { get; set; }

        //OVERRIDE

        [ScaffoldColumn(false)]
        public override int ProductID
        { get; set; }
        [ScaffoldColumn(false)]
        [DataType(DataType.Currency)]
        [Display(Name = "Cost Price")]
        [Required]
        public override double CostPrice
        { get; set; }       
        [DataType(DataType.Currency)]
        [Display(Name="Selling Price")]
        public override double SellingPrice
        { get; set; }
        [ScaffoldColumn(false)]
        public override DateTime DateAdded
        { get; set; }        
        [ScaffoldColumn(false)]
        public override bool IsBook
        { get; set; }
        [ScaffoldColumn(true)]
        public override int SupplierID 
        { get; set; }


        [NotMapped]
        List<Publisher> Publisher { get; set; }
    }
}
